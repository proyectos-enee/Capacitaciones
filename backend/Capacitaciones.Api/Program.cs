using Capacitaciones.Api.Plumbing.Extensions;

DotNetEnv.Env.Load();
IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables()
    .Build();

var builder = WebApplication.CreateBuilder(args);

builder.AddServer(configuration);
var app = builder.Build();

await app.UseServer(args);
