namespace CarFactory.Employees.Domain.Common;

public interface IDomainEventHandler<in T> where T : DomainEvent
{
    Task HandleAsync(T domainEvent, CancellationToken cancellationToken = default);
}
