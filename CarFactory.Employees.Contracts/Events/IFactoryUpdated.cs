namespace CarFactory.Employees.Contracts.Events;

public interface IFactoryUpdated
{
    public Guid FactoryId { get; }
    public string Name { get; }
    public string City { get; }
    public int NumberOfEmployees { get; }
    public bool IsDeleted { get; set; }
}
