using CarFactory.Employees.Application.Features.EmployeeRequests;
using CarFactory.Employees.Application.Features.Employees;
using CarFactory.Employees.Domain.Common;
using CarFactory.Employees.Domain.Repositories;
using CarFactory.Employees.Infrastructure.Events;
using CarFactory.Employees.Infrastructure.Repositories;
using CarFactory.Employees.Infrastructure.Services;
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
}
