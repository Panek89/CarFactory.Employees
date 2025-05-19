using CarFactory.Employees.Domain.Models;
using CarFactory.Employees.SharedLibrary.Enums;

namespace CarFactory.Employees.Domain.Factories;

public class EmployeeFactory
{
    public static EmployeeFactory Create() => new EmployeeFactory();

    private readonly Employee _instance = new Employee();

    public EmployeeFactory SetFirstName(string firstName)
    {
        _instance.SetFirstName(firstName);
        return this;
    }

    public EmployeeFactory SetLastName(string lastName)
    {
        _instance.SetLastName(lastName);
        return this;
    }
    public EmployeeFactory SetPersonalId(string personalId)
    {
        _instance.SetPersonalId(personalId);
        return this;
    }

    public EmployeeFactory SetGender(Gender gender)
    {
        _instance.SetGender(gender);
        return this;
    }

    public EmployeeFactory SetIsEmployed(bool isEmployed)
    {
        _instance.SetIsEmployed(isEmployed);
        return this;
    }

    public EmployeeFactory SetEmploymentStartDate(DateTime employmenStartDate)
    {
        _instance.SetEmploymentStartDate(employmenStartDate);
        return this;
    }

    public EmployeeFactory SetEmploymentEndDate(DateTime employmenEndDate)
    {
        _instance.SetEmploymentEndDate(employmenEndDate);
        return this;
    }

    public Employee Build()
    {
        return _instance;
    }
}
