using CarFactory.Employees.Application.Features.EmployeeRequests.DTOs;
using CarFactory.Employees.Infrastructure.Repositories;
using CarFactory.Employees.SharedLibrary.Enums;
using MediatR;

namespace CarFactory.Employees.Application.Features.EmployeeRequests.Commands;

public class RegisterEmployeeRequestQueryHandler : IRequestHandler<RegisterEmployeeRequestQuery, EmployeeRequestDto>
{
    private readonly IEmployeeRequestRepository _employeeRequestRepository;

    public RegisterEmployeeRequestQueryHandler(IEmployeeRequestRepository employeeRequestRepository)
    {
        _employeeRequestRepository = employeeRequestRepository;
    }

    public async Task<EmployeeRequestDto> Handle(RegisterEmployeeRequestQuery query, CancellationToken token)
    {
        var employeeRequest = query.MapToEmployeeRequest();
        await _employeeRequestRepository.AddAsync(employeeRequest, token);
        await _employeeRequestRepository.SaveChangesAsync(token);

        return employeeRequest.MapToDto();
    }
}

public class RegisterEmployeeRequestQuery : IRequest<EmployeeRequestDto>
{
    public int NoOfEmployeesNeeded { get; init; }
    public required string Business { get; init; }
    public DateTime StartDate { get; init; }
    public readonly EmployeeRequestStatus Status = EmployeeRequestStatus.Registered;
}
