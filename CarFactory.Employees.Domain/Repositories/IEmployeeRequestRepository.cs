using CarFactory.Employees.Domain.Models;

namespace CarFactory.Employees.Domain.Repositories;

public interface IEmployeeRequestRepository : IBaseRepository<EmployeeRequest>
{
    Task<IEnumerable<EmployeeRequest>> GetAllWithCandidatesAsync(CancellationToken token);
}
