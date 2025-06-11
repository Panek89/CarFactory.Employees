using CarFactory.Employees.Domain.Common;
using CarFactory.Employees.Domain.Events.EmployeeRequest;
using Microsoft.Extensions.Logging;

namespace CarFactory.Employees.Application.Features.EmployeeRequests.Events;

public class AssignedCandidateEventHandler : IDomainEventHandler<AssignedCandidateEvent>
{
    private readonly ILogger<AssignedCandidateEventHandler> _logger;

    public AssignedCandidateEventHandler(ILogger<AssignedCandidateEventHandler> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task HandleAsync(AssignedCandidateEvent domainEvent, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Candidate assigned to request with ID: {RequestId} on {OccurredOn}",
                domainEvent.RequestId, domainEvent.OccurredOn);

        await Task.Delay(100, cancellationToken);
    }
}
