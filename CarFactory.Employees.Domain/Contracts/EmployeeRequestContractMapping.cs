using CarFactory.Employees.Domain.Models;
using CarFactory.Employees.Domain.ValueObjects;

namespace CarFactory.Employees.Domain.Contracts;

public static class EmployeeRequestContractMapping
{
    public static EmployeeRequestDetails MapToEmployeeRequestDetails(this EmployeeRequest employeeRequest)
    {
        return new EmployeeRequestDetails()
        {
            NumberOfEmployeesNeeded = employeeRequest.NumberOfEmployeesNeeded,
            Business = employeeRequest.Business,
            StartDate = employeeRequest.StartDate,
            Status = employeeRequest.Status,
            NumberOfCandidates = employeeRequest.Candidates.Count
        };
    }
}
