using CarFactory.Employees.Domain.Common;
using CarFactory.Employees.Domain.ExtensionMethods;
using CarFactory.Employees.Domain.ValueObjects;
using CarFactory.Employees.SharedLibrary.Enums;

namespace CarFactory.Employees.Domain.Models;

public class EmployeeRequestCandidate : BaseEntity
{
    private Gender _gender;
    private DateTime _dateOfBirth;
    private EmployeeCandidateStatus _status;

    public FirstName FirstName { get; private set; } = null!;
    public LastName LastName { get; private set; } = null!;
    public PersonalId PersonalId { get; private set; } = null!;
    public Gender Gender
    {
        get => _gender;
        private set
        {
            if (value is Gender.NotSpecified)
            {
                throw new ArgumentException("Gender must be specified", nameof(Gender));
            }

            _gender = value;
        }
    }
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
    public EmployeeCandidateStatus Status
    {
        get => _status;
        private set
        {
            if (value != EmployeeCandidateStatus.Candidate)
            {
                throw new ArgumentException($"New candidate cannot have another status that candidate {EmployeeCandidateStatus.Candidate}", nameof(Status));
            }

            _status = value;
        }
    }

    private EmployeeRequestCandidate() { }

    private EmployeeRequestCandidate
    (
        FirstName firstName,
        LastName lastName,
        PersonalId personalId,
        Gender gender,
        DateTime dateOfBirth,
        EmployeeCandidateStatus status
    )
    {
        FirstName = firstName;
        LastName = lastName;
        PersonalId = personalId;
        Gender = gender;
        DateOfBirth = dateOfBirth;
        Status = status;
    }

    public static EmployeeRequestCandidate Register
    (
        string firstName,
        string lastName,
        PersonalId personalId,
        Gender gender,
        DateTime dateOfBirth
    )
    {
        return new EmployeeRequestCandidate
        (
            firstName,
            lastName,
            personalId,
            gender,
            dateOfBirth,
            EmployeeCandidateStatus.Candidate
        ).SetInitialMetaData();
    }
}
