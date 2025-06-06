using CarFactory.Employees.Domain.Repositories;
using CarFactory.Employees.Domain.ValueObjects;
using MediatR;

namespace CarFactory.Employees.Application.Features.Employees.Queries;

public class GetEmployeeDetailsQueryHandler : IRequestHandler<GetEmployeeDetailsQuery, EmployeeDetails?>
{
    private readonly IEmployeeRepository _employeeRepository;

    public GetEmployeeDetailsQueryHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
    }

    public async Task<EmployeeDetails?> Handle(GetEmployeeDetailsQuery query, CancellationToken cancellationToken)
    {
        return await _employeeRepository.GetEmployeeDetailsAsync(query.Id, cancellationToken);
    }
}

public class GetEmployeeDetailsQuery : IRequest<EmployeeDetails?>
{
    public Guid Id { get; init; }
}