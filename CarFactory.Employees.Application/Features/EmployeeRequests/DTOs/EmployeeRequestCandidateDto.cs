using CarFactory.Employees.SharedLibrary.Enums;

namespace CarFactory.Employees.Application.Features.EmployeeRequests.DTOs;

public class EmployeeRequestCandidateDto
{
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required string PersonalId { get; init; }
    public required int Age { get; init; }
    public EmployeeCandidateStatus Status { get; init; }
}
