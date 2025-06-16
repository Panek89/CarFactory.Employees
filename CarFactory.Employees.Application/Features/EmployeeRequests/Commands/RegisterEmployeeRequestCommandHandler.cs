using CarFactory.Employees.Application.Features.EmployeeRequests.DTOs;
using CarFactory.Employees.Domain.Models;
using CarFactory.Employees.Domain.Repositories;
using MediatR;

namespace CarFactory.Employees.Application.Features.EmployeeRequests.Commands;

public class RegisterEmployeeRequestCommandHandler : IRequestHandler<RegisterEmployeeRequestCommand, EmployeeRequestDetailsDto>
{
    private readonly IEmployeeRequestRepository _employeeRequestRepository;

    public RegisterEmployeeRequestCommandHandler(IEmployeeRequestRepository employeeRequestRepository)
    {
        _employeeRequestRepository = employeeRequestRepository ?? throw new ArgumentNullException(nameof(employeeRequestRepository));
    }

    public async Task<EmployeeRequestDetailsDto> Handle(RegisterEmployeeRequestCommand command, CancellationToken token)
    {
        var employeeRequest = EmployeeRequest.Register(command.NoOfEmployeesNeeded, command.Business, command.StartDate);
        await _employeeRequestRepository.AddAsync(employeeRequest, token);
        await _employeeRequestRepository.SaveChangesAsync(token);

        return employeeRequest.MapToDto();
    }
}

public class RegisterEmployeeRequestCommand : IRequest<EmployeeRequestDetailsDto>
{
    public int NoOfEmployeesNeeded { get; init; }
    public required string Business { get; init; }
    public DateTime StartDate { get; init; }
}
