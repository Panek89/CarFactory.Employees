namespace CarFactory.Employees.Domain.ValueObjects;

public class EmployeeDetails
{
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required PersonalId PersonalId { get; init; }
    public required DateTime DateOfBirth { get; init; }
}
