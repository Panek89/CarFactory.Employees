using CarFactory.Employees.Application.Features.EmployeeRequests.Events;
using CarFactory.Employees.Domain.Common;
using CarFactory.Employees.Domain.Events.EmployeeRequest;
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

    public static IServiceCollection RegisterEvents(this IServiceCollection services)
    {
        services.AddScoped<IDomainEventHandler<AssignedCandidateEvent>, AssignedCandidateEventHandler>();

        return services;
    }
}
