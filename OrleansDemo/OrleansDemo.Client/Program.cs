using Microsoft.AspNetCore.Mvc;
using OrleansDemo.Grains;

var builder = WebApplication.CreateBuilder(args);

int.TryParse(Environment.GetEnvironmentVariable("GATEWAY_PORT"), out var gatewayPort);

builder.Services.AddOrleansClient(clientBuilder =>
{
    clientBuilder.UseLocalhostClustering(gatewayPort);
});

var app = builder.Build();

app.MapGet("/greet", async ([FromServices] IClusterClient client) =>
{
    var person = new Person
    {
        Firstname = "John",
        Lastname = "Doe"
    };
    
    var grain = client.GetGrain<IGreeterGrain>(Guid.NewGuid());

    await grain.Greet(person);
});

app.Run();