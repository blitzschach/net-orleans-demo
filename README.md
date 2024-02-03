# net-orleans-demo

This project demonstrates Microsoft Orleans localhost clustering.

## Run

### Server

You can run up to 3 servers / silos. <br>
Since every silo needs different ports, there is a launchSettings profile for each silo.

Silo 1 is considered the primary silo the others connect to in order to form a cluster. <br>
Therefore, silo 1 needs to be started at all times.

```powershell
dotnet run --project ./OrleansDemo.Server/OrleansDemo.Server.csproj --launch-profile silo1
dotnet run --project ./OrleansDemo.Server/OrleansDemo.Server.csproj --launch-profile silo2
dotnet run --project ./OrleansDemo.Server/OrleansDemo.Server.csproj --launch-profile silo3
```

A dashboard will be provided for each server instance. <br>
You can visit the dashboard of server / silo 1 at the following address:

```
http://localhost:10103/
```

### Client

The client must connect to a specific silo. <br>
Thus, there are predefined profiles in the client launchSettings as well.

Start the client using one of the profiles.

```powershell
dotnet run --project ./OrleansDemo.Client/OrleansDemo.Client.csproj --launch-profile silo1
```

### Requesting Grains

The client provides a `/greet` endpoint which can be called to request a `GreeterGrain`.

```powershell
curl http://localhost:9500/greet
```