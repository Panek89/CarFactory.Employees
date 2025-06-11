using CarFactory.Employees.Application.Features.EmployeeRequests.DTOs;
using CarFactory.Employees.Domain.Repositories;
using CarFactory.Employees.SharedLibrary.Enums;
using MediatR;

namespace CarFactory.Employees.Application.Features.EmployeeRequests.Commands;

public class AssignCandidateToRequestCommandHandler : IRequestHandler<AssignCandidateToRequestCommand, EmployeeRequestCandidateDto?>
{
    private readonly IEmployeeRequestRepository _employeeRequestRepository;

    public AssignCandidateToRequestCommandHandler(IEmployeeRequestRepository employeeRequestRepository)
    {
        _employeeRequestRepository = employeeRequestRepository ?? throw new ArgumentNullException(nameof(employeeRequestRepository));
    }

    public async Task<EmployeeRequestCandidateDto?> Handle(AssignCandidateToRequestCommand command, CancellationToken cancellationToken)
    {
        var employeeRequest = await _employeeRequestRepository.GetRequestWithCandidatesAsync(command.EmployeeRequestId, cancellationToken);

        if (employeeRequest is null)
        {
            return null;
        }

        var employeeRequestCandidate = employeeRequest.AssignCandidate
        (
            employeeRequest,
            command.FirstName,
            command.LastName,
            command.PersonalId,
            command.Gender,
            command.DateOfBirth
        );

        await _employeeRequestRepository.SaveChangesAsync(cancellationToken);

        return employeeRequestCandidate.MapToDto();
    }
}

public class AssignCandidateToRequestCommand : IRequest<EmployeeRequestCandidateDto?>
{
    public Guid EmployeeRequestId { get; init; }
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required string PersonalId { get; init; }
    public required Gender Gender { get; init; }
    public required DateTime DateOfBirth { get; init; }
}