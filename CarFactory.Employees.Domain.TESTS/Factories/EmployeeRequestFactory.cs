using CarFactory.Employees.Domain.Models;

namespace CarFactory.Employees.Domain.TESTS.Factories;

public class EmployeeRequestFactory
{
    private static readonly int _correctNumberOfEmployeesNeeded = 5;
    private static readonly string _correctBusiness = "Business";
    private static readonly DateTime _correctStartDate = DateTime.UtcNow.AddMonths(2);

    public static EmployeeRequest Register
    (
        int? numberOfEmployeesNeeded = null,
        string? business = null,
        DateTime? startDate = null
    )
    {
        return EmployeeRequest.Register
        (
            numberOfEmployeesNeeded ?? _correctNumberOfEmployeesNeeded,
            business ?? _correctBusiness,
            startDate ?? _correctStartDate
        );
    }

    public static EmployeeRequest RegisterNullBusiness(string? business = null)
    {
        return EmployeeRequest.Register
        (
            _correctNumberOfEmployeesNeeded,
            business!,
            _correctStartDate
        );
    }
}
