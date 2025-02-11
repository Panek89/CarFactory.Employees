using System.ComponentModel.DataAnnotations.Schema;

namespace CarFactory.Employees.Domain;

public class Employee : BaseEntity
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public DateTime StartEmploymentDate { get; set; }

    [NotMapped]
    public string FullName => $"{FirstName} {LastName}";
    [NotMapped]
    public string FullNameReverse => $"{LastName} {FirstName}";
}
