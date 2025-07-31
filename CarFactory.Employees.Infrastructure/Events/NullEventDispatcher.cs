using CarFactory.Employees.Domain.Common;

namespace CarFactory.Employees.Infrastructure.Events;

internal class NullEventDispatcher : IDomainEventDispatcher
{
    public Task DispatchAsync(DomainEvent domainEvent, CancellationToken cancellationToken = default)
    {
        return Task.CompletedTask;
    }

    public Task DispatchAsync(IEnumerable<DomainEvent> domainEvents, CancellationToken cancellationToken = default)
    {
        return Task.CompletedTask;
    }
}
