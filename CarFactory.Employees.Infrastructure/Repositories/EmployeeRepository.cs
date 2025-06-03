using CarFactory.Employees.Domain.Models;
using CarFactory.Employees.Domain.Repositories;

namespace CarFactory.Employees.Infrastructure.Repositories;

public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(AppDbContext context) : base(context)
    {
    }
}
