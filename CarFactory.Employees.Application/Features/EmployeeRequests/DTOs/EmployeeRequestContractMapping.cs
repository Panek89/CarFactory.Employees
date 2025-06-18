using CarFactory.Employees.Domain.Models;

namespace CarFactory.Employees.Application.Features.EmployeeRequests.DTOs;

public static class EmployeeRequestContractMapping
{
    public static EmployeeRequestDetailsDto MapToDto(this EmployeeRequest employeeRequest)
    {
        return new EmployeeRequestDetailsDto()
        {
            Id = employeeRequest.Id,
            NoOfEmployeesNeeded = employeeRequest.NumberOfEmployeesNeeded,
            Business = employeeRequest.Business,
            StartDate = employeeRequest.StartDate,
            Status = employeeRequest.Status,
            CandidateDetails = employeeRequest.Candidates.MapToDtos()
        };
    }

    public static IEnumerable<EmployeeRequestDetailsDto> MapToDtos(this IEnumerable<EmployeeRequest> employeeRequests)
    {
        return employeeRequests.Select(MapToDto);
    }

    public static EmployeeRequestCandidateDetailsDto MapToDto(this EmployeeRequestCandidate employeeRequestCandidate) 
    {
        return new EmployeeRequestCandidateDetailsDto()
        {
            FirstName = employeeRequestCandidate.FirstName,
            LastName = employeeRequestCandidate.LastName,
            PersonalId= employeeRequestCandidate.PersonalId,
            DateOfBirth = employeeRequestCandidate.DateOfBirth,
            Status = employeeRequestCandidate.Status,
        };
    }

    public static IEnumerable<EmployeeRequestCandidateDetailsDto> MapToDtos(this IEnumerable<EmployeeRequestCandidate> employeeRequestCandidates)
    {
        return employeeRequestCandidates.Select(MapToDto);
    }
}
