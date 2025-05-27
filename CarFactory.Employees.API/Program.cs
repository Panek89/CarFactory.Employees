using CarFactory.Employees.API.Extensions;
using CarFactory.Employees.Application;
using CarFactory.Employees.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructure();
builder.Services.AddDatabase(builder.Configuration.GetConnectionString("SQLSERVER")!);
builder.Services.AddApplication();

var app = builder.Build();

// Configure the HTTP request pipeline.
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
