using CarFactory.Employees.Domain.Models;
using CarFactory.Employees.Domain.ValueObjects;

namespace CarFactory.Employees.Domain.TESTS.Models;

public class EmployeeTests
{
    private readonly string _correctFirstName = "FirstName";
    private readonly string _correctLastName = "Surname";
    private readonly DateTime _correctDateOfBirth = DateTime.Today.AddYears(-20);
    private readonly DateTime _correctEmploymentStartDate = DateTime.Today.AddMonths(-5);
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
        Assert.Throws<ArgumentNullException>(() => CreateEmployee(firstName, _correctLastName, _personalId, true, _correctEmploymentStartDate, null, _correctDateOfBirth));
    }

    [TestCase(null)]
    [TestCase(default)]
    public void Employee_ShouldThrowArgumentNullException_WhenLastNameIsNull(string? lastName)
    {
        Assert.Throws<ArgumentNullException>(() => CreateEmployee(_correctFirstName, lastName, _personalId, true, _correctEmploymentStartDate, null, _correctDateOfBirth));
    }

    [TestCase("A")]
    [TestCase("B")]
    public void Employee_ShouldThrowArgumentException_WhenFirstNameIsTooShort(string firstName)
    {
        Assert.Throws<ArgumentException>(() => CreateEmployee(firstName, _correctLastName, _personalId, true, _correctEmploymentStartDate, null, _correctDateOfBirth));
    }

    [TestCase("C")]
    [TestCase("D")]
    public void Employee_ShouldThrowArgumentException_WhenLastNameIsTooShort(string lastName)
    {
        Assert.Throws<ArgumentException>(() => CreateEmployee(_correctFirstName, lastName, _personalId, true, _correctEmploymentStartDate, null, _correctDateOfBirth));
    }

    [TestCase("Stefan!")]
    [TestCase("@ndrzej")]
    public void Employee_ShouldThrowArgumentException_WhenFirstNameContainsSpecialCharacters(string firstName)
    {
        Assert.Throws<ArgumentException>(() => CreateEmployee(firstName, _correctLastName, _personalId, true, _correctEmploymentStartDate, null, _correctDateOfBirth));
    }

    [TestCase("Now@k")]
    [TestCase("Duriak!*")]
    public void Employee_ShouldThrowArgumentException_WhenLastNameContainsSpecialCharacters(string lastName)
    {
        Assert.Throws<ArgumentException>(() => CreateEmployee(_correctFirstName, lastName, _personalId, true, _correctEmploymentStartDate, null, _correctDateOfBirth));
    }

    private PersonalId CreatePersonalId(string personalId)
    {
        return new PersonalId(personalId);
    }

    private Employee CreateEmployee(string firstName, string lastName, PersonalId personalId, bool isEmployeed, DateTime employmentStartDate, DateTime? employmentEndDate, DateTime dateOfBirth)
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
            IsDeleted = false,
            CreatedBy = "TEST",
            CreatedAt = DateTime.Now
        };
    }
}
