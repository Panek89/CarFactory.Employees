using CarFactory.Employees.Domain.Common;
using CarFactory.Employees.Domain.ExtensionMethods;
using CarFactory.Employees.Domain.ValueObjects;
using CarFactory.Employees.SharedLibrary.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarFactory.Employees.Domain.Models;

public class Employee : BaseEntity
{
    private DateTime _dateOfBirth;

    public FirstName FirstName { get; private set; } = null!;
    public LastName LastName { get; private set; } = null!;
    public PersonalId PersonalId { get; private set; } = null!;
    public Gender Gender { get; private set; }
    public DateTime DateOfBirth
    {
        get => _dateOfBirth;
        private set
        {
            if (Gender == Gender.Male && value > DateTime.Today.AddYears(-18))
            {
                throw new ArgumentException("Minimum age for male candidates is 18 years", nameof(DateOfBirth));
            }

            if (Gender == Gender.Male && value < DateTime.Today.AddYears(-65))
            {
                throw new ArgumentException("Maximum age for male candidates is 65 years", nameof(DateOfBirth));
            }

            if (Gender == Gender.Female && value > DateTime.Today.AddYears(-18))
            {
                throw new ArgumentException("Minimum age for female candidates is 18 years", nameof(DateOfBirth));
            }

            if (Gender == Gender.Female && value < DateTime.Today.AddYears(-60))
            {
                throw new ArgumentException("Maximum age for female candidates is 60 years", nameof(DateOfBirth));
            }

            _dateOfBirth = value;
        }
    }
    public bool IsEmployed { get; private set; }
    public DateTime EmploymentStartDate { get; private set; }
    public DateTime? EmploymentEndDate { get; private set; }

    [NotMapped]
    public string FullName => $"{FirstName} {LastName}";
    [NotMapped]
    public string FullNameReverse => $"{LastName} {FirstName}";

    private Employee() { }

    private Employee
    (
        FirstName firstName,
        LastName lastName,
        PersonalId personalId,
        Gender gender,
        DateTime dateOfBirth,
        bool isEmployed,
        DateTime employmentStartDate,
        DateTime? employmentEndDate
    )
    {
        FirstName = firstName;
        LastName = lastName;
        PersonalId = personalId;
        Gender = gender;
        DateOfBirth = dateOfBirth;
        IsEmployed = isEmployed;
        EmploymentStartDate = employmentStartDate;
        EmploymentEndDate = employmentEndDate;
    }

    public static Employee HireMale
    (
        FirstName firstName,
        LastName lastName,
        PersonalId personalId,
        DateTime dateOfBirth,
        DateTime employmentStartDate
    )
    {
        return new Employee
        (
            firstName,
            lastName,
            personalId,
            Gender.Male,
            dateOfBirth,
            true,
            employmentStartDate,
            null
        ).SetInitialMetaData();
    }

    public static Employee HireFemale
    (
        FirstName firstName,
        LastName lastName,
        PersonalId personalId,
        DateTime dateOfBirth,
        DateTime employmentStartDate
    )
    {
        return new Employee
        (
            firstName,
            lastName,
            personalId,
            Gender.Female,
            dateOfBirth,
            true,
            employmentStartDate,
            null
        ).SetInitialMetaData();
    }
}
