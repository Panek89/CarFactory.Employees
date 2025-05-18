using CarFactory.Employees.Domain.Models;
using CarFactory.Employees.Domain.TESTS.Extensions;

namespace CarFactory.Employees.Domain.TESTS.Models;

public class EmployeeTests
{
    [TestCase(null)]
    [TestCase(default)]
    public void Employee_ShouldThrowArgumentNullException_WhenFirstNameIsNull(string? firstName)
    {
        Assert.That(() => EmployeeTestsExtensions.CorrectHire().SetFirstName(firstName!),
            Throws.ArgumentNullException.With.Property(nameof(ArgumentNullException.ParamName)).EqualTo(nameof(Employee.FirstName)));
    }

    // [TestCase(null)]
    // [TestCase(default)]
    // public void Employee_ShouldThrowArgumentNullException_WhenLastNameIsNull(string? lastName)
    // {
    //     Assert.Throws<ArgumentNullException>(() => CreateEmployee(_correctFirstName, lastName!, _personalId, true, _correctEmploymentStartDate, null, _correctDateOfBirth, _maleGender));
    // }

    // [TestCase("A")]
    // [TestCase("B")]
    // public void Employee_ShouldThrowArgumentException_WhenFirstNameIsTooShort(string firstName)
    // {
    //     Assert.Throws<ArgumentException>(() => CreateEmployee(firstName, _correctLastName, _personalId, true, _correctEmploymentStartDate, null, _correctDateOfBirth, _maleGender));
    // }

    // [TestCase("C")]
    // [TestCase("D")]
    // public void Employee_ShouldThrowArgumentException_WhenLastNameIsTooShort(string lastName)
    // {
    //     Assert.Throws<ArgumentException>(() => CreateEmployee(_correctFirstName, lastName, _personalId, true, _correctEmploymentStartDate, null, _correctDateOfBirth, _maleGender));
    // }

    // [TestCase("Stefan!")]
    // [TestCase("@ndrzej")]
    // public void Employee_ShouldThrowArgumentException_WhenFirstNameContainsSpecialCharacters(string firstName)
    // {
    //     Assert.Throws<ArgumentException>(() => CreateEmployee(firstName, _correctLastName, _personalId, true, _correctEmploymentStartDate, null, _correctDateOfBirth, _maleGender));
    // }

    // [TestCase("Now@k")]
    // [TestCase("Duriak!*")]
    // public void Employee_ShouldThrowArgumentException_WhenLastNameContainsSpecialCharacters(string lastName)
    // {
    //     Assert.Throws<ArgumentException>(() => CreateEmployee(_correctFirstName, lastName, _personalId, true, _correctEmploymentStartDate, null, _correctDateOfBirth, _maleGender));
    // }

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
