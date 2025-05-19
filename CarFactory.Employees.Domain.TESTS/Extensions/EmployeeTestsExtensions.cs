using CarFactory.Employees.Domain.ValueObjects;
using CarFactory.Employees.SharedLibrary.Enums;

namespace CarFactory.Employees.Domain.TESTS.Extensions;

public static class EmployeeTestsExtensions
{
    private static readonly string _correctFirstName = "Imie";
    private static readonly string _correctLastName = "Nazwisko";
    private static readonly PersonalId _correctPersonalId = new("12345678901");
    private static readonly DateTime _correctDateOfBirth = DateTime.Today.AddYears(-20);
    private static readonly Gender _maleGender = Gender.Male;
    private static readonly DateTime _correctEmploymentStartDate = DateTime.Today.AddDays(1);

}
