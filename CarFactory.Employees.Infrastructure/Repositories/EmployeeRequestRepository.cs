using CarFactory.Employees.Domain.Models;

namespace CarFactory.Employees.Infrastructure.Repositories;

public interface IEmployeeRequestRepository : IBaseRepository<EmployeeRequest>
{

}

public class EmployeeRequestRepository : BaseRepository<EmployeeRequest>, IEmployeeRequestRepository
{
    public EmployeeRequestRepository(AppDbContext context) : base(context)
    {
    }
}


