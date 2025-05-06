using CarFactory.Employees.Application.Features.EmployeeRequests.DTOs;
using CarFactory.Employees.Domain.Repositories;
using CarFactory.Employees.SharedLibrary.Enums;
using MediatR;

namespace CarFactory.Employees.Application.Features.EmployeeRequests.Commands;

public class RegisterEmployeeRequestCommandHandler : IRequestHandler<RegisterEmployeeRequestCommand, EmployeeRequestDto>
{
    private readonly IEmployeeRequestRepository _employeeRequestRepository;

    public RegisterEmployeeRequestCommandHandler(IEmployeeRequestRepository employeeRequestRepository)
    {
        _employeeRequestRepository = employeeRequestRepository ?? throw new ArgumentNullException(nameof(employeeRequestRepository));
    }

    public async Task<EmployeeRequestDto> Handle(RegisterEmployeeRequestCommand command, CancellationToken token)
    {
        var employeeRequest = command.MapToEmployeeRequest();
        await _employeeRequestRepository.AddAsync(employeeRequest, token);
        await _employeeRequestRepository.SaveChangesAsync(token);

        return employeeRequest.MapToDto();
    }
}

public class RegisterEmployeeRequestCommand : IRequest<EmployeeRequestDto>
{
    public int NoOfEmployeesNeeded { get; init; }
    public required string Business { get; init; }
    public DateTime StartDate { get; init; }
    public readonly EmployeeRequestStatus Status = EmployeeRequestStatus.Registered;
}
