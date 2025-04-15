using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CarFactory.Employees.Application;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(typeof(IApplicationMarker));

        return services;
    }
}
