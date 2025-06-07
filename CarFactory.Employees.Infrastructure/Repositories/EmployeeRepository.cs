using CarFactory.Employees.Domain.Models;
using CarFactory.Employees.Domain.Repositories;
using CarFactory.Employees.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace CarFactory.Employees.Infrastructure.Repositories;

public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<EmployeeDetails?> GetEmployeeDetailsAsync(Guid id, CancellationToken token)
    {
        return await _dbSet
            .AsNoTracking()
            .Where(x => x.Id == id)
            .Select(y => new EmployeeDetails
                {
                    FirstName = y.FirstName,
                    LastName = y.LastName,
                    PersonalId = y.PersonalId,
                    DateOfBirth = y.DateOfBirth
                })
            .SingleOrDefaultAsync(token);
    }

    public async Task<EmployeeDetails?> GetEmployeeDetailsAsync(PersonalId personalId, CancellationToken token)
    {
        return await _dbSet
            .AsNoTracking()
            .Where(x => x.PersonalId == personalId)
            .Select(y => new EmployeeDetails
                {
                    FirstName = y.FirstName,
                    LastName = y.LastName,
                    PersonalId = y.PersonalId,
                    DateOfBirth = y.DateOfBirth
                })
            .SingleOrDefaultAsync(token);
    }
}
