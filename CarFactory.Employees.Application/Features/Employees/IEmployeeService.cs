using CarFactory.Employees.Contracts.DTOs.Employees;
using CarFactory.Employees.Domain.ValueObjects;

namespace CarFactory.Employees.Application.Features.Employees;

public interface IEmployeeService
{
    Task<EmployeeDetailsDto?> GetEmployeeDetailsAsync(Guid id, CancellationToken token);
    Task<EmployeeDetailsDto?> GetEmployeeDetailsAsync(PersonalId personalId, CancellationToken token);
}
