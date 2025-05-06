using CarFactory.Employees.Domain.Models;
using CarFactory.Employees.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CarFactory.Employees.Infrastructure.Repositories;

public class EmployeeRequestRepository : BaseRepository<EmployeeRequest>, IEmployeeRequestRepository
{
    public EmployeeRequestRepository(AppDbContext context) : base(context)
    { 
    }

    public async Task<IEnumerable<EmployeeRequest>> GetAllWithCandidatesAsync(CancellationToken token)
    {
        return await _dbSet.Include(x => x.Candidates).ToListAsync(token);
    }
}
