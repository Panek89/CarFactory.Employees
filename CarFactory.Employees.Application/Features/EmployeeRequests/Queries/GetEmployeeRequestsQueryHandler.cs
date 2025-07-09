using CarFactory.Employees.Contracts.DTOs.EmployeeRequests;
using CarFactory.Employees.Domain.Repositories;
using MediatR;

namespace CarFactory.Employees.Application.Features.EmployeeRequests.Queries;

public class GetEmployeeRequestsQueryHandler : IRequestHandler<GetEmployeeRequestsQuery, IEnumerable<EmployeeRequestDetailsDto>>
{
    private readonly IEmployeeRequestRepository _employeeRequestRepository;

    public GetEmployeeRequestsQueryHandler(IEmployeeRequestRepository employeeRequestRepository)
    {
        _employeeRequestRepository = employeeRequestRepository ?? throw new ArgumentNullException(nameof(employeeRequestRepository));
    }

    public async Task<IEnumerable<EmployeeRequestDetailsDto>> Handle(GetEmployeeRequestsQuery query, CancellationToken cancellationToken)
    {
        return (await _employeeRequestRepository.GetAllAsync(cancellationToken)).MapToDtos();
    }
}

public class GetEmployeeRequestsQuery : IRequest<IEnumerable<EmployeeRequestDetailsDto>>
{
}