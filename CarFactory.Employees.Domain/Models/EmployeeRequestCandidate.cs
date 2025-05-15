using CarFactory.Employees.Domain.ExtensionMethods;
using CarFactory.Employees.Domain.ValueObjects;
using CarFactory.Employees.SharedLibrary.Enums;
using CarFactory.Employees.SharedLibrary.Extensions;

namespace CarFactory.Employees.Domain.Models;

public class EmployeeRequestCandidate : BaseEntity
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public PersonalId PersonalId { get; private set; }
    public DateTime DateOfBirth { get; private set; }
    public Gender Gender { get; private set; }
    public EmployeeCandidateStatus Status { get; private set; }

    public Guid EmployeeRequestId { get; private set; }
    public EmployeeRequest EmployeeRequest { get; private set; }

    public EmployeeRequestCandidate SetFirstName(string firstName)
    {
        if (firstName == default)
        {
            throw new ArgumentNullException(nameof(FirstName), "Candidate first name must have value");
        }

        if (firstName.Length < 2)
        {
            throw new ArgumentException("Candidate first name must have at least two letters", nameof(FirstName));
        }

        if (firstName.HasNonLettersChars())
        {
            throw new ArgumentException("Candidate first name can only contains letters", nameof(FirstName));
        }

        FirstName = firstName;
        return this;
    }

    public EmployeeRequestCandidate SetLastName(string lastName)
    {
        if (lastName == default)
        {
            throw new ArgumentNullException(nameof(LastName), "Candidate last name must have value");
        }

        if (lastName.Length < 2)
        {
            throw new ArgumentException("Candidate first name must have at least two letters", nameof(LastName));
        }

        if (lastName.HasNonLettersChars())
        {
            throw new ArgumentException("Candidate first name can only contains letters", nameof(LastName));
        }

        LastName = lastName;
        return this;
    }

    public EmployeeRequestCandidate SetPersonalId(PersonalId personalId)
    {
        PersonalId = personalId;
        return this;
    }

    public EmployeeRequestCandidate SetGender(Gender gender)
    {
        if (gender is Gender.NotSpecified)
        {
            throw new ArgumentException("Gender must be specified", nameof(Gender));
        }

        Gender = gender;
        return this;
    }

    public EmployeeRequestCandidate SetDateOfBirth(DateTime dateOfBirth)
    {
        if (Gender == Gender.Male && dateOfBirth > DateTime.Today.AddYears(-18))
        {
            throw new ArgumentException("Minimum age for male candidates is 18 years", nameof(DateOfBirth));
        }

        if (Gender == Gender.Male && dateOfBirth < DateTime.Today.AddYears(-65))
        {
            throw new ArgumentException("Maximum age for male candidates is 65 years", nameof(DateOfBirth));
        }

        if (Gender == Gender.Female && dateOfBirth > DateTime.Today.AddYears(-18))
        {
            throw new ArgumentException("Minimum age for female candidates is 18 years", nameof(DateOfBirth));
        }

        if (Gender == Gender.Female && dateOfBirth < DateTime.Today.AddYears(-60))
        {
            throw new ArgumentException("Maximum age for female candidates is 60 years", nameof(DateOfBirth));
        }

        DateOfBirth = dateOfBirth;
        return this;
    }

    public EmployeeRequestCandidate SetStatus(EmployeeCandidateStatus status)
    {
        if (status != EmployeeCandidateStatus.Candidate)
        {
            throw new ArgumentException($"New candidate cannot have another status that candidate {EmployeeCandidateStatus.Candidate}", nameof(Status));
        }

        Status = status;
        return this;
    }

    public EmployeeRequestCandidate SetEmployeeRequest(EmployeeRequest employeeRequest)
    {
        if (employeeRequest is null)
        {
            throw new ArgumentNullException(nameof(EmployeeRequest), "Request must have a value");
        }

        EmployeeRequestId = employeeRequest.Id;
        EmployeeRequest = employeeRequest;
        return this;
    }

    public static EmployeeRequestCandidate RegisterCandidate(string firstName, string lastName, PersonalId personalId, Gender gender, DateTime dateOfBirth, EmployeeRequest employeeRequest)
    {
        return new EmployeeRequestCandidate()
            .SetInitialMetaData()
            .SetFirstName(firstName)
            .SetLastName(lastName)
            .SetPersonalId(personalId)
            .SetGender(gender)
            .SetDateOfBirth(dateOfBirth)
            .SetStatus(EmployeeCandidateStatus.Candidate)
            .SetEmployeeRequest(employeeRequest);
    }
}
