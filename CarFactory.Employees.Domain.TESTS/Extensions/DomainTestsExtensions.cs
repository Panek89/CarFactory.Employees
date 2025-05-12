using CarFactory.Employees.Domain.Models;

namespace CarFactory.Employees.Domain.TESTS.Extensions;

public static class DomainTestsExtensions
{
    private static readonly int _correctNumberOfEmployeesNeeded = 5;
    private static readonly string _correctBusiness = "Business";
    private static readonly DateTime _correctStartDate = DateTime.UtcNow.AddMonths(2);

    public static EmployeeRequest EmployeeRequestRegisterCorrect()
    {
        return EmployeeRequest.Register(_correctNumberOfEmployeesNeeded, _correctBusiness, _correctStartDate);
    }
}
