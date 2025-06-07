
using CarFactory.Employees.Domain.Models;
using CarFactory.Employees.Domain.ValueObjects;

namespace CarFactory.Employees.Domain.Contracts;

public static class EmployeeContractMapping
{
    public static EmployeeDetails MapToEmployeeDetails(this Employee employee)
    {
        return new EmployeeDetails()
        {
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            PersonalId = employee.PersonalId,
            DateOfBirth = employee.DateOfBirth
        };
    }
}
