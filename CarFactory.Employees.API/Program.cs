using CarFactory.Employees.API.Extensions;
using CarFactory.Employees.Application;
using CarFactory.Employees.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructure();
builder.Services.AddDatabase(builder.Configuration.GetConnectionString("SQLSERVER")!);
builder.Services.AddApplication();
builder.Services.RegisterEvents();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.RegisterDevelopment();
}

if (!app.Environment.IsDevelopment())
{
    app.RegisterNonDevelopment();
}


app.UseAuthorization();

app.MapControllers();

app.RunMigrations();

app.Run();
