using CarFactory.Employees.Contracts.DTOs.Employees;
using MediatR;

namespace CarFactory.Employees.Application.Features.Employees.Queries;

public class GetEmployeeDetailsQueryHandler : IRequestHandler<GetEmployeeDetailsQuery, EmployeeDetailsDto?>
{
    private readonly IEmployeeService _employeeService;

    public GetEmployeeDetailsQueryHandler(IEmployeeService employeeService)
    {
        _employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
    }

    public async Task<EmployeeDetailsDto?> Handle(GetEmployeeDetailsQuery query, CancellationToken cancellationToken)
    {
        return await _employeeService.GetEmployeeDetailsAsync(query.Id, cancellationToken);
    }
}

public class GetEmployeeDetailsQuery : IRequest<EmployeeDetailsDto?>
{
    public Guid Id { get; init; }
}