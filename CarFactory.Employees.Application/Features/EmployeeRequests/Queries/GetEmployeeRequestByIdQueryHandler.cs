using CarFactory.Employees.Contracts.DTOs.EmployeeRequests;
using CarFactory.Employees.Domain.Repositories;
using MediatR;

namespace CarFactory.Employees.Application.Features.EmployeeRequests.Queries;

public class GetEmployeeRequestByIdQueryHandler : IRequestHandler<GetEmployeeRequestByIdQuery, EmployeeRequestDetailsDto?>
{
    private readonly IEmployeeRequestRepository _employeeRequestRepository;

    public GetEmployeeRequestByIdQueryHandler(IEmployeeRequestRepository employeeRequestRepository)
    {
        _employeeRequestRepository = employeeRequestRepository ?? throw new ArgumentNullException(nameof(employeeRequestRepository));
    }

    public async Task<EmployeeRequestDetailsDto?> Handle(GetEmployeeRequestByIdQuery query, CancellationToken cancellationToken)
    {
        return (await _employeeRequestRepository.GetByIdAsync(query.Id, cancellationToken))?.MapToDto();
    }
}

public class GetEmployeeRequestByIdQuery : IRequest<EmployeeRequestDetailsDto?>
{
    public Guid Id { get; init; }
}