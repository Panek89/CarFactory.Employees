using CarFactory.Employees.Domain.Common;

namespace CarFactory.Employees.Domain.Entities;

public class Factory : BaseEntity
{
    public Guid FactoryId { get; set; }
    public required string Name { get; set; }
    public bool IsOpen { get; set; }
}
