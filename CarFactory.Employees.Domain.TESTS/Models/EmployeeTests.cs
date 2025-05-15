using CarFactory.Employees.Domain.Models;
using CarFactory.Employees.Domain.ValueObjects;
using CarFactory.Employees.SharedLibrary.Enums;

namespace CarFactory.Employees.Domain.TESTS.Models;

public class EmployeeTests
{
    private readonly string _correctFirstName = "FirstName";
    private readonly string _correctLastName = "Surname";
    private readonly DateTime _correctDateOfBirth = DateTime.Today.AddYears(-20);
    private readonly DateTime _correctEmploymentStartDate = DateTime.Today.AddMonths(-5);
    private readonly Gender _maleGender = Gender.Male;
    private readonly string _correctPersonalId = "12345678901";
    private PersonalId _personalId;

    [OneTimeSetUp]
    public void Initialize()
    {
        _personalId = CreatePersonalId(_correctPersonalId);
    }

    [TestCase(null)]
    [TestCase(default)]
    public void Employee_ShouldThrowArgumentNullException_WhenFirstNameIsNull(string? firstName)
    {
        Assert.Throws<ArgumentNullException>(() => CreateEmployee(firstName!, _correctLastName, _personalId, true, _correctEmploymentStartDate, null, _correctDateOfBirth, _maleGender));
    }

    [TestCase(null)]
    [TestCase(default)]
    public void Employee_ShouldThrowArgumentNullException_WhenLastNameIsNull(string? lastName)
    {
        Assert.Throws<ArgumentNullException>(() => CreateEmployee(_correctFirstName, lastName!, _personalId, true, _correctEmploymentStartDate, null, _correctDateOfBirth, _maleGender));
    }

    [TestCase("A")]
    [TestCase("B")]
    public void Employee_ShouldThrowArgumentException_WhenFirstNameIsTooShort(string firstName)
    {
        Assert.Throws<ArgumentException>(() => CreateEmployee(firstName, _correctLastName, _personalId, true, _correctEmploymentStartDate, null, _correctDateOfBirth, _maleGender));
    }

    [TestCase("C")]
    [TestCase("D")]
    public void Employee_ShouldThrowArgumentException_WhenLastNameIsTooShort(string lastName)
    {
        Assert.Throws<ArgumentException>(() => CreateEmployee(_correctFirstName, lastName, _personalId, true, _correctEmploymentStartDate, null, _correctDateOfBirth, _maleGender));
    }

    [TestCase("Stefan!")]
    [TestCase("@ndrzej")]
    public void Employee_ShouldThrowArgumentException_WhenFirstNameContainsSpecialCharacters(string firstName)
    {
        Assert.Throws<ArgumentException>(() => CreateEmployee(firstName, _correctLastName, _personalId, true, _correctEmploymentStartDate, null, _correctDateOfBirth, _maleGender));
    }

    [TestCase("Now@k")]
    [TestCase("Duriak!*")]
    public void Employee_ShouldThrowArgumentException_WhenLastNameContainsSpecialCharacters(string lastName)
    {
        Assert.Throws<ArgumentException>(() => CreateEmployee(_correctFirstName, lastName, _personalId, true, _correctEmploymentStartDate, null, _correctDateOfBirth, _maleGender));
    }

    [TestCase(-17, Gender.Male)]
    [TestCase(-16, Gender.Female)]
    public void Employee_ShouldThrowArgumentException_WhenEmployeeAgeIsBelow18_NoMatterOfGender(int yearsFromToday, Gender gender)
    {
        var dateOfBirth = DateTime.Today.AddYears(yearsFromToday);

        Assert.Throws<ArgumentException>(() => CreateEmployee(_correctFirstName, _correctLastName, _personalId, true, _correctEmploymentStartDate, null, dateOfBirth, gender));
    }

    [Test]
    public void Employee_ShouldThrowArgumentException_WhenWork_LessThanTwoDays()
    {
        var employmentStartDate = DateTime.Today;
        var employmentEndDate = DateTime.Today.AddDays(1);

        Assert.Throws<ArgumentException>(() => CreateEmployee(_correctFirstName, _correctLastName, _personalId, true, employmentStartDate, employmentEndDate, _correctDateOfBirth, _maleGender));
    }

    [Test]
    public void Employee_ShouldThrowArgumentException_WhenEmployeed_HasEmploymentEndDate()
    {
        var employmentEndDate = DateTime.Today;
        var isEmployed = true;

        Assert.Throws<ArgumentException>(() => CreateEmployee(_correctFirstName, _correctLastName, _personalId, isEmployed, _correctEmploymentStartDate, employmentEndDate, _correctDateOfBirth, _maleGender));
    }

    private PersonalId CreatePersonalId(string personalId)
    {
        return new PersonalId(personalId);
    }

    private Employee CreateEmployee(string firstName, string lastName, PersonalId personalId, bool isEmployeed, DateTime employmentStartDate, DateTime? employmentEndDate, DateTime dateOfBirth, Gender gender)
    {
        return new Employee()
        {
            Id = Guid.NewGuid(),
            FirstName = firstName,
            LastName = lastName,
            PersonalId = personalId,
            IsEmployed = isEmployeed,
            EmploymentStartDate = employmentStartDate,
            EmploymentEndDate = employmentEndDate,
            DateOfBirth = dateOfBirth,
            Gender = gender,
            IsDeleted = false,
            CreatedBy = "TEST",
            CreatedAt = DateTime.Now
        };
    }
}
