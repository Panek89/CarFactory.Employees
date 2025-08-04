using CarFactory.Employees.Application.Features.EmployeeRequests;
using CarFactory.Employees.Application.Features.Employees;
using CarFactory.Employees.Domain.Common;
using CarFactory.Employees.Domain.Repositories;
using CarFactory.Employees.Infrastructure.Consumers;
using CarFactory.Employees.Infrastructure.Events;
using CarFactory.Employees.Infrastructure.Repositories;
using CarFactory.Employees.Infrastructure.Services;
using CarFactory.Employees.SharedLibrary.Options;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CarFactory.Employees.Infrastructure;

public static class InfrastructureServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IEmployeeRequestRepository, EmployeeRequestRepository>();
        services.AddScoped<IEmployeeRequestCandidateRepository, EmployeeRequestCandidateRepository>();
        services.AddScoped<IFactoryRepository, FactoryRepository>();

        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IEmployeeRequestService, EmployeeRequestService>();

        services.AddScoped<IDomainEventDispatcher, DomainEventDispatcher>();

        return services;
    }

    public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString));

        return services;
    }

    public static IServiceCollection RegisterMassTransit(this IServiceCollection services, AppSettingsConfiguration configuration)
    {
        services.AddMassTransit(conf =>
        {
            conf.AddConsumer<FactoryCreatedConsumer>();
            conf.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(configuration.RabbitMq.HostName, "/", h =>
                {
                    h.Username(configuration.RabbitMq.Username);
                    h.Password(configuration.RabbitMq.Password);
                });

                cfg.ReceiveEndpoint(configuration.Contracts.FactoriesQueue, e =>
                {
                    e.ConfigureConsumer<FactoryCreatedConsumer>(context);
                });
            });
        });

        return services;
    }
}
