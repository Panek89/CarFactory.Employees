using CarFactory.Employees.SharedLibrary.Enums;

namespace CarFactory.Employees.Application.Features.EmployeeRequests.DTOs;

public class EmployeeRequestDto
{
    public Guid Id { get; init; }
    public int NoOfEmployeesNeeded { get; init; }
    public required string Business { get; init; }
    public DateTime StartDate { get; init; }
    public EmployeeRequestStatus Status { get; init; }
}
