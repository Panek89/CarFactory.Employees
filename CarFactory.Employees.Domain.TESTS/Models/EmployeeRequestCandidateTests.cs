using CarFactory.Employees.Domain.Models;
using CarFactory.Employees.Domain.TESTS.Extensions;
using CarFactory.Employees.Domain.ValueObjects;

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
            Throws.ArgumentNullException.With.Property(nameof(ArgumentNullException.ParamName)).EqualTo("LastName")); ;
    }

    //[TestCase("A")]
    //[TestCase("B")]
    //public void EmployeeRequestCandidate_ShouldThrowArgumentException_WhenFirstNameIsTooShort(string firstName)
    //{
    //    Assert.Throws<ArgumentException>(() => CreateEmployeeRequestCandidate(firstName, _correctLastName, _correctDateOfBirth, _personalId, _employeeRequest));
    //}

    //[TestCase("C")]
    //[TestCase("D")]
    //public void EmployeeRequestCandidate_ShouldThrowArgumentException_WhenLastNameIsTooShort(string lastName)
    //{
    //    Assert.Throws<ArgumentException>(() => CreateEmployeeRequestCandidate(_correctFirstName, lastName, _correctDateOfBirth, _personalId, _employeeRequest));
    //}

    //[TestCase("Stefan!")]
    //[TestCase("@ndrzej")]
    //public void EmployeeRequestCandidate_ShouldThrowArgumentException_WhenFirstNameContainsSpecialCharacters(string firstName)
    //{
    //    Assert.Throws<ArgumentException>(() => CreateEmployeeRequestCandidate(firstName, _correctLastName, _correctDateOfBirth, _personalId, _employeeRequest));
    //}

    //[TestCase("Now@k")]
    //[TestCase("Duriak!*")]
    //public void EmployeeRequestCandidate_ShouldThrowArgumentException_WhenLastNameContainsSpecialCharacters(string lastName)
    //{
    //    Assert.Throws<ArgumentException>(() => CreateEmployeeRequestCandidate(_correctFirstName, lastName, _correctDateOfBirth, _personalId, _employeeRequest));
    //}

    //[TestCase(-17, Gender.Male)]
    //[TestCase(-16, Gender.Female)]
    //public void EmployeeRequestCandidate_ShouldThrowArgumentException_WhenEmployeeAgeIsBelow18_NoMatterOfGender(int yearsFromToday, Gender gender)
    //{
    //    var dateOfBirth = DateTime.Today.AddYears(yearsFromToday);

    //    Assert.Throws<ArgumentException>(() => CreateEmployeeRequestCandidate(_correctFirstName, _correctLastName, dateOfBirth, _personalId, _employeeRequest, gender));
    //}

    //[TestCase(-61)]
    //[TestCase(-65)]
    //public void EmployeeRequestCandidate_ShouldThrowArgumentException_WhenEmployeeAgeIsAbove60_ForFemales(int yearsFromToday)
    //{
    //    var dateOfBirth = DateTime.Today.AddYears(yearsFromToday);

    //    Assert.Throws<ArgumentException>(() => CreateEmployeeRequestCandidate(_correctFirstName, _correctLastName, dateOfBirth, _personalId, _employeeRequest, Gender.Female));
    //}

    //[TestCase(-66)]
    //[TestCase(-70)]
    //public void EmployeeRequestCandidate_ShouldThrowArgumentException_WhenEmployeeAgeIsAbove65_ForMales(int yearsFromToday)
    //{
    //    var dateOfBirth = DateTime.Today.AddYears(yearsFromToday);

    //    Assert.Throws<ArgumentException>(() => CreateEmployeeRequestCandidate(_correctFirstName, _correctLastName, dateOfBirth, _personalId, _employeeRequest, Gender.Male));
    //}

    //[TestCase(null)]
    //[TestCase(default)]
    //public void EmployeeRequestCandidate_ShouldThrowArgumentException_WhenEmployeeRequestIsNull(EmployeeRequest? employeeRequest)
    //{
    //    Assert.Throws<ArgumentException>(() => CreateEmployeeRequestCandidate(_correctFirstName, _correctLastName, _correctDateOfBirth, _personalId, employeeRequest, Gender.Male));
    //}

    //private void CreateEmployeeRequestCandidate(string firstName, string lastName, DateTime dateOfBirth, PersonalId personalId, EmployeeRequest employeeRequest, Gender gender = Gender.Male)
    //{
    //    var requestCandidate = new EmployeeRequestCandidate()
    //    {
    //        Id = Guid.NewGuid(),
    //        FirstName = firstName,
    //        LastName = lastName,
    //        PersonalId = personalId,
    //        DateOfBirth = dateOfBirth,
    //        Gender = gender,
    //        Status = EmployeeCandidateStatus.Candidate,
    //        EmployeeRequest = employeeRequest,
    //        IsDeleted = false,
    //        CreatedBy = "TEST",
    //        CreatedAt = DateTime.Today
    //    };
    //}
}
