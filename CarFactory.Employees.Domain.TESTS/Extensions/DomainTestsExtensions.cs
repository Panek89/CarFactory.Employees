using CarFactory.Employees.Domain.Models;
using CarFactory.Employees.Domain.ValueObjects;
using CarFactory.Employees.SharedLibrary.Enums;

namespace CarFactory.Employees.Domain.TESTS.Extensions;

public static class DomainTestsExtensions
{
    private static readonly int _correctNumberOfEmployeesNeeded = 5;
    private static readonly string _correctBusiness = "Business";
    private static readonly DateTime _correctStartDate = DateTime.UtcNow.AddMonths(2);

    private static readonly string _correctFirstName = "Imie";
    private static readonly string _correctLastName = "LastName";
    private static readonly PersonalId _correctPersonalId = new("12345678901");
    private static readonly DateTime _correctDateOfBirth = DateTime.Today.AddYears(-20);
    private static readonly Gender _maleGender = Gender.Male;

    public static EmployeeRequest EmployeeRequestRegisterCorrect()
    {
        return EmployeeRequest.Register(_correctNumberOfEmployeesNeeded, _correctBusiness, _correctStartDate);
    }

    public static EmployeeRequestCandidate EmployeeRequestCandidateRegisterCorrect()
    {
        return EmployeeRequestCandidate.RegisterCandidate(_correctFirstName, _correctLastName, _correctPersonalId, _maleGender, _correctDateOfBirth, EmployeeRequestRegisterCorrect());
    }
}
