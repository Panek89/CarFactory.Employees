using CarFactory.Employees.Application.Features.EmployeeRequests.DTOs;
using MediatR;

namespace CarFactory.Employees.Application.Features.EmployeeRequests.Queries;

public class GetActualRequestesDetailsQueryHandler : IRequestHandler<GetActualRequestesDetailsQuery, IEnumerable<EmployeeRequestDetailsDto>>
{
    private readonly IEmployeeRequestService _employeeRequestService;

    public GetActualRequestesDetailsQueryHandler(IEmployeeRequestService employeeRequestService)
    {
        _employeeRequestService = employeeRequestService ?? throw new ArgumentNullException(nameof(employeeRequestService));
    }

    public async Task<IEnumerable<EmployeeRequestDetailsDto>> Handle(GetActualRequestesDetailsQuery query, CancellationToken cancellationToken)
    {
        return await _employeeRequestService.ActualRequestsDetailsAsync(cancellationToken);
    }
}

public class GetActualRequestesDetailsQuery : IRequest<IEnumerable<EmployeeRequestDetailsDto>>
{
}
