using CarFactory.Employees.Domain.Models;
using CarFactory.Employees.Domain.ValueObjects;

namespace CarFactory.Employees.Domain.Repositories;

public interface IEmployeeRepository : IBaseRepository<Employee>
{
    Task<EmployeeDetails?> GetEmployeeDetailsAsync(Guid id, CancellationToken token);
}
