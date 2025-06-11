using CarFactory.Employees.Domain.Models;
using CarFactory.Employees.Domain.ValueObjects;

namespace CarFactory.Employees.Domain.Repositories;

public interface IEmployeeRequestRepository : IBaseRepository<EmployeeRequest>
{
    Task<EmployeeRequest?> GetRequestWithCandidatesAsync(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<EmployeeRequestDetails>> ActualRequestsDetailsAsync(CancellationToken token);
    Task<IEnumerable<EmployeeRequest>> GetAllWithCandidatesAsync(CancellationToken token);
}
