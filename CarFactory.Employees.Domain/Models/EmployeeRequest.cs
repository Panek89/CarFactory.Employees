using CarFactory.Employees.Domain.ExtensionMethods;
using CarFactory.Employees.SharedLibrary.Enums;

namespace CarFactory.Employees.Domain.Models;

public class EmployeeRequest : BaseEntity
{
    public int NumberOfEmployeesNeeded { get; private set; }
    public string Business { get; private set; }
    public DateTime StartDate { get; private set; }
    public EmployeeRequestStatus Status { get; private set; }
    public ICollection<EmployeeRequestCandidate> Candidates { get; set; } = [];

    private EmployeeRequest() { }

    public EmployeeRequest SetNumberOfEmployeesNeeded(int numberOfEmployeesNeeded)
    {
        if (numberOfEmployeesNeeded < 1|| numberOfEmployeesNeeded > 10)
        {
            throw new ArgumentException("Number of employees needed in Request must be between 1 and 10", nameof(NumberOfEmployeesNeeded));
        }

        NumberOfEmployeesNeeded = numberOfEmployeesNeeded;
        return this;
    }

    public EmployeeRequest SetBusiness(string business)
    {
        if (string.IsNullOrEmpty(business))
        {
            throw new ArgumentNullException(nameof(Business), "Business must be specified");
        }

        Business = business;
        return this;
    }

    public EmployeeRequest SetStartDate(DateTime startDate)
    {
        if (startDate < DateTime.Today)
        {
            throw new ArgumentException("Request Start Date cannot be in the past", nameof(StartDate));
        }

        if (startDate < DateTime.Today.AddMonths(1))
        {
            throw new ArgumentException("Request Start Date must be at least one month in advance", nameof(StartDate));
        }

        StartDate = startDate;
        return this;
    }

    public EmployeeRequest SetStatus(EmployeeRequestStatus status)
    {
        if (status != EmployeeRequestStatus.Registered)
        {
            throw new ArgumentException($"On request registration, status can be only set to {EmployeeRequestStatus.Registered.ToString()}", nameof(Status));
        }

        Status = status;
        return this;
    }

    public static EmployeeRequest Register(int numberOfEmployeesNeeded, string business, DateTime startDate)
    {
        return new EmployeeRequest()
            .SetInitialMetaData()
            .SetNumberOfEmployeesNeeded(numberOfEmployeesNeeded)
            .SetBusiness(business)
            .SetStartDate(startDate)
            .SetStatus(EmployeeRequestStatus.Registered);
    }
}
