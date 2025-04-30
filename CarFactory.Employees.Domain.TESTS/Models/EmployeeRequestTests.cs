using AutoFixture;
using CarFactory.Employees.Domain.Models;
using CarFactory.Employees.SharedLibrary.Enums;

namespace CarFactory.Employees.Domain.TESTS.Models;

public class EmployeeRequestTests
{
    private readonly int _correctNumberOfEmployees = 5;
    private readonly string _correctBusiness = "Business";
    private readonly DateTime _correctStartDate = DateTime.Today.AddMonths(2);

    [TestCase(0)]
    [TestCase(-1)]
    public void EmployeeRequest_ShouldThrowArgumentException_WhenNumberOfEmployeesNeeded_IsBelowOne(int numberOfEmployees)
    {
        Assert.Throws<ArgumentException>(() => CreateEmployeeRequest(numberOfEmployees, _correctBusiness, _correctStartDate, []));
    }

    [TestCase(11)]
    [TestCase(12)]
    [TestCase(21)]
    public void EmployeeRequest_ShouldThrowArgumentException_WhenNumberOfEmployeesNeeded_IsAboveTen(int numberOfEmployees)
    {
        Assert.Throws<ArgumentException>(() => CreateEmployeeRequest(numberOfEmployees, _correctBusiness, _correctStartDate, []));
    }

    [TestCase(null)]
    [TestCase(default)]
    public void EmployeeRequest_ShouldThrowArgumentNullException_WhenBusiness_IsNull(string? business)
    {
        Assert.Throws<ArgumentNullException>(() => CreateEmployeeRequest(_correctNumberOfEmployees, business, _correctStartDate, []));
    }

    [Test]
    public void EmployeeRequest_ShouldThrowArgumentException_WhenStartDate_IsInThePast()
    {
        Assert.Throws<ArgumentException>(() => CreateEmployeeRequest(_correctNumberOfEmployees, _correctBusiness, DateTime.Today.AddDays(-1), []));
    }

    [Test]
    public void EmployeeRequest_ShouldThrowArgumentException_WhenStartDate_IsLessThanOneMonthInFuture()
    {
        Assert.Throws<ArgumentException>(() => CreateEmployeeRequest(_correctNumberOfEmployees, _correctBusiness, DateTime.Today.AddMonths(1).AddDays(-1), []));
    }

    [TestCase(1, 2)]
    [TestCase(5, 6)]
    [TestCase(7, 10)]
    public void EmployeeRequest_ShouldThrowArgumentException_WhenNumberOfCandidates_ExceedNumberOfEmployees(int numberOfEmployees, int numberOfCandidates)
    {
        var fixture = new Fixture();
        var candidates = fixture.CreateMany<EmployeeRequestCandidate>(numberOfCandidates);

        Assert.Throws<ArgumentException>(() => CreateEmployeeRequest(numberOfEmployees, _correctBusiness, _correctStartDate, candidates));
    }

    private EmployeeRequest CreateEmployeeRequest(int numberOfEmployees, string business, DateTime startDate, IEnumerable<EmployeeRequestCandidate> candidates)
    {
        return new EmployeeRequest()
        {
            Id = Guid.NewGuid(),
            NumberOfEmployeesNeeded = numberOfEmployees,
            Business = business,
            StartDate = startDate,
            Status = EmployeeRequestStatus.Registered,
            Candidates = candidates.ToList(),
            CreatedBy = "TEST",
            CreatedAt = DateTime.Today,
            IsDeleted = false
        };
    }
}
