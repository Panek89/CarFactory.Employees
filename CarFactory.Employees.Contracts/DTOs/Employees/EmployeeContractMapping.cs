using CarFactory.Employees.Domain.Models;

namespace CarFactory.Employees.Contracts.DTOs.Employees;

public static class EmployeeContractMapping
{
    public static EmployeeDetailsDto MapToDto(this Employee employee)
    {
        return new EmployeeDetailsDto()
        {
            
        };
    }
}
