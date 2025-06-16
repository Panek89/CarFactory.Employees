using CarFactory.Employees.Application.Features.Employees.DTOs;
using CarFactory.Employees.Domain.Repositories;
using MediatR;

namespace CarFactory.Employees.Application.Features.Employees.Queries;

public class GetEmployeeDetailsQueryHandler : IRequestHandler<GetEmployeeDetailsQuery, EmployeeDetailsDto?>
{
    private readonly IEmployeeRepository _employeeRepository;

    public GetEmployeeDetailsQueryHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
    }

    public async Task<EmployeeDetailsDto?> Handle(GetEmployeeDetailsQuery query, CancellationToken cancellationToken)
    {
        return await _employeeRepository.GetEmployeeDetailsAsync(query.Id, cancellationToken);
    }
}

public class GetEmployeeDetailsQuery : IRequest<EmployeeDetailsDto?>
{
    public Guid Id { get; init; }
}