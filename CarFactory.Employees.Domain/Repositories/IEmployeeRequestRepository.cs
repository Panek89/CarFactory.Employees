using CarFactory.Employees.Domain.Models;

namespace CarFactory.Employees.Domain.Repositories;

public interface IEmployeeRequestRepository : IBaseRepository<EmployeeRequest>
{
    Task<EmployeeRequest?> GetRequestWithCandidatesAsync(Guid employeeRequestId, CancellationToken token);
    Task<IEnumerable<EmployeeRequest>> GetAllWithCandidatesAsync(CancellationToken token);
}
