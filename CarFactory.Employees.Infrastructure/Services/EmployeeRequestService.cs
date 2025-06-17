using CarFactory.Employees.Application.Features.EmployeeRequests;
using CarFactory.Employees.Application.Features.EmployeeRequests.DTOs;
using CarFactory.Employees.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CarFactory.Employees.Infrastructure.Services;

public class EmployeeRequestService : IEmployeeRequestService
{
    private readonly DbSet<EmployeeRequest> _employeeRequests;

    public EmployeeRequestService(AppDbContext context)
    {
        _employeeRequests = context.EmployeeRequests;
    }

    public async Task<IEnumerable<EmployeeRequestDetailsDto>> ActualRequestsDetailsAsync(CancellationToken cancellationToken)
    {
        return await _employeeRequests.Where(x => x.StartDate > DateTime.Today)
            .Select(s => s.MapToDto())
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<EmployeeRequestDetailsDto?> GetRequestDetailsWithCandidatesAsync(Guid employeeRequestId, CancellationToken token)
    {
        return await _employeeRequests.Where(x => x.Id == employeeRequestId)
            .Include(i => i.Candidates)
            .Select(s => s.MapToDto())
            .AsNoTracking()
            .SingleOrDefaultAsync(token);
    }
}
