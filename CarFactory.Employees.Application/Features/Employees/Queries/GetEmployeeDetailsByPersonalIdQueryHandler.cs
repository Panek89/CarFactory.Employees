using CarFactory.Employees.Domain.Repositories;
using CarFactory.Employees.Domain.ValueObjects;
using MediatR;

namespace CarFactory.Employees.Application.Features.Employees.Queries;

public class GetEmployeeDetailsByPersonalIdQueryHandler : IRequestHandler<GetEmployeeDetailsByPersonalIdQuery, EmployeeDetails?>
{
    private readonly IEmployeeRepository _employeeRepository;

    public GetEmployeeDetailsByPersonalIdQueryHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
    }

    public async Task<EmployeeDetails?> Handle(GetEmployeeDetailsByPersonalIdQuery query, CancellationToken cancellationToken)
    {
        return await _employeeRepository.GetEmployeeDetailsAsync(query.PersonalId, cancellationToken);
    }
}


public class GetEmployeeDetailsByPersonalIdQuery : IRequest<EmployeeDetails?>
{
    public required PersonalId PersonalId { get; init; }
}