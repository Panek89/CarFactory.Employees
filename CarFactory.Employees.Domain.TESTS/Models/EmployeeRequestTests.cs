using CarFactory.Employees.Domain.TESTS.Extensions;
using CarFactory.Employees.SharedLibrary.Enums;

namespace CarFactory.Employees.Domain.TESTS.Models;

public class EmployeeRequestTests
{

    [TestCase(0)]
    [TestCase(-1)]
    public void EmployeeRequest_ShouldThrowArgumentException_WhenNumberOfEmployeesNeeded_IsBelowOne(int numberOfEmployeesNeeded)
    {
        Assert.That(() => DomainTestsExtensions.EmployeeRequestRegisterCorrect().SetNumberOfEmployeesNeeded(numberOfEmployeesNeeded),
            Throws.ArgumentException.With.Property(nameof(ArgumentException.ParamName)).EqualTo("NumberOfEmployeesNeeded"));
    }

    [TestCase(11)]
    [TestCase(12)]
    [TestCase(21)]
    public void EmployeeRequest_ShouldThrowArgumentException_WhenNumberOfEmployeesNeeded_IsAboveTen(int numberOfEmployeesNeeded)
    {
        Assert.That(() => DomainTestsExtensions.EmployeeRequestRegisterCorrect().SetNumberOfEmployeesNeeded(numberOfEmployeesNeeded),
            Throws.ArgumentException.With.Property(nameof(ArgumentException.ParamName)).EqualTo("NumberOfEmployeesNeeded"));
    }

    [TestCase(null)]
    [TestCase(default)]
    [TestCase("")]
    public void EmployeeRequest_ShouldThrowArgumentNullException_WhenBusiness_IsNull(string? business)
    {
        Assert.That(() => DomainTestsExtensions.EmployeeRequestRegisterCorrect().SetBusiness(business),
            Throws.ArgumentNullException.With.Property(nameof(ArgumentNullException.ParamName)).EqualTo("Business"));
    }

    [Test]
    public void EmployeeRequest_ShouldThrowArgumentException_WhenStartDate_IsInThePast()
    {
        Assert.That(() => DomainTestsExtensions.EmployeeRequestRegisterCorrect().SetStartDate(DateTime.Today.AddDays(-1)),
            Throws.ArgumentException.With.Property(nameof(ArgumentException.ParamName)).EqualTo("StartDate"));
    }

    [Test]
    public void EmployeeRequest_ShouldThrowArgumentException_WhenStartDate_IsLessThanOneMonthInFuture()
    {
        Assert.That(() => DomainTestsExtensions.EmployeeRequestRegisterCorrect().SetStartDate(DateTime.Today.AddMonths(1).AddDays(-1)),
               Throws.ArgumentException.With.Property(nameof(ArgumentException.ParamName)).EqualTo("StartDate"));
    }

    [TestCase(EmployeeRequestStatus.Approved)]
    [TestCase(EmployeeRequestStatus.RejectedByHr)]
    [TestCase(EmployeeRequestStatus.NoCandidates)]
    [TestCase(EmployeeRequestStatus.CandidatesInInterview)]
    [TestCase(EmployeeRequestStatus.CandidatesInExams)]
    [TestCase(EmployeeRequestStatus.Completed)]
    public void EmployeeRequest_ShouldThrowArgumentException_WhenStatusOnRegister_IsIncorrect(EmployeeRequestStatus status)
    {
        Assert.That(() => DomainTestsExtensions.EmployeeRequestRegisterCorrect().SetStatus(status),
                Throws.ArgumentException.With.Property(nameof(ArgumentException.ParamName)).EqualTo("Status"));
    }

    // TODO
    //[TestCase(1, 2)]
    //[TestCase(5, 6)]
    //[TestCase(7, 10)]
    //public void EmployeeRequest_ShouldThrowArgumentException_WhenNumberOfCandidates_ExceedNumberOfEmployees(int numberOfEmployees, int numberOfCandidates)
    //{
    //    var fixture = new Fixture();
    //    var candidates = fixture.CreateMany<EmployeeRequestCandidate>(numberOfCandidates);

    //    Assert.Throws<ArgumentException>(() => CreateEmployeeRequest(numberOfEmployees, _correctBusiness, _correctStartDate, candidates));
    //}
}
