using CarFactory.Employees.Domain.ExtensionMethods;
using CarFactory.Employees.Domain.ValueObjects;
using CarFactory.Employees.SharedLibrary.Enums;

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
        FirstName = firstName;
        return this;
    }

    public EmployeeRequestCandidate SetLastName(string lastName)
    {
        LastName = lastName;
        return this;
    }

    public EmployeeRequestCandidate SetPersonalId(PersonalId personalId)
    {
        PersonalId = personalId;
        return this;
    }

    public EmployeeRequestCandidate SetDateOfBirth(DateTime dateOfBirth)
    {
        DateOfBirth = dateOfBirth;
        return this;
    }

    public EmployeeRequestCandidate SetGender(Gender gender)
    {
        Gender = gender;
        return this;
    }

    public EmployeeRequestCandidate SetEmployeeRequest(EmployeeRequest employeeRequest)
    {
        EmployeeRequestId = employeeRequest.Id;
        EmployeeRequest = employeeRequest;
        return this;
    }

    public static EmployeeRequestCandidate RegisterCandidate(string firstName, string lastName, PersonalId personalId, DateTime dateOfBirth, Gender gender, EmployeeRequest employeeRequest)
    {
        return new EmployeeRequestCandidate()
            .SetInitialMetaData()
            .SetFirstName(firstName)
            .SetLastName(lastName)
            .SetPersonalId(personalId)
            .SetDateOfBirth(dateOfBirth)
            .SetGender(gender)
            .SetEmployeeRequest(employeeRequest);
    }
}
