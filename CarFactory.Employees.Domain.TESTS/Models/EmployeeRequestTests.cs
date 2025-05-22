using CarFactory.Employees.Domain.Models;
using CarFactory.Employees.Domain.TESTS.Factories;

namespace CarFactory.Employees.Domain.TESTS.Models;

public class EmployeeRequestTests
{

    [TestCase(0)]
    [TestCase(-1)]
    public void EmployeeRequest_ShouldThrowArgumentException_WhenNumberOfEmployeesNeeded_IsBelowOne(int numberOfEmployeesNeeded)
    {
        Assert.That(() => EmployeeRequestFactory.Register(numberOfEmployeesNeeded),
            Throws.ArgumentException.With.Property(nameof(ArgumentException.ParamName)).EqualTo(nameof(EmployeeRequest.NumberOfEmployeesNeeded)));
    }

    [TestCase(11)]
    [TestCase(12)]
    [TestCase(21)]
    public void EmployeeRequest_ShouldThrowArgumentException_WhenNumberOfEmployeesNeeded_IsAboveTen(int numberOfEmployeesNeeded)
    {
        Assert.That(() => EmployeeRequestFactory.Register(numberOfEmployeesNeeded),
            Throws.ArgumentException.With.Property(nameof(ArgumentException.ParamName)).EqualTo(nameof(EmployeeRequest.NumberOfEmployeesNeeded)));
    }

    [TestCase(null)]
    [TestCase(default)]
    [TestCase("")]
    public void EmployeeRequest_ShouldThrowArgumentNullException_WhenBusiness_IsNull(string? business)
    {
        Assert.That(() => EmployeeRequestFactory.RegisterNullBusiness(business: business),
            Throws.ArgumentNullException.With.Property(nameof(ArgumentNullException.ParamName)).EqualTo(nameof(EmployeeRequest.Business)));
    }

    [Test]
    public void EmployeeRequest_ShouldThrowArgumentException_WhenStartDate_IsInThePast()
    {
        Assert.That(() => EmployeeRequestFactory.Register(startDate: DateTime.Today.AddDays(-1)),
            Throws.ArgumentException.With.Property(nameof(ArgumentException.ParamName)).EqualTo(nameof(EmployeeRequest.StartDate)));
    }

    [Test]
    public void EmployeeRequest_ShouldThrowArgumentException_WhenStartDate_IsLessThanOneMonthInFuture()
    {
        Assert.That(() => EmployeeRequestFactory.Register(startDate:DateTime.Today.AddMonths(1).AddDays(-1)),
               Throws.ArgumentException.With.Property(nameof(ArgumentException.ParamName)).EqualTo(nameof(EmployeeRequest.StartDate)));
    }
}
