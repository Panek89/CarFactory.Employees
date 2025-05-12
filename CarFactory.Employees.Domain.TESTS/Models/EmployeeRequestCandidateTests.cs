using CarFactory.Employees.Domain.Models;
using CarFactory.Employees.Domain.TESTS.Extensions;
using CarFactory.Employees.SharedLibrary.Enums;

namespace CarFactory.Employees.Domain.TESTS.Models;

public class EmployeeRequestCandidateTests
{
    [TestCase(null)]
    [TestCase(default)]
    public void EmployeeRequestCandidate_ShouldThrowArgumentNullException_WhenFirstNameIsNull(string? firstName)
    {
        Assert.That(() => DomainTestsExtensions.EmployeeRequestCandidateRegisterCorrect().SetFirstName(firstName),
            Throws.ArgumentNullException.With.Property(nameof(ArgumentNullException.ParamName)).EqualTo("FirstName"));
    }

    [TestCase(null)]
    [TestCase(default)]
    public void EmployeeRequestCandidate_ShouldThrowArgumentNullException_WhenLastNameIsNull(string? lastName)
    {
        Assert.That(() => DomainTestsExtensions.EmployeeRequestCandidateRegisterCorrect().SetLastName(lastName),
            Throws.ArgumentNullException.With.Property(nameof(ArgumentNullException.ParamName)).EqualTo("LastName"));
    }

    [TestCase("A")]
    [TestCase("B")]
    public void EmployeeRequestCandidate_ShouldThrowArgumentException_WhenFirstNameIsTooShort(string firstName)
    {
        Assert.That(() => DomainTestsExtensions.EmployeeRequestCandidateRegisterCorrect().SetFirstName(firstName),
            Throws.ArgumentException.With.Property(nameof(ArgumentException.ParamName)).EqualTo("FirstName"));
    }

    [TestCase("C")]
    [TestCase("D")]
    public void EmployeeRequestCandidate_ShouldThrowArgumentException_WhenLastNameIsTooShort(string lastName)
    {
        Assert.That(() => DomainTestsExtensions.EmployeeRequestCandidateRegisterCorrect().SetLastName(lastName),
            Throws.ArgumentException.With.Property(nameof(ArgumentException.ParamName)).EqualTo("LastName"));
    }

    [TestCase("Stefan!")]
    [TestCase("@ndrzej")]
    public void EmployeeRequestCandidate_ShouldThrowArgumentException_WhenFirstNameContainsSpecialCharacters(string firstName)
    {
        Assert.That(() => DomainTestsExtensions.EmployeeRequestCandidateRegisterCorrect().SetFirstName(firstName),
            Throws.ArgumentException.With.Property(nameof(ArgumentException.ParamName)).EqualTo("FirstName"));
    }

    [TestCase("Now@k")]
    [TestCase("Duriak!*")]
    public void EmployeeRequestCandidate_ShouldThrowArgumentException_WhenLastNameContainsSpecialCharacters(string lastName)
    {
        Assert.That(() => DomainTestsExtensions.EmployeeRequestCandidateRegisterCorrect().SetLastName(lastName),
            Throws.ArgumentException.With.Property(nameof(ArgumentException.ParamName)).EqualTo("LastName"));
    }

    [TestCase(-17, Gender.Male)]
    [TestCase(-16, Gender.Female)]
    public void EmployeeRequestCandidate_ShouldThrowArgumentException_WhenEmployeeAgeIsBelow18_NoMatterOfGender(int yearsFromToday, Gender gender)
    {
        var dateOfBirth = DateTime.Today.AddYears(yearsFromToday);

        Assert.That(() => DomainTestsExtensions.EmployeeRequestCandidateRegisterCorrect().SetDateOfBirth(dateOfBirth).SetGender(gender),
            Throws.ArgumentException.With.Property(nameof(ArgumentException.ParamName)).EqualTo("DateOfBirth"));
    }

    [TestCase(-61)]
    [TestCase(-65)]
    public void EmployeeRequestCandidate_ShouldThrowArgumentException_WhenEmployeeAgeIsAbove60_ForFemales(int yearsFromToday)
    {
        var dateOfBirth = DateTime.Today.AddYears(yearsFromToday);

        Assert.That(() => DomainTestsExtensions.EmployeeRequestCandidateRegisterCorrect().SetGender(Gender.Female).SetDateOfBirth(dateOfBirth),
            Throws.ArgumentException.With.Property(nameof(ArgumentException.ParamName)).EqualTo("DateOfBirth"));
    }

    [TestCase(-66)]
    [TestCase(-70)]
    public void EmployeeRequestCandidate_ShouldThrowArgumentException_WhenEmployeeAgeIsAbove65_ForMales(int yearsFromToday)
    {
        var dateOfBirth = DateTime.Today.AddYears(yearsFromToday);

        Assert.That(() => DomainTestsExtensions.EmployeeRequestCandidateRegisterCorrect().SetGender(Gender.Male).SetDateOfBirth(dateOfBirth),
            Throws.ArgumentException.With.Property(nameof(ArgumentException.ParamName)).EqualTo("DateOfBirth"));
    }

    [TestCase(null)]
    [TestCase(default)]
    public void EmployeeRequestCandidate_ShouldThrowArgumentException_WhenEmployeeRequestIsNull(EmployeeRequest? employeeRequest)
    {
        Assert.That(() => DomainTestsExtensions.EmployeeRequestCandidateRegisterCorrect().SetEmployeeRequest(employeeRequest),
            Throws.ArgumentNullException.With.Property(nameof(ArgumentNullException.ParamName)).EqualTo("EmployeeRequest"));
    }

    [TestCase(EmployeeCandidateStatus.Accepted)]
    [TestCase(EmployeeCandidateStatus.Rejected)]
    [TestCase(EmployeeCandidateStatus.Withdrawn)]
    public void EmployeeRequest_ShouldThrowArgumentException_WhenStatusOnRegister_IsIncorrect(EmployeeCandidateStatus status)
    {
        Assert.That(() => DomainTestsExtensions.EmployeeRequestCandidateRegisterCorrect().SetStatus(status),
                Throws.ArgumentException.With.Property(nameof(ArgumentException.ParamName)).EqualTo("Status"));
    }
}
