using CarFactory.Employees.SharedLibrary.Enums;
using MediatR;

namespace CarFactory.Employees.Application.Features.EmployeeRequests.Commands;

public class RegisterEmployeeRequestQueryHandler : IRequestHandler<RegisterEmployeeRequestQuery>
{
    public Task<Unit> Handle(RegisterEmployeeRequestQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

public class RegisterEmployeeRequestQuery : IRequest
{
    public int NoOfEmployeesNeeded { get; init; }
    public required string Business { get; init; }
    public DateTime StartDate { get; init; }
    public readonly EmployeeRequestStatus Status = EmployeeRequestStatus.Registered;
}
