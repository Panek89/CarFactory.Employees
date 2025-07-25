using CarFactory.Employees.API.Extensions;
using CarFactory.Employees.Application;
using CarFactory.Employees.Infrastructure;
using CarFactory.Employees.SharedLibrary.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureOptions();

builder.Services.AddControllers();
builder.Services.AddHttpClient();
builder.Services.AddInfrastructure();
builder.Services.AddDatabase(builder.Configuration.GetConnectionString("SQLSERVER")!);
builder.Services.AddApplication();
builder.Services.RegisterEvents();
builder.Services.RegisterMassTransit(
    builder.Configuration.GetSection(AppSettingsConfiguration.AppSettings).Get<AppSettingsConfiguration>()!);
builder.Services.AddHealthChecks();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CarFactory_Employees_API", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Insert JWT access token",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

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
