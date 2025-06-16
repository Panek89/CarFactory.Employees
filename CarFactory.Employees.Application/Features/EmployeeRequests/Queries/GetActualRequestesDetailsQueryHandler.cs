using CarFactory.Employees.Application.Features.EmployeeRequests.DTOs;
using CarFactory.Employees.Domain.Repositories;
using MediatR;

namespace CarFactory.Employees.Application.Features.EmployeeRequests.Queries;

public class GetActualRequestesDetailsQueryHandler : IRequestHandler<GetActualRequestesDetailsQuery, IEnumerable<EmployeeRequestDetailsDto>>
{
    private readonly IEmployeeRequestRepository _employeeRequestRepository;

    public GetActualRequestesDetailsQueryHandler(IEmployeeRequestRepository employeeRequestRepository)
    {
        _employeeRequestRepository = employeeRequestRepository ?? throw new ArgumentNullException(nameof(employeeRequestRepository));
    }

    public async Task<IEnumerable<EmployeeRequestDetailsDto>> Handle(GetActualRequestesDetailsQuery query, CancellationToken cancellationToken)
    {
        return await _employeeRequestRepository.ActualRequestsDetailsAsync(cancellationToken);
    }
}

public class GetActualRequestesDetailsQuery : IRequest<IEnumerable<EmployeeRequestDetailsDto>>
{
}
