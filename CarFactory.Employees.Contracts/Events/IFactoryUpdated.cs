namespace CarFactory.Employees.Contracts.Events;

public interface IFactoryUpdated
{
    public Guid Id { get; }
    public string Name { get; }
    public bool IsOpen { get; }
}
