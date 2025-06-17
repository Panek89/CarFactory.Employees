using CarFactory.Employees.Application.Features.EmployeeRequests.DTOs;

namespace CarFactory.Employees.Application.Features.EmployeeRequests;

public interface IEmployeeRequestService
{
    Task<IEnumerable<EmployeeRequestDetailsDto>> ActualRequestsDetailsAsync(CancellationToken cancellationToken);
    Task<EmployeeRequestDetailsDto?> GetRequestDetailsWithCandidatesAsync(Guid employeeRequestId, CancellationToken token);
}
