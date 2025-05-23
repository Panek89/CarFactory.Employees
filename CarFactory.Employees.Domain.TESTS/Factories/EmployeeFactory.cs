using CarFactory.Employees.Domain.Models;
using CarFactory.Employees.Domain.ValueObjects;

namespace CarFactory.Employees.Domain.TESTS.Factories;

public class EmployeeFactory
{
    private static readonly FirstName _correctFirstName = "Imie";
    private static readonly LastName _correctLastName = "Nazwisko";
    private static readonly PersonalId _correctPersonalId = new("12345678901");
    private static readonly DateTime _correctDateOfBirth = DateTime.Today.AddYears(-20);
    private static readonly DateTime _correctEmploymentStartDate = DateTime.Today.AddDays(1);

    public static Employee HireMale(
        FirstName? firstName = null,
        LastName? lastName = null,
        PersonalId? personalId = null,
        DateTime? dateOfBirth = null,
        DateTime? employmentStartDate = null
        )
    {
        return Employee.HireMale
        (
            firstName ?? _correctFirstName,
            lastName ?? _correctLastName,
            personalId ?? _correctPersonalId,
            dateOfBirth ?? _correctDateOfBirth,
            employmentStartDate ?? _correctEmploymentStartDate
        );
    }

    public static Employee HireFemale(
        FirstName? firstName = null,
        LastName? lastName = null,
        PersonalId? personalId = null,
        DateTime? dateOfBirth = null,
        DateTime? employmentStartDate = null
        )
    {
        return Employee.HireFemale
        (
            firstName ?? _correctFirstName,
            lastName ?? _correctLastName,
            personalId ?? _correctPersonalId,
            dateOfBirth ?? _correctDateOfBirth,
            employmentStartDate ?? _correctEmploymentStartDate
        );
    }
}
