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

    internal Employee() {}

    internal Employee SetFirstName(FirstName firstName)
    {
        FirstName = firstName;
        return this;
    }

    internal Employee SetLastName(LastName lastName)
    {
        LastName = lastName;
        return this;
    }

    internal Employee SetPersonalId(PersonalId personalId)
    {
        PersonalId = personalId;
        return this;
    }

    internal Employee SetGender(Gender gender)
    {
        if (gender is Gender.NotSpecified)
        {
            throw new ArgumentException("Gender must be specified", nameof(Gender));
        }

        Gender = gender;
        return this;
    }

    internal Employee SetIsEmployed(bool isEmployed)
    {
        IsEmployed = isEmployed;
        return this;
    }

    internal Employee SetEmploymentStartDate(DateTime employmentStartDate)
    {
        EmploymentStartDate = employmentStartDate;
        return this;
    }

    internal Employee SetEmploymentEndDate(DateTime employmentEndDate)
    {
        EmploymentEndDate = employmentEndDate;
        return this;
    }
}
