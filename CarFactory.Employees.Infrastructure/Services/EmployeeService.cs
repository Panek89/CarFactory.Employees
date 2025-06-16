using CarFactory.Employees.Application.Features.Employees;
using CarFactory.Employees.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CarFactory.Employees.Infrastructure.Services;

public class EmployeeService : IEmployeeService
{
    private readonly DbSet<Employee> _employees;

    public EmployeeService(AppDbContext context)
    {
        _employees = context.Employees;
    }
}
