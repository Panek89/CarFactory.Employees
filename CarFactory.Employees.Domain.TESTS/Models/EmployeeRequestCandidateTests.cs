using AutoFixture;
using CarFactory.Employees.Domain.Models;
using CarFactory.Employees.Domain.ValueObjects;
using CarFactory.Employees.SharedLibrary.Enums;
using System.Reflection;

namespace CarFactory.Employees.Domain.TESTS.Models;

public class EmployeeRequestCandidateTests
{
    private readonly string _correctFirstName = "FirstName";
    private readonly string _correctLastName = "Surname";
    private readonly DateTime _correctDateOfBirth = DateTime.Today.AddYears(-20);
    private readonly DateTime _aaa = DateTime.Today.AddYears(-16);
    private EmployeeRequest _employeeRequest;

    [OneTimeSetUp]
    public void Initialize()
    {
        _employeeRequest = CreateEmployeeRequest();
    }


    [TestCase(null)]
    [TestCase(default)]
    public void EmployeeRequestCandidate_ShouldThrowArgumentNullException_WhenFirstNameIsNull(string? firstName)
    {
        var fixture = new Fixture();
        var personalId = fixture.Create<PersonalId>();

        Assert.Throws<ArgumentNullException>(() => CreateEmployeeRequestCandidate(firstName, _correctLastName, _correctDateOfBirth, personalId, _employeeRequest));
    }

    [TestCase(null)]
    [TestCase(default)]
    public void EmployeeRequestCandidate_ShouldThrowArgumentNullException_WhenLastNameIsNull(string? lastName)
    {
        var fixture = new Fixture();
        var personalId = fixture.Create<PersonalId>();

        Assert.Throws<ArgumentNullException>(() => CreateEmployeeRequestCandidate(_correctFirstName, lastName, _correctDateOfBirth, personalId, _employeeRequest));
    }

    [TestCase("A")]
    [TestCase("B")]
    public void EmployeeRequestCandidate_ShouldThrowArgumentException_WhenFirstNameIsTooShort(string firstName)
    {
        var fixture = new Fixture();
        var personalId = fixture.Create<PersonalId>();

        Assert.Throws<ArgumentException>(() => CreateEmployeeRequestCandidate(firstName, _correctLastName, _correctDateOfBirth, personalId, _employeeRequest));
    }

    [TestCase("C")]
    [TestCase("D")]
    public void EmployeeRequestCandidate_ShouldThrowArgumentException_WhenLastNameIsTooShort(string lastName)
    {
        var fixture = new Fixture();
        var personalId = fixture.Create<PersonalId>();

        Assert.Throws<ArgumentException>(() => CreateEmployeeRequestCandidate(_correctFirstName, lastName, _correctDateOfBirth, personalId, _employeeRequest));
    }

    [TestCase("Stefan!")]
    [TestCase("@ndrzej")]
    public void EmployeeRequestCandidate_ShouldThrowArgumentException_WhenFirstNameContainsSpecialCharacters(string firstName)
    {
        var fixture = new Fixture();
        var personalId = fixture.Create<PersonalId>();

        Assert.Throws<ArgumentException>(() => CreateEmployeeRequestCandidate(firstName, _correctLastName, _correctDateOfBirth, personalId, _employeeRequest));
    }

    [TestCase("Now@k")]
    [TestCase("Duriak!*")]
    public void EmployeeRequestCandidate_ShouldThrowArgumentException_WhenLastNameContainsSpecialCharacters(string lastName)
    {
        var fixture = new Fixture();
        var personalId = fixture.Create<PersonalId>();

        Assert.Throws<ArgumentException>(() => CreateEmployeeRequestCandidate(_correctFirstName, lastName, _correctDateOfBirth, personalId, _employeeRequest));
    }

    [TestCase(-17, Gender.Male)]
    [TestCase(-16, Gender.Female)]
    public void EmployeeRequestCandidate_ShouldThrowArgumentException_WhenEmployeeAgeIsBelow18_NoMatterOfGender(int yearsFromToday, Gender gender)
    {
        var fixture = new Fixture();
        var personalId = fixture.Create<PersonalId>();
        var dateOfBirth = DateTime.Today.AddYears(yearsFromToday);

        Assert.Throws<ArgumentException>(() => CreateEmployeeRequestCandidate(_correctFirstName, _correctLastName, dateOfBirth, personalId, _employeeRequest, gender));
    }

    [TestCase(-61)]
    [TestCase(-65)]
    public void EmployeeRequestCandidate_ShouldThrowArgumentException_WhenEmployeeAgeIsAbove60_ForFemales(int yearsFromToday)
    {
        var fixture = new Fixture();
        var personalId = fixture.Create<PersonalId>();
        var dateOfBirth = DateTime.Today.AddYears(yearsFromToday);

        Assert.Throws<ArgumentException>(() => CreateEmployeeRequestCandidate(_correctFirstName, _correctLastName, dateOfBirth, personalId, _employeeRequest, Gender.Female));
    }

    [TestCase(-66)]
    [TestCase(-70)]
    public void EmployeeRequestCandidate_ShouldThrowArgumentException_WhenEmployeeAgeIsAbove65_ForMales(int yearsFromToday)
    {
        var fixture = new Fixture();
        var personalId = fixture.Create<PersonalId>();
        var dateOfBirth = DateTime.Today.AddYears(yearsFromToday);

        Assert.Throws<ArgumentException>(() => CreateEmployeeRequestCandidate(_correctFirstName, _correctLastName, dateOfBirth, personalId, _employeeRequest, Gender.Male));
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

    private EmployeeRequest CreateEmployeeRequest()
    {
        return new EmployeeRequest()
        {
            Id = Guid.NewGuid(),
            Business = "Business",
            Candidates = [],
            CreatedBy = "TEST",
            CreatedAt = DateTime.Today,
            NumberOfEmployeesNeeded = 5,
            StartDate = DateTime.Today.AddMonths(2),
            Status = EmployeeRequestStatus.Registered,
            IsDeleted = false
        };
    }
}
