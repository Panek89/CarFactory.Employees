using CarFactory.Employees.Application.Features.EmployeeRequests.DTOs;
using CarFactory.Employees.Domain.Repositories;
using MediatR;

namespace CarFactory.Employees.Application.Features.EmployeeRequests.Queries;

public class GetEmployeeRequestsQueryHandler : IRequestHandler<GetEmployeeRequestsQuery, IEnumerable<EmployeeRequestDto>>
{
    private readonly IEmployeeRequestRepository _employeeRequestRepository;

    public GetEmployeeRequestsQueryHandler(IEmployeeRequestRepository employeeRequestRepository)
    {
        _employeeRequestRepository = employeeRequestRepository ?? throw new ArgumentNullException(nameof(employeeRequestRepository));
    }

    public async Task<IEnumerable<EmployeeRequestDto>> Handle(GetEmployeeRequestsQuery query, CancellationToken cancellationToken)
    {
        return (await _employeeRequestRepository.GetAllAsync(cancellationToken)).MapToDtos();
    }
}

public class GetEmployeeRequestsQuery : IRequest<IEnumerable<EmployeeRequestDto>>
{
}