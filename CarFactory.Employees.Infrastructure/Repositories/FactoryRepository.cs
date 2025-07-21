using CarFactory.Employees.Domain.Models;
using CarFactory.Employees.Domain.Repositories;

namespace CarFactory.Employees.Infrastructure.Repositories;

public class FactoryRepository : BaseRepository<Factory>, IFactoryRepository
{
    public FactoryRepository(AppDbContext context) : base(context)
    {
    }
}
