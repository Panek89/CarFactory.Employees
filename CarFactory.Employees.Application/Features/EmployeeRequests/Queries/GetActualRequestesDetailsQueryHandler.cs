using CarFactory.Employees.Domain.Repositories;
using CarFactory.Employees.Domain.ValueObjects;
using MediatR;

namespace CarFactory.Employees.Application.Features.EmployeeRequests.Queries;

public class GetActualRequestesDetailsQueryHandler : IRequestHandler<GetActualRequestesDetailsQuery, IEnumerable<EmployeeRequestDetails>>
{
    private readonly IEmployeeRequestRepository _employeeRequestRepository;

    public GetActualRequestesDetailsQueryHandler(IEmployeeRequestRepository employeeRequestRepository)
    {
        _employeeRequestRepository = employeeRequestRepository ?? throw new ArgumentNullException(nameof(employeeRequestRepository));
    }

    public async Task<IEnumerable<EmployeeRequestDetails>> Handle(GetActualRequestesDetailsQuery query, CancellationToken cancellationToken)
    {
        return await _employeeRequestRepository.ActualRequestsDetailsAsync(cancellationToken);
    }
}

public class GetActualRequestesDetailsQuery : IRequest<IEnumerable<EmployeeRequestDetails>>
{
}
