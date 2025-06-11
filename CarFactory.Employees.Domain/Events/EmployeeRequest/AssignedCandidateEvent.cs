using CarFactory.Employees.Domain.Common;

namespace CarFactory.Employees.Domain.Events.EmployeeRequest;

public class AssignedCandidateEvent : DomainEvent
{
    public Guid RequestId { get; }

    public AssignedCandidateEvent(Guid requestId)
    {
        RequestId = requestId;
    }
}
