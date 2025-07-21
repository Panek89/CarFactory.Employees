using System;
using CarFactory.Employees.Domain.Common;
using CarFactory.Employees.Domain.Events.EmployeeRequest;
using Microsoft.Extensions.Logging;

namespace CarFactory.Employees.Application.Features.EmployeeRequests.Events;

public class RegisterEmployeeRequestEventHandler : IDomainEventHandler<RegisterEmployeeRequestEvent>
{
    private readonly ILogger<RegisterEmployeeRequestEventHandler> _logger;

    public RegisterEmployeeRequestEventHandler(ILogger<RegisterEmployeeRequestEventHandler> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task HandleAsync(RegisterEmployeeRequestEvent domainEvent, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation
        (
            "Employee request register for {NoOfEmployees} no of employees in business {Business}, ID: {RequestId} on {OccurredOn}",
            domainEvent.NoOfEmployeesNeeded, domainEvent.Business, domainEvent.RequestId, domainEvent.OccurredOn
        );

        await Task.Delay(100, cancellationToken);
    }
}
