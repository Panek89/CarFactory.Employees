namespace CarFactory.Employees.Contracts.Events;

public interface IFactoryCreated
{
    public Guid Id { get; }
    public string Name { get; }
    public bool IsOpen { get; }
}
