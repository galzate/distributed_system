using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


var builder = WebApplication.CreateBuilder(args);


// Configuración de Redis
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "localhost:6379"; // Cambia esto según tu configuración de Redis
    options.InstanceName = "SampleInstance";
});


var app = builder.Build();


app.Run();
