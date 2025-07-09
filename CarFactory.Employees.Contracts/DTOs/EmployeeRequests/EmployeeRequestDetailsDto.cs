using CarFactory.Employees.SharedLibrary.Enums;

namespace CarFactory.Employees.Contracts.DTOs.EmployeeRequests;

public class EmployeeRequestDetailsDto
{
    public Guid Id { get; init; }
    public int NoOfEmployeesNeeded { get; init; }
    public required string Business { get; init; }
    public DateTime StartDate { get; init; }
    public EmployeeRequestStatus Status { get; init; }
    public IEnumerable<EmployeeRequestCandidateDetailsDto> CandidateDetails { get; init; } = [];
}
