using CarFactory.Employees.Domain.Models;

namespace CarFactory.Employees.Application.Features.Employees.DTOs;

public static class EmployeeContractMapping
{
    public static EmployeeDetailsDto MapToDto(this Employee employee)
    {
        return new EmployeeDetailsDto()
        {
            
        };
    }
}
