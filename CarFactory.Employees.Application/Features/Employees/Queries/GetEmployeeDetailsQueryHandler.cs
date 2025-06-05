using CarFactory.Employees.Domain.ValueObjects;
using MediatR;

namespace CarFactory.Employees.Application.Features.Employees.Queries;

public class GetEmployeeDetailsQueryHandler : IRequestHandler<GetEmployeeDetailsQuery, EmployeeDetails>
{
    public Task<EmployeeDetails> Handle(GetEmployeeDetailsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

public class GetEmployeeDetailsQuery : IRequest<EmployeeDetails>
{

}