namespace CarFactory.Employees.Contracts.Events;

public interface IFactoryCreated
{
    public Guid Id { get; }
    public string Name { get; }
    public string City { get; }
    public int NumberOfEmployees { get; }
}
