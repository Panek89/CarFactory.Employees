using CarFactory.Employees.Domain.ValueObjects;
using CarFactory.Employees.SharedLibrary.Enums;

namespace CarFactory.Employees.Domain.Models;

public class EmployeeRequestCandidate : BaseEntity
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required PersonalId PersonalId { get; set; }
    public required DateTime DateOfBirth { get; set; }
    public EmployeeCandidateStatus Status { get; set; }

    public Guid EmployeeRequestId { get; set; }
    public required EmployeeRequest EmployeeRequest { get; set; }
}
