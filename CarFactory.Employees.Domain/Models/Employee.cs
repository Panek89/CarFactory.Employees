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

    public Employee SetPersonalId(PersonalId personalId)
    {
        PersonalId = personalId;
        return this;
    }

    public Employee SetGender(Gender gender)
    {
        if (gender is Gender.NotSpecified)
        {
            throw new ArgumentException("Gender must be specified", nameof(Gender));
        }

        Gender = gender;
        return this;
    }

    public Employee SetIsEmployed(bool isEmployed)
    {
        IsEmployed = isEmployed;
        return this;
    }

    public Employee SetEmploymentStartDate(DateTime employmentStartDate)
    {
        EmploymentStartDate = employmentStartDate;
        return this;
    }

    public Employee SetEmploymentEndDate(DateTime employmentEndDate)
    {
        EmploymentEndDate = employmentEndDate;
        return this;
    }

    public static Employee Hire()
    {
        return new Employee().SetInitialMetaData();
    }
}
