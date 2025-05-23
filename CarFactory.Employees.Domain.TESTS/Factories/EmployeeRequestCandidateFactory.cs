using CarFactory.Employees.Domain.Models;
using CarFactory.Employees.Domain.ValueObjects;
using CarFactory.Employees.SharedLibrary.Enums;

namespace CarFactory.Employees.Domain.TESTS.Factories;

public class EmployeeRequestCandidateFactory
{
    private static readonly FirstName _correctFirstName = "Imie";
    private static readonly LastName _correctLastName = "LastName";
    private static readonly PersonalId _correctPersonalId = new("12345678901");
    private static readonly DateTime _correctDateOfBirth = DateTime.Today.AddYears(-20);

    public static EmployeeRequestCandidate Register
    (
        FirstName? firstName = null,
        LastName? lastName = null,
        PersonalId? personalId = null,
        DateTime? dateOfBirth = null,
        Gender? gender = null,
        EmployeeRequest? employeeRequest = null
    )
    {
        return EmployeeRequestCandidate.Register
        (
            firstName ?? _correctFirstName,
            lastName ?? _correctLastName,
            personalId ?? _correctPersonalId,
            gender ?? Gender.Male,
            dateOfBirth ?? _correctDateOfBirth,
            employeeRequest ?? EmployeeRequestFactory.Register()
        );
    }

    public static EmployeeRequestCandidate RegisterWithoutEmployeeRequest
    (
        FirstName? firstName = null,
        LastName? lastName = null,
        PersonalId? personalId = null,
        DateTime? dateOfBirth = null,
        Gender? gender = null,
        EmployeeRequest? employeeRequest = null
    )
    {
        return EmployeeRequestCandidate.Register
        (
            firstName ?? _correctFirstName,
            lastName ?? _correctLastName,
            personalId ?? _correctPersonalId,
            gender ?? Gender.Male,
            dateOfBirth ?? _correctDateOfBirth,
            employeeRequest!
        );
    }
}
