using CarFactory.Employees.SharedLibrary.Enums;

namespace CarFactory.Employees.Domain.Models;

public class EmployeeRequestCandidate : BaseEntity
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string PersonalId { get; set; }
    public required int Age { get; set; }
    public EmployeeCandidateStatus Status { get; set; }

    public Guid EmployeeRequestId { get; set; }
    public required EmployeeRequest EmployeeRequest { get; set; }
}
