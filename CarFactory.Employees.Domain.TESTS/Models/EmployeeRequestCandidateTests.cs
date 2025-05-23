using CarFactory.Employees.Domain.Models;
using CarFactory.Employees.Domain.TESTS.Factories;
using CarFactory.Employees.SharedLibrary.Enums;

namespace CarFactory.Employees.Domain.TESTS.Models;

public class EmployeeRequestCandidateTests
{
    [TestCase(-17, Gender.Male)]
    [TestCase(-16, Gender.Female)]
    public void EmployeeRequestCandidate_ShouldThrowArgumentException_WhenEmployeeAgeIsBelow18_NoMatterOfGender(int yearsFromToday, Gender gender)
    {
        var dateOfBirth = DateTime.Today.AddYears(yearsFromToday);

        Assert.That(() => EmployeeRequestCandidateFactory.Register(gender: gender, dateOfBirth: dateOfBirth),
            Throws.ArgumentException.With.Property(nameof(ArgumentException.ParamName)).EqualTo(nameof(EmployeeRequestCandidate.DateOfBirth)));
    }

    [TestCase(-61)]
    [TestCase(-65)]
    public void EmployeeRequestCandidate_ShouldThrowArgumentException_WhenEmployeeAgeIsAbove60_ForFemales(int yearsFromToday)
    {
        var dateOfBirth = DateTime.Today.AddYears(yearsFromToday);

        Assert.That(() => EmployeeRequestCandidateFactory.Register(gender: Gender.Female, dateOfBirth: dateOfBirth),
            Throws.ArgumentException.With.Property(nameof(ArgumentException.ParamName)).EqualTo(nameof(EmployeeRequestCandidate.DateOfBirth)));
    }

    [TestCase(-66)]
    [TestCase(-70)]
    public void EmployeeRequestCandidate_ShouldThrowArgumentException_WhenEmployeeAgeIsAbove65_ForMales(int yearsFromToday)
    {
        var dateOfBirth = DateTime.Today.AddYears(yearsFromToday);

        Assert.That(() => EmployeeRequestCandidateFactory.Register(gender: Gender.Male, dateOfBirth: dateOfBirth),
            Throws.ArgumentException.With.Property(nameof(ArgumentException.ParamName)).EqualTo(nameof(EmployeeRequestCandidate.DateOfBirth)));
    }

    [TestCase(null)]
    [TestCase(default)]
    public void EmployeeRequestCandidate_ShouldThrowArgumentException_WhenEmployeeRequestIsNull(EmployeeRequest? employeeRequest)
    {
        Assert.That(() => EmployeeRequestCandidateFactory.RegisterWithoutEmployeeRequest(employeeRequest: employeeRequest),
            Throws.ArgumentNullException.With.Property(nameof(ArgumentNullException.ParamName)).EqualTo(nameof(EmployeeRequestCandidate.EmployeeRequest)));
    }

    [Test]
    public void EmployeeRequest_ShouldThrowArgumentException_WhenGender_IsNotSpecified()
    {
        var dateOfBirth = DateTime.Today.AddYears(-30);
        Assert.That(() => EmployeeRequestCandidateFactory.Register(gender: Gender.NotSpecified),
            Throws.ArgumentException.With.Property(nameof(ArgumentException.ParamName)).EqualTo(nameof(EmployeeRequestCandidate.Gender)));
    }
}
