# Heating OPC UA Example

This example exposes a thermostat with a temperature, writable setpoint, and
Boost method. Use UaExpert to test the running server and SiOME to edit the
information model.

All PowerShell commands below run from the repository root unless stated otherwise.

## Prerequisites

- .NET 10 SDK for the server and sample client.
- [UaExpert](https://www.unified-automation.com/products/development-tools/uaexpert.html)
  for browsing, reading, writing, and calling methods.
- Siemens OPC UA Modeling Editor (SiOME) for editing NodeSet2 models.
- OPC Foundation ModelCompiler for converting the ModelDesign files to NodeSet2.

Install ModelCompiler as a global .NET tool; a source checkout is not required:

```powershell
dotnet tool install --global OPCFoundation.Opc.Ua.ModelCompiler.Tool
Opc.Ua.ModelCompiler compile --help
```

If already installed, update it instead:

```powershell
dotnet tool update --global OPCFoundation.Opc.Ua.ModelCompiler.Tool
```

If the executable is not found, reopen the terminal or invoke it using its full
Windows path:

```powershell
& "$HOME/.dotnet/tools/Opc.Ua.ModelCompiler.exe" compile --help
```

## Start the Server

```powershell
dotnet run --project ./GettingStartedServer
```

Keep this terminal running. The endpoint is:

```text
opc.tcp://localhost:62560/GettingStartedServer
```

The server stores its certificates relative to its content root. When launched
from the project directory, this is `GettingStartedServer/pki`. Check the absolute
certificate-store path in the server logs if your launch configuration uses a
different working directory.

To run the sample client in a second terminal:

```powershell
dotnet run --project ./GettingStartedClient
```

The sample client has its own certificate and completes after its demonstrations;
its exit does not stop the server.

## UaExpert Connection

1. Add a server using the endpoint above and discover its endpoints.
2. Select security policy **Basic256Sha256** and message security mode
   **SignAndEncrypt** from the advertised endpoints.
3. Use **Anonymous** authentication if advertised by the server.
4. Inspect the server certificate and trust it in UaExpert if it belongs to this
   server. Confirm its identity against the certificate in the server's PKI store.
5. Connect. If the server rejects UaExpert's certificate, follow the trust procedure
   below, then reconnect.

Browse `Objects -> Thermostat` to inspect `Temperature`, `Setpoint`, and `Boost`.
The valid setpoint range is 5 to 30 degrees Celsius. Writes or Boost calls outside
that range return `BadOutOfRange`.

Look for `ThermostatType` under `Types -> ObjectTypes -> BaseObjectType` if it is
exposed by the running server. To inspect the model independently of what the
server publishes, import the generated NodeSet2 files into SiOME.

## Certificate Trust and Reconnect Loops

Server and client trust are separate: the client must trust the server certificate,
and the server must trust the client certificate. Trusting UaExpert does not trust
SiOME or the sample client; each application has its own certificate.

These server messages indicate a rejected client certificate, not a model problem:

```text
BadCertificateUntrusted
Could not verify security on OpenSecureChannel request.
```

The client may appear to connect and immediately reconnect because the secure
channel never opens successfully.

### Trust a Specific Client Certificate

1. Attempt a connection so the server records the rejected certificate.
2. Read its subject and thumbprint in the server log.
3. Compare the thumbprint with the application certificate displayed by your client.
   Only trust the certificate when its identity is confirmed.
4. Copy that exact public certificate from the rejected store to the trusted store.

For the UaExpert certificate encountered during setup, the command is:

```powershell
Copy-Item -LiteralPath './GettingStartedServer/pki/rejected/certs/UaExpert@MSG-NB-C4BSZF4 [48F030F4EA532DD4FF1D62008C8C48A18E9BD207].der' -Destination './GettingStartedServer/pki/trusted/certs/'
```

This filename and thumbprint are machine-specific. For another installation or
SiOME, substitute the verified certificate's actual filename. `-LiteralPath` is
important because square brackets in filenames are wildcard characters otherwise.
Use the store path printed in the logs if it differs from the example.

Reconnect after copying. If trust is not reloaded automatically, stop and restart
the server. Also resolve any server-certificate trust prompt in the client.

Do not copy private keys, trust every rejected certificate, or disable certificate
validation. `BadCertificateTimeInvalid`, hostname errors, and application-URI errors
need their own corrections; adding trust alone does not fix them.

## Generate NodeSet2 for SiOME

[Models/Heating.Common.xml](Models/Heating.Common.xml) and
[Models/Heating.xml](Models/Heating.xml) use OPC UA **ModelDesign**, not **NodeSet2**.
The C# source generator consumes these files during the server build. A successful
`dotnet build` does not automatically export NodeSet2 files for SiOME.

The namespace URIs are case-sensitive:

| Model | Namespace URI | Contents |
| --- | --- | --- |
| Common | `http://messring.de/ua` | `TemperatureVariableType` and shared `BoostMethodType` declaration |
| Heating | `http://messring.de/UA/Heating` | `ThermostatType` and `Thermostat` instance |

Generate the common model first, then Heating with the common ModelDesign as an
included dependency. These commands were tested with ModelCompiler **2.8.15**.
Keep the identifier CSVs beside the model files so dependency NodeIds match:

```powershell
New-Item -ItemType Directory -Force ./Models/Generated | Out-Null
Opc.Ua.ModelCompiler compile -d2 ./Models/Heating.Common.xml -cg ./Models/Heating.Common.csv -o2 ./Models/Generated
if ($LASTEXITCODE -ne 0) { throw 'Common model compilation failed.' }
Opc.Ua.ModelCompiler compile -d2 ./Models/Heating.xml -d2 ./Models/Heating.Common.xml -cg ./Models/Heating.csv -o2 ./Models/Generated
if ($LASTEXITCODE -ne 0) { throw 'Heating model compilation failed.' }
Get-ChildItem ./Models/Generated -Filter '*.NodeSet2.xml'
```

According to the ModelCompiler command documentation:

- The first `-d2` input is the model to generate; subsequent inputs are dependencies.
- Inputs can be ModelDesign or NodeSet2. Both inputs above are ModelDesign files.
- For a NodeSet2 dependency, the optional comma-separated suffix specifies its
   namespace prefix and short model name. Quote such arguments in PowerShell.
- `-cg` creates the identifier CSV if needed. Keep and version the resulting CSV
  files so regenerated models retain stable identifiers.
- `-o2` selects the output directory. Generated output also includes code and other
  artifacts; SiOME needs the `*.NodeSet2.xml` files, not the generated C# files.

These commands export models for offline tooling; they do not replace the server's
source-generator configuration. Do not assume independently generated numeric
NodeIds match the live server without verifying them.

### Common Model Dependency

If SiOME reports `Model depends on other models` and asks for
`http://messring.de/ua`, import the common NodeSet2 before the Heating NodeSet2.
Passing a dependency to ModelCompiler does not export that dependency automatically.

The common model defines `TemperatureVariableType`, used by the Heating
`Temperature` variable. Both exports and the cross-namespace type NodeId have been
checked. The earlier method-only common model caused an empty export and a
`NullReferenceException` with compiler 2.8.15; the concrete variable type resolves
that export failure.

Keep `Models/Heating.Common.csv` and `Models/Heating.csv` alongside the XML sources
and retain them across regenerations. Generating the common CSV only in a temporary
output directory can leave Heating referencing a different common NodeId.

### Import into SiOME

1. Open a SiOME project with the standard OPC UA base model available.
2. Import [Models/Generated/Common.NodeSet2.xml](Models/Generated/Common.NodeSet2.xml)
   first. If an older empty common model is already loaded, replace it with this
   regenerated version or use a fresh project.
3. Import [Models/Generated/Heating.NodeSet2.xml](Models/Generated/Heating.NodeSet2.xml).
4. Inspect the common namespace for `TemperatureVariableType` under VariableTypes
   and Heating for `ThermostatType` and its `Boost` method.

Import commands and menu names vary by SiOME version. Importing local NodeSet2
files does not require a live server or certificate trust. Connecting SiOME to the
server is a separate workflow and requires trusting SiOME's own certificate.

`BoostMethodType` is a reusable method declaration, not an ObjectType. Do not expect
it under `ObjectTypes` alongside `ThermostatType`.

## References

- [OPC Foundation ModelCompiler: installation, usage, and command options](https://github.com/OPCFoundation/UA-ModelCompiler#readme)
- [UaExpert downloads and product documentation](https://www.unified-automation.com/products/development-tools/uaexpert.html)
- [Siemens OPC UA Modeling Editor (SiOME)](https://support.industry.siemens.com/cs/document/109755133)
- [SiOME manual](https://www.siemens.com/siome/manual)

Use the installed SiOME version's help for its exact import and certificate-manager
menus. ModelCompiler CLI syntax above follows the current upstream README.