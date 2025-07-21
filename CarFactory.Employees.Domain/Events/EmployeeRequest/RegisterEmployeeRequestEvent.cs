using System;
using CarFactory.Employees.Domain.Common;

namespace CarFactory.Employees.Domain.Events.EmployeeRequest;

public class RegisterEmployeeRequestEvent : DomainEvent
{
    public Guid RequestId { get; }
    public int NoOfEmployeesNeeded { get; }
    public string Business { get; }

    public RegisterEmployeeRequestEvent(Guid requestId, int noOfEmployeesNeeded, string business)
    {
        RequestId = requestId;
        NoOfEmployeesNeeded = noOfEmployeesNeeded;
        Business = business;
    }
}
