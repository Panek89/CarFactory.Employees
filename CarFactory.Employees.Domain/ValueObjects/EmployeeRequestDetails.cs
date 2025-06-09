using CarFactory.Employees.SharedLibrary.Enums;

namespace CarFactory.Employees.Domain.ValueObjects;

public class EmployeeRequestDetails
{
    public required int NumberOfEmployeesNeeded { get; init; }
    public required string Business { get; init; }
    public required DateTime StartDate { get; init; }
    public required EmployeeRequestStatus Status { get; init; }
    public required int NumberOfCandidates { get; init; }
}
