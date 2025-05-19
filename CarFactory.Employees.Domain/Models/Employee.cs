using CarFactory.Employees.Domain.ExtensionMethods;
using CarFactory.Employees.Domain.ValueObjects;
using CarFactory.Employees.SharedLibrary.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarFactory.Employees.Domain.Models;

public class Employee : BaseEntity
{
    public FirstName FirstName { get; private set; } = null!;
    public LastName LastName { get; private set; } = null!;
    public PersonalId PersonalId { get; private set; } = null!;
    public DateTime DateOfBirth { get; private set; }
    public Gender Gender { get; private set; }
    public bool IsEmployed { get; private set; }
    public DateTime EmploymentStartDate { get; private set; }
    public DateTime? EmploymentEndDate { get; private set; }

    [NotMapped]
    public string FullName => $"{FirstName} {LastName}";
    [NotMapped]
    public string FullNameReverse => $"{LastName} {FirstName}";

    private Employee() {}

    public Employee SetFirstName(FirstName firstName)
    {
        FirstName = firstName;
        return this;
    }

    public Employee SetLastName(LastName lastName)
    {
        LastName = lastName;
        return this;
    }

    public static Employee Hire()
    {
        return new Employee().SetInitialMetaData();
    }
}
