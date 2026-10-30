using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Opc.Ua;
using Opc.Ua.Client;
using Opc.Ua.Client.Subscriptions;
using Opc.Ua.Client.Subscriptions.Streaming;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
builder.Logging.SetMinimumLevel(LogLevel.Warning);

builder.Services
    .AddOpcUa()
    .AddClient(options =>
    {
        options.ApplicationName = "GettingStartedClient";
        options.ApplicationUri = "urn:localhost:GettingStartedClient";
        options.ProductUri = "urn:example.com:GettingStartedClient";
        options.PkiRoot = Path.Combine(builder.Environment.ContentRootPath, "pki");
        options.Session = new ManagedSessionOptions
        {
            ReconnectPolicy = new ReconnectPolicyOptions { MaxRetries = 2 },
        };
    })
    .AddDiscoveryAndConnect(options =>
    {
        options.DiscoveryUrl = "opc.tcp://localhost:62560/GettingStartedServer";
        options.SecurityMode = MessageSecurityMode.SignAndEncrypt;
        options.SecurityPolicyUri = SecurityPolicies.Basic256Sha256;
    });

using IHost host = builder.Build();
await host.StartAsync();

using var timeout = new CancellationTokenSource(TimeSpan.FromMinutes(1));
CancellationToken ct = timeout.Token;

try
{
    var connect = host.Services
        .GetRequiredService<Func<CancellationToken, Task<ManagedSession>>>();
    ManagedSession session = await connect(ct);
    await using (session)
    {
        Console.WriteLine($"Connected to {session.ConfiguredEndpoint?.EndpointUrl}");

        // The server assigns the namespace index at run time. Look it up
        // from the namespace URI that the model defines.
        int namespaceIndex = session.NamespaceUris.GetIndex(Heating.Namespaces.Heating);
        if (namespaceIndex < 0)
        {
            throw new ServiceResultException(
                StatusCodes.BadNotFound,
                "The server does not expose the Heating model.");
        }

        var ns = (ushort)namespaceIndex;
        Console.WriteLine($"Heating namespace index: {ns}");

        // Translate three browse paths, starting at the Objects folder, in one request.
        TranslateBrowsePathsToNodeIdsResponse translated =
            await session.TranslateBrowsePathsToNodeIdsAsync(
                null,
                [
                    PathFromObjects(ns, Heating.BrowseNames.Thermostat),
                    PathFromObjects(ns, Heating.BrowseNames.Thermostat,
                        Heating.BrowseNames.Temperature),
                    PathFromObjects(ns, Heating.BrowseNames.Thermostat,
                        Heating.BrowseNames.Setpoint),
                ],
                ct);
        NodeId thermostatId = GetTarget(session, translated.Results[0]);
        NodeId temperatureId = GetTarget(session, translated.Results[1]);
        NodeId setpointId = GetTarget(session, translated.Results[2]);

        // Read both variables in one request. Each value has its own status.
        (ArrayOf<DataValue> values, ArrayOf<ServiceResult> errors) =
            await session.ReadValuesAsync([temperatureId, setpointId], ct);
        PrintValue("Temperature", values[0], errors[0]);
        PrintValue("Setpoint", values[1], errors[1]);

        // Write a valid setpoint, then one outside the range the server accepts.
        foreach (double setpoint in new[] { 22.5, 35.0 })
        {
            WriteResponse response = await session.WriteAsync(
                null,
                [
                    new WriteValue
                    {
                        NodeId = setpointId,
                        AttributeId = Attributes.Value,
                        Value = new DataValue(new Variant(setpoint)),
                    },
                ],
                ct);

            // The Write service succeeds as a whole; each write has its own result.
            Console.WriteLine($"Write Setpoint {setpoint}: {response.Results[0]}");
        }

        // Call the Boost method through the client generated from the model.
        var thermostat = new Heating.ThermostatTypeClient(
            session,
            thermostatId,
            host.Services.GetRequiredService<ITelemetryContext>());
        double newSetpoint = await thermostat.BoostAsync(2.0, ct);
        Console.WriteLine($"Boost 2: new setpoint {newSetpoint}");
        try
        {
            await thermostat.BoostAsync(10.0, ct);
        }
        catch (ServiceResultException ex)
        {
            Console.WriteLine($"Boost 10: {ex.StatusCode}");
        }

        // Monitor the same variable and stop after three notifications.
        Console.WriteLine("Waiting for three temperature updates...");
        await foreach (DataValueChange change in session.DefaultStreaming
            .SubscribeDataChangesAsync(temperatureId, ct: ct)
            .TakeAsync(3)
            .WithCancellation(ct))
        {
            PrintValue("New Temperature: ", change.Value, StatusCodes.Good);
        }

        // Monitor the same variable and stop after three notifications.
        Console.WriteLine("Waiting for three data changes...");
        await foreach (DataValueChange change in session.DefaultStreaming
            .SubscribeDataChangesAsync(VariableIds.Server_ServerStatus_CurrentTime, ct: ct)
            .TakeAsync(3)
            .WithCancellation(ct))
        {
            PrintTime("Update: ", change.Value);
        }
    }
}
catch (ServiceResultException ex)
{
    Console.Error.WriteLine($"OPC UA error {ex.StatusCode}: {ex.Message}");
    Environment.ExitCode = 1;
}
catch (OperationCanceledException)
{
    Console.Error.WriteLine("The client did not finish within one minute.");
    Environment.ExitCode = 1;
}
finally
{
    await host.StopAsync();
}

static BrowsePath PathFromObjects(ushort ns, params string[] browseNames)
{
    return new BrowsePath
    {
        StartingNode = ObjectIds.ObjectsFolder,
        RelativePath = new RelativePath
        {
            Elements = browseNames
                .Select(name => new RelativePathElement
                {
                    ReferenceTypeId = ReferenceTypeIds.HierarchicalReferences,
                    IncludeSubtypes = true,
                    TargetName = new QualifiedName(name, ns),
                })
                .ToArray(),
        },
    };
}

static NodeId GetTarget(ManagedSession session, BrowsePathResult result)
{
    if (StatusCode.IsBad(result.StatusCode) || result.Targets.Count == 0)
    {
        throw new ServiceResultException(
            result.StatusCode,
            "A browse path was not found.");
    }
    return ExpandedNodeId.ToNodeId(result.Targets[0].TargetId, session.NamespaceUris);
}

static void PrintValue(string name, DataValue value, ServiceResult error)
{
    if (ServiceResult.IsBad(error) || StatusCode.IsBad(value.StatusCode))
    {
        Console.WriteLine($"{name}: failed with {value.StatusCode}");
    }
    else if (value.WrappedValue.TryGetValue(out double number))
    {
        Console.WriteLine($"{name}: {number} ({value.StatusCode})");
    }
    else
    {
        Console.WriteLine($"{name}: unexpected value {value.WrappedValue}");
    }
}

static void PrintTime(string label, DataValue value)
{
    if (StatusCode.IsBad(value.StatusCode))
    {
        Console.WriteLine($"{label}: failed with {value.StatusCode}");
    }
    else if (value.WrappedValue.TryGetValue(out DateTimeUtc time))
    {
        Console.WriteLine($"{label}: {time} (status {value.StatusCode})");
    }
    else
    {
        Console.WriteLine($"{label}: unexpected value {value.WrappedValue}");
    }
}