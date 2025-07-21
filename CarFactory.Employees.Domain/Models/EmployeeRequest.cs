using CarFactory.Employees.Domain.Common;
using CarFactory.Employees.Domain.Events.EmployeeRequest;
using CarFactory.Employees.Domain.ExtensionMethods;
using CarFactory.Employees.SharedLibrary.Enums;

namespace CarFactory.Employees.Domain.Models;

public class EmployeeRequest : AggregateRoot
{
    private int _numberOfEmployeesNeeded;
    private string _business = null!;
    private DateTime _startDate;
    private EmployeeRequestStatus _status;

    public int NumberOfEmployeesNeeded
    {
        get => _numberOfEmployeesNeeded;
        private set
        {
            if (value < 1 || value > 10)
            {
                throw new ArgumentException("Number of employees needed in Request must be between 1 and 10", nameof(NumberOfEmployeesNeeded));
            }

            _numberOfEmployeesNeeded = value;
        }
    }
    public string Business
    {
        get => _business;
        private set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(Business), "Business must be specified");
            }

            _business = value;
        }
    }
    public DateTime StartDate
    {
        get => _startDate;
        private set
        {
            if (value < DateTime.Today)
            {
                throw new ArgumentException("Request Start Date cannot be in the past", nameof(StartDate));
            }

            if (value < DateTime.Today.AddMonths(1))
            {
                throw new ArgumentException("Request Start Date must be at least one month in advance", nameof(StartDate));
            }

            _startDate = value;
        }
    }
    public EmployeeRequestStatus Status
    {
        get => _status;
        private set
        {
            if (value != EmployeeRequestStatus.Registered)
            {
                throw new ArgumentException($"On request registration, status can be only set to {EmployeeRequestStatus.Registered.ToString()}", nameof(Status));
            }

            _status = value;
        }
    }
    public ICollection<EmployeeRequestCandidate> Candidates { get; set; } = [];

    private EmployeeRequest() { }

    private EmployeeRequest
    (
        int numberOfEmployeesNeeded,
        string business,
        DateTime startDate,
        EmployeeRequestStatus status
    )
    {
        NumberOfEmployeesNeeded = numberOfEmployeesNeeded;
        Business = business;
        StartDate = startDate;
        Status = status;
    }

    public static EmployeeRequest Register(int numberOfEmployeesNeeded, string business, DateTime startDate)
    {
        var employeeRequest = new EmployeeRequest
        (
            numberOfEmployeesNeeded,
            business,
            startDate,
            EmployeeRequestStatus.Registered
        ).SetInitialMetaData();

        employeeRequest.RaiseDomainEvent(new RegisterEmployeeRequestEvent(employeeRequest.Id, employeeRequest.NumberOfEmployeesNeeded, employeeRequest.Business));

        return employeeRequest;
    }

    public EmployeeRequestCandidate AssignCandidate(EmployeeRequest employeeRequest, string firstName, string lastName, string personalId, Gender gender, DateTime dateOfBirth)
    {
        var employeeRequestCandidate = EmployeeRequestCandidate.Register(firstName, lastName, personalId, gender, dateOfBirth);
        employeeRequest.Candidates.Add(employeeRequestCandidate);
        employeeRequest.RaiseDomainEvent(new AssignedCandidateEvent(employeeRequest.Id));

        return employeeRequestCandidate;
    }
}
