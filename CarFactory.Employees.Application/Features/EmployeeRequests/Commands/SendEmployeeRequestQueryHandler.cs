using System;
using MediatR;

namespace CarFactory.Employees.Application.Features.EmployeeRequests.Commands;

public class SendEmployeeRequestQueryHandler : IRequestHandler<SendEmployeeRequestQuery>
{
    public Task<Unit> Handle(SendEmployeeRequestQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

public class SendEmployeeRequestQuery : IRequest
{
    
}