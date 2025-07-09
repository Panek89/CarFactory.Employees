using CarFactory.Employees.Contracts.DTOs.Employees;
using CarFactory.Employees.Domain.ValueObjects;
using MediatR;

namespace CarFactory.Employees.Application.Features.Employees.Queries;

public class GetEmployeeDetailsByPersonalIdQueryHandler : IRequestHandler<GetEmployeeDetailsByPersonalIdQuery, EmployeeDetailsDto?>
{
    private readonly IEmployeeService _employeeService;

    public GetEmployeeDetailsByPersonalIdQueryHandler(IEmployeeService employeeService)
    {
        _employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
    }

    public async Task<EmployeeDetailsDto?> Handle(GetEmployeeDetailsByPersonalIdQuery query, CancellationToken cancellationToken)
    {
        return await _employeeService.GetEmployeeDetailsAsync(query.PersonalId, cancellationToken);
    }
}


public class GetEmployeeDetailsByPersonalIdQuery : IRequest<EmployeeDetailsDto?>
{
    public required PersonalId PersonalId { get; init; }
}