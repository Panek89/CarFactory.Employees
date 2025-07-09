using CarFactory.Employees.Application.Features.Employees;
using CarFactory.Employees.Contracts.DTOs.Employees;
using CarFactory.Employees.Domain.Models;
using CarFactory.Employees.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace CarFactory.Employees.Infrastructure.Services;

public class EmployeeService : IEmployeeService
{
    private readonly DbSet<Employee> _employees;

    public EmployeeService(AppDbContext context)
    {
        _employees = context.Employees;
    }

    public async Task<EmployeeDetailsDto?> GetEmployeeDetailsAsync(Guid id, CancellationToken token)
    {
        return await _employees.Where(x => x.Id == id).Select(s => s.MapToDto()).SingleOrDefaultAsync();
    }

    public async Task<EmployeeDetailsDto?> GetEmployeeDetailsAsync(PersonalId personalId, CancellationToken token)
    {
        return await _employees.Where(x => x.PersonalId == personalId).Select(s => s.MapToDto()).SingleOrDefaultAsync();
    }
}
