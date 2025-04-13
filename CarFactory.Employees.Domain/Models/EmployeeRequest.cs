using CarFactory.Employees.SharedLibrary.Enums;

namespace CarFactory.Employees.Domain.Models;

public class EmployeeRequest : BaseEntity
{
    public int NoOfEmployeesNeeded { get; set; }
    public required string Business { get; set; }
    public DateTime StartDate { get; set; }
    public EmployeeRequestStatus Status { get; set; }
    public IEnumerable<EmployeeRequestCandidate> Candidates { get; set; } = [];
}
