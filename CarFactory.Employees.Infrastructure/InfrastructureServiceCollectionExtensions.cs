using CarFactory.Employees.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CarFactory.Employees.Infrastructure;

public static class InfrastructureServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IEmployeeRequestRepository, EmployeeRequestRepository>();

        return services;
    }

    public static IServiceCollection AddDatabase(this IServiceCollection services,
       string connectionString)
    {
        // TODO

        return services;
    }
}
