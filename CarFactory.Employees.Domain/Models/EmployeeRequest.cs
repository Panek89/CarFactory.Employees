using CarFactory.Employees.SharedLibrary.Enums;

namespace CarFactory.Employees.Domain.Models;

public class EmployeeRequest : BaseEntity
{
    public int NumberOfEmployeesNeeded { get; set; }
    public required string Business { get; set; }
    public DateTime StartDate { get; set; }
    public EmployeeRequestStatus Status { get; set; }
    public ICollection<EmployeeRequestCandidate> Candidates { get; set; } = [];
}
