using CarFactory.Employees.Domain.Models;
using CarFactory.Employees.Domain.TESTS.Factories;

namespace CarFactory.Employees.Domain.TESTS.Models;

public class EmployeeTests
{
    [TestCase(-17)]
    [TestCase(-16)]
    public void Employee_ShouldThrowArgumentException_WhenEmployeeAgeIsBelow18_ForMales(int yearsFromToday)
    {
        var dateOfBirth = DateTime.Today.AddYears(yearsFromToday);

        Assert.That(() => EmployeeFactory.HireMale(dateOfBirth: dateOfBirth),
            Throws.ArgumentException.With.Property(nameof(ArgumentException.ParamName)).EqualTo(nameof(Employee.DateOfBirth)));
    }

    [TestCase(-17)]
    [TestCase(-16)]
    public void Employee_ShouldThrowArgumentException_WhenEmployeeAgeIsBelow18_ForFemales(int yearsFromToday)
    {
        var dateOfBirth = DateTime.Today.AddYears(yearsFromToday);

        Assert.That(() => EmployeeFactory.HireFemale(dateOfBirth: dateOfBirth),
            Throws.ArgumentException.With.Property(nameof(ArgumentException.ParamName)).EqualTo(nameof(Employee.DateOfBirth)));
    }
}
