using CarFactory.Employees.Application.Features.EmployeeRequests;
using CarFactory.Employees.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CarFactory.Employees.Infrastructure.Services;

public class EmployeeRequestService: IEmployeeRequestService
{
    private readonly DbSet<EmployeeRequest> _employeeRequests;

    public EmployeeRequestService(AppDbContext context)
    {
        _employeeRequests = context.EmployeeRequests;
    }
}
