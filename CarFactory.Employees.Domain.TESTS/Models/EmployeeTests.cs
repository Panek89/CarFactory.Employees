using CarFactory.Employees.Domain.Models;
using CarFactory.Employees.SharedLibrary.Enums;

namespace CarFactory.Employees.Domain.TESTS.Models;

public class EmployeeTests
{
    [Test]
    public void Employee_ShouldThrowArgumentException_WhenGender_IsNotSpecified()
    {
        var dateOfBirth = DateTime.Today.AddYears(-30);
        Assert.That(() => Employee.Hire().SetGender(Gender.NotSpecified),
            Throws.ArgumentException.With.Property(nameof(ArgumentException.ParamName)).EqualTo("Gender"));
    }
    // [TestCase(-17, Gender.Male)]
    // [TestCase(-16, Gender.Female)]
    // public void Employee_ShouldThrowArgumentException_WhenEmployeeAgeIsBelow18_NoMatterOfGender(int yearsFromToday, Gender gender)
    // {
    //     var dateOfBirth = DateTime.Today.AddYears(yearsFromToday);

    //     Assert.Throws<ArgumentException>(() => CreateEmployee(_correctFirstName, _correctLastName, _personalId, true, _correctEmploymentStartDate, null, dateOfBirth, gender));
    // }

    // [Test]
    // public void Employee_ShouldThrowArgumentException_WhenWork_LessThanTwoDays()
    // {
    //     var employmentStartDate = DateTime.Today;
    //     var employmentEndDate = DateTime.Today.AddDays(1);

    //     Assert.Throws<ArgumentException>(() => CreateEmployee(_correctFirstName, _correctLastName, _personalId, true, employmentStartDate, employmentEndDate, _correctDateOfBirth, _maleGender));
    // }

    // [Test]
    // public void Employee_ShouldThrowArgumentException_WhenEmployeed_HasEmploymentEndDate()
    // {
    //     var employmentEndDate = DateTime.Today;
    //     var isEmployed = true;

    //     Assert.Throws<ArgumentException>(() => CreateEmployee(_correctFirstName, _correctLastName, _personalId, isEmployed, _correctEmploymentStartDate, employmentEndDate, _correctDateOfBirth, _maleGender));
    // }

}
