using CarFactory.Employees.Domain.Entities;
using CarFactory.Employees.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CarFactory.Employees.Infrastructure.Repositories;

public class FactoryRepository : BaseRepository<Factory>, IFactoryRepository
{
  public FactoryRepository(AppDbContext context) : base(context)
  {
  }

  public async Task<Factory?> GetByFactoryIdAsync(Guid factoryId, CancellationToken cancellationToken) => await _dbSet.SingleOrDefaultAsync(x => x.FactoryId == factoryId, cancellationToken);
}
