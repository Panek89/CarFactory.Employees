using CarFactory.Employees.API.Extensions;
using CarFactory.Employees.Application;
using CarFactory.Employees.Infrastructure;
using CarFactory.Employees.SharedLibrary.Options;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureOptions();

builder.Services.AddControllers();
builder.Services.AddHttpClient();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructure();
builder.Services.AddDatabase(builder.Configuration.GetConnectionString("SQLSERVER")!);
builder.Services.AddApplication();
builder.Services.RegisterEvents();
builder.Services.RegisterMassTransit(
    builder.Configuration.GetSection(AppSettingsConfiguration.AppSettings).Get<AppSettingsConfiguration>()!);
builder.Services.AddHealthChecks();

builder.ConfigureJwt(
    builder.Configuration.GetSection(KeycloakConfiguration.Keycloak).Get<KeycloakConfiguration>()!
);
builder.Services.AddAuthorization();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.RegisterDevelopment();
}

if (!app.Environment.IsDevelopment())
{
    app.RegisterNonDevelopment();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapHealthChecks("/healthy").AllowAnonymous();

app.RunMigrations();

app.Run();
