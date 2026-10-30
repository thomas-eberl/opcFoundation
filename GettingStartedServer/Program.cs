using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddOpcUa()
    .AddServer(options =>
    {
        options.ApplicationName = "GettingStartedServer";
        options.ApplicationUri = "urn:localhost:GettingStartedServer";
        options.ProductUri = "urn:example.com:GettingStartedServer";
        options.EndpointUrls.Add("opc.tcp://localhost:62560/GettingStartedServer");
        options.PkiRoot = Path.Combine(builder.Environment.ContentRootPath, "pki");
    })
    .AddNodeManager<Heating.HeatingNodeManagerFactory>();

await builder.Build().RunAsync();