using CarFactory.Employees.Application.Features.EmployeeRequests.Commands;
using CarFactory.Employees.Domain.Models;

namespace CarFactory.Employees.Application.Features.EmployeeRequests.DTOs;

public static class EmployeeRequestContractMapping
{
    public static EmployeeRequest MapToEmployeeRequest(this RegisterEmployeeRequestQuery query)
    {
        return new EmployeeRequest()
        {
            Id = Guid.NewGuid(),
            NoOfEmployeesNeeded = query.NoOfEmployeesNeeded,
            Business = query.Business,
            StartDate = query.StartDate,
            Status = query.Status,
            IsDeleted = false,
            CreatedAt = DateTime.UtcNow,
            CreatedBy = "SYSTEM"
        };
    }

    public static EmployeeRequestDto MapToDto(this EmployeeRequest employeeRequest)
    {
        return new EmployeeRequestDto()
        {
            Id = employeeRequest.Id,
            NoOfEmployeesNeeded = employeeRequest.NoOfEmployeesNeeded,
            Business = employeeRequest.Business,
            StartDate = employeeRequest.StartDate,
            Status = employeeRequest.Status
        };
    }
}
