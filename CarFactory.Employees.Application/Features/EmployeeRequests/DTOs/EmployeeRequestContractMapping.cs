using CarFactory.Employees.Application.Features.EmployeeRequests.Commands;
using CarFactory.Employees.Domain.Models;

namespace CarFactory.Employees.Application.Features.EmployeeRequests.DTOs;

public static class EmployeeRequestContractMapping
{
    public static EmployeeRequest MapToEmployeeRequest(this RegisterEmployeeRequestCommand command)
    {
        return new EmployeeRequest()
        {
            Id = Guid.NewGuid(),
            NoOfEmployeesNeeded = command.NoOfEmployeesNeeded,
            Business = command.Business,
            StartDate = command.StartDate,
            Status = command.Status,
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

    public static IEnumerable<EmployeeRequestDto> MapToDtos(this IEnumerable<EmployeeRequest> employeeRequests)
    {
        return employeeRequests.Select(MapToDto);
    }

    public static EmployeeRequestCandidate MapToCandidate(this AssignCandidateToRequestCommand command, EmployeeRequest employeeRequest)
    {
        return new EmployeeRequestCandidate()
        {
            Id = Guid.NewGuid(),
            FirstName = command.FirstName,
            LastName = command.LastName,
            PersonalId = command.PersonalId,
            Age = command.Age,
            Status = command.Status,
            IsDeleted = false,
            CreatedAt = DateTime.UtcNow,
            CreatedBy = "SYSTEM",
            EmployeeRequest = employeeRequest
        };
    }

    public static EmployeeRequestCandidateDto MapToDto(this EmployeeRequestCandidate employeeRequestCandidate) 
    {
        return new EmployeeRequestCandidateDto()
        {
            FirstName = employeeRequestCandidate.FirstName,
            LastName = employeeRequestCandidate.LastName,
            PersonalId= employeeRequestCandidate.PersonalId,
            Age= employeeRequestCandidate.Age,
            Status = employeeRequestCandidate.Status,
        };
    }

    public static IEnumerable<EmployeeRequestCandidateDto> MapToDtos(this IEnumerable<EmployeeRequestCandidate> employeeRequestCandidates)
    {
        return employeeRequestCandidates.Select(MapToDto);
    }
}
