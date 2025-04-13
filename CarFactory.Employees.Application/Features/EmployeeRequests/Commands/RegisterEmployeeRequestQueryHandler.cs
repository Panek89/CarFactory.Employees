using System;
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
    
}