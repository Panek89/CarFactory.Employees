using AutoFixture;
using CarFactory.Employees.Domain.Models;
using CarFactory.Employees.Domain.ValueObjects;
using CarFactory.Employees.SharedLibrary.Enums;

namespace CarFactory.Employees.Domain.TESTS.Models;

public class EmployeeRequestCandidateTests
{
    private readonly string _correctFirstName = "FirstName";
    private readonly string _correctLastName = "Surname";
    private readonly DateTime _correctDateOfBirth = DateTime.Today.AddYears(-20);

    [TestCase(null)]
    [TestCase(default)]
    public void EmployeeRequestCandidate_ShouldThrowArgumentNullException_WhenFirstNameIsNull(string? firstName)
    {
        var fixture = new Fixture();
        var personalId = fixture.Create<PersonalId>();
        var employeeRequest = CreateEmployeeRequest();

        Assert.Throws<ArgumentNullException>(() => CreateEmployeeRequestCandidate(firstName, _correctLastName, _correctDateOfBirth, personalId, employeeRequest));
    }

    [TestCase(null)]
    [TestCase(default)]
    public void EmployeeRequestCandidate_ShouldThrowArgumentNullException_WhenLastNameIsNull(string? lastName)
    {
        var fixture = new Fixture();
        var personalId = fixture.Create<PersonalId>();
        var employeeRequest = CreateEmployeeRequest();

        Assert.Throws<ArgumentNullException>(() => CreateEmployeeRequestCandidate(_correctFirstName, lastName, _correctDateOfBirth, personalId, employeeRequest));
    }

    [TestCase("A")]
    [TestCase("B")]
    public void EmployeeRequestCandidate_ShouldThrowArgumentException_WhenFirstNameIsTooShort(string firstName)
    {
        var fixture = new Fixture();
        var personalId = fixture.Create<PersonalId>();
        var employeeRequest = CreateEmployeeRequest();

        Assert.Throws<ArgumentException>(() => CreateEmployeeRequestCandidate(firstName, _correctLastName, _correctDateOfBirth, personalId, employeeRequest));
    }

    [TestCase("C")]
    [TestCase("D")]
    public void EmployeeRequestCandidate_ShouldThrowArgumentException_WhenLastNameIsTooShort(string lastName)
    {
        var fixture = new Fixture();
        var personalId = fixture.Create<PersonalId>();
        var employeeRequest = CreateEmployeeRequest();

        Assert.Throws<ArgumentException>(() => CreateEmployeeRequestCandidate(_correctFirstName, lastName, _correctDateOfBirth, personalId, employeeRequest));
    }

    [TestCase("Stefan!")]
    [TestCase("@ndrzej")]
    public void EmployeeRequestCandidate_ShouldThrowArgumentException_WhenFirstNameContainsSpecialCharacters(string firstName)
    {
        var fixture = new Fixture();
        var personalId = fixture.Create<PersonalId>();
        var employeeRequest = CreateEmployeeRequest();

        Assert.Throws<ArgumentException>(() => CreateEmployeeRequestCandidate(firstName, _correctLastName, _correctDateOfBirth, personalId, employeeRequest));
    }

    [TestCase("Now@k")]
    [TestCase("Duriak!*")]
    public void EmployeeRequestCandidate_ShouldThrowArgumentException_WhenLastNameContainsSpecialCharacters(string lastName)
    {
        var fixture = new Fixture();
        var personalId = fixture.Create<PersonalId>();
        var employeeRequest = CreateEmployeeRequest();

        Assert.Throws<ArgumentException>(() => CreateEmployeeRequestCandidate(_correctFirstName, lastName, _correctDateOfBirth, personalId, employeeRequest));
    }

    private void CreateEmployeeRequestCandidate(string firstName, string lastName, DateTime dateOfBirth, PersonalId personalId, EmployeeRequest employeeRequest)
    {
        var requestCandidate = new EmployeeRequestCandidate()
        {
            Id = Guid.NewGuid(),
            FirstName = firstName,
            LastName = lastName,
            PersonalId = personalId,
            DateOfBirth = dateOfBirth,
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
