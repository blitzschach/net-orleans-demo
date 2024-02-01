using System.Net;

var builder = WebApplication.CreateBuilder(args);

int.TryParse(Environment.GetEnvironmentVariable("SILO_PORT"), out var siloPort);
int.TryParse(Environment.GetEnvironmentVariable("GATEWAY_PORT"), out var gatewayPort);
int.TryParse(Environment.GetEnvironmentVariable("DASHBOARD_PORT"), out var dashboardPort);
int.TryParse(Environment.GetEnvironmentVariable("PRIMARY_SILO_PORT"), out var primarySiloPort);

builder.Services.AddOrleans(siloBuilder =>
{
    siloBuilder.UseLocalhostClustering(
        siloPort,
        gatewayPort, 
        new IPEndPoint(IPAddress.Loopback, primarySiloPort));
    
    siloBuilder.UseDashboard(o =>
    {
        o.Port = dashboardPort;
    });
});

var app = builder.Build();

app.Run();