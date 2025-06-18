using CarFactory.Employees.Domain.Models;
using CarFactory.Employees.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CarFactory.Employees.Infrastructure.Repositories;

public class EmployeeRequestRepository : BaseRepository<EmployeeRequest>, IEmployeeRequestRepository
{
    public EmployeeRequestRepository(AppDbContext context) : base(context)
    { 
    }

    public async Task<EmployeeRequest?> GetRequestWithCandidatesAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _dbSet.Include(i => i.Candidates).SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IEnumerable<EmployeeRequest>> GetAllWithCandidatesAsync(CancellationToken token)
    {
        return await _dbSet.Include(x => x.Candidates).ToListAsync(token);
    }
}
