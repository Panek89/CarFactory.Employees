using AutoFixture;
using CarFactory.Employees.Domain.Models;
using CarFactory.Employees.Domain.TESTS.Extensions;
using CarFactory.Employees.Domain.ValueObjects;
using CarFactory.Employees.SharedLibrary.Enums;

namespace CarFactory.Employees.Domain.TESTS.Models;

public class EmployeeRequestCandidateTests
{
    private readonly string _correctFirstName = "FirstName";
    private readonly string _correctLastName = "Surname";
    private readonly DateTime _correctDateOfBirth = DateTime.Today.AddYears(-20);
    private EmployeeRequest _employeeRequest;
    private PersonalId _personalId;

    [OneTimeSetUp]
    public void Initialize()
    {
        var fixture = new Fixture();
        _personalId = fixture.Create<PersonalId>();
        _employeeRequest = DomainTestsExtensions.EmployeeRequestRegisterCorrect();
    }


    [TestCase(null)]
    [TestCase(default)]
    public void EmployeeRequestCandidate_ShouldThrowArgumentNullException_WhenFirstNameIsNull(string? firstName)
    {
        Assert.Throws<ArgumentNullException>(() => CreateEmployeeRequestCandidate(firstName, _correctLastName, _correctDateOfBirth, _personalId, _employeeRequest));
    }

    [TestCase(null)]
    [TestCase(default)]
    public void EmployeeRequestCandidate_ShouldThrowArgumentNullException_WhenLastNameIsNull(string? lastName)
    {
        Assert.Throws<ArgumentNullException>(() => CreateEmployeeRequestCandidate(_correctFirstName, lastName, _correctDateOfBirth, _personalId, _employeeRequest));
    }

    [TestCase("A")]
    [TestCase("B")]
    public void EmployeeRequestCandidate_ShouldThrowArgumentException_WhenFirstNameIsTooShort(string firstName)
    {
        Assert.Throws<ArgumentException>(() => CreateEmployeeRequestCandidate(firstName, _correctLastName, _correctDateOfBirth, _personalId, _employeeRequest));
    }

    [TestCase("C")]
    [TestCase("D")]
    public void EmployeeRequestCandidate_ShouldThrowArgumentException_WhenLastNameIsTooShort(string lastName)
    {
        Assert.Throws<ArgumentException>(() => CreateEmployeeRequestCandidate(_correctFirstName, lastName, _correctDateOfBirth, _personalId, _employeeRequest));
    }

    [TestCase("Stefan!")]
    [TestCase("@ndrzej")]
    public void EmployeeRequestCandidate_ShouldThrowArgumentException_WhenFirstNameContainsSpecialCharacters(string firstName)
    {
        Assert.Throws<ArgumentException>(() => CreateEmployeeRequestCandidate(firstName, _correctLastName, _correctDateOfBirth, _personalId, _employeeRequest));
    }

    [TestCase("Now@k")]
    [TestCase("Duriak!*")]
    public void EmployeeRequestCandidate_ShouldThrowArgumentException_WhenLastNameContainsSpecialCharacters(string lastName)
    {
        Assert.Throws<ArgumentException>(() => CreateEmployeeRequestCandidate(_correctFirstName, lastName, _correctDateOfBirth, _personalId, _employeeRequest));
    }

    [TestCase(-17, Gender.Male)]
    [TestCase(-16, Gender.Female)]
    public void EmployeeRequestCandidate_ShouldThrowArgumentException_WhenEmployeeAgeIsBelow18_NoMatterOfGender(int yearsFromToday, Gender gender)
    {
        var dateOfBirth = DateTime.Today.AddYears(yearsFromToday);

        Assert.Throws<ArgumentException>(() => CreateEmployeeRequestCandidate(_correctFirstName, _correctLastName, dateOfBirth, _personalId, _employeeRequest, gender));
    }

    [TestCase(-61)]
    [TestCase(-65)]
    public void EmployeeRequestCandidate_ShouldThrowArgumentException_WhenEmployeeAgeIsAbove60_ForFemales(int yearsFromToday)
    {
        var dateOfBirth = DateTime.Today.AddYears(yearsFromToday);

        Assert.Throws<ArgumentException>(() => CreateEmployeeRequestCandidate(_correctFirstName, _correctLastName, dateOfBirth, _personalId, _employeeRequest, Gender.Female));
    }

    [TestCase(-66)]
    [TestCase(-70)]
    public void EmployeeRequestCandidate_ShouldThrowArgumentException_WhenEmployeeAgeIsAbove65_ForMales(int yearsFromToday)
    {
        var dateOfBirth = DateTime.Today.AddYears(yearsFromToday);

        Assert.Throws<ArgumentException>(() => CreateEmployeeRequestCandidate(_correctFirstName, _correctLastName, dateOfBirth, _personalId, _employeeRequest, Gender.Male));
    }

    [TestCase(null)]
    [TestCase(default)]
    public void EmployeeRequestCandidate_ShouldThrowArgumentException_WhenEmployeeRequestIsNull(EmployeeRequest? employeeRequest)
    {
        Assert.Throws<ArgumentException>(() => CreateEmployeeRequestCandidate(_correctFirstName, _correctLastName, _correctDateOfBirth, _personalId, employeeRequest, Gender.Male));
    }

    private void CreateEmployeeRequestCandidate(string firstName, string lastName, DateTime dateOfBirth, PersonalId personalId, EmployeeRequest employeeRequest, Gender gender = Gender.Male)
    {
        var requestCandidate = new EmployeeRequestCandidate()
        {
            Id = Guid.NewGuid(),
            FirstName = firstName,
            LastName = lastName,
            PersonalId = personalId,
            DateOfBirth = dateOfBirth,
            Gender = gender,
            Status = EmployeeCandidateStatus.Candidate,
            EmployeeRequest = employeeRequest,
            IsDeleted = false,
            CreatedBy = "TEST",
            CreatedAt = DateTime.Today
        };
    }
}
