using CarFactory.Employees.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CarFactory.Employees.Infrastructure.Repositories;

public interface IEmployeeRequestRepository : IBaseRepository<EmployeeRequest>
{
    Task<IEnumerable<EmployeeRequest>> GetAllWithCandidatesAsync(CancellationToken token);
}

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


