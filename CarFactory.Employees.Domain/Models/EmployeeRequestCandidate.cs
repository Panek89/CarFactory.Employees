using CarFactory.Employees.SharedLibrary.Enums;

namespace CarFactory.Employees.Domain.Models;

public class EmployeeRequestCandidate
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string PersonalId { get; set; }
    public required int Age { get; set; }
    public EmployeeCandidateStatus Status { get; set; }
}
