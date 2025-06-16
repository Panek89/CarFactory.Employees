using CarFactory.Employees.Application.Features.EmployeeRequests.DTOs;
using CarFactory.Employees.Domain.Common;
using CarFactory.Employees.Domain.Repositories;
using CarFactory.Employees.SharedLibrary.Enums;
using MediatR;

namespace CarFactory.Employees.Application.Features.EmployeeRequests.Commands;

public class AssignCandidateToRequestCommandHandler : IRequestHandler<AssignCandidateToRequestCommand, EmployeeRequestCandidateDetailsDto?>
{
    private readonly IEmployeeRequestRepository _employeeRequestRepository;
    private readonly IDomainEventDispatcher _eventDispatcher;

    public AssignCandidateToRequestCommandHandler(IEmployeeRequestRepository employeeRequestRepository, IDomainEventDispatcher eventDispatcher)
    {
        _employeeRequestRepository = employeeRequestRepository ?? throw new ArgumentNullException(nameof(employeeRequestRepository));
        _eventDispatcher = eventDispatcher ?? throw new ArgumentNullException(nameof(eventDispatcher));
    }

    public async Task<EmployeeRequestCandidateDetailsDto?> Handle(AssignCandidateToRequestCommand command, CancellationToken cancellationToken)
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

        await _eventDispatcher.DispatchAsync(employeeRequest.DomainEvents);
        employeeRequest.ClearDomainEvents();

        return employeeRequestCandidate.MapToDto();
    }
}

public class AssignCandidateToRequestCommand : IRequest<EmployeeRequestCandidateDetailsDto?>
{
    public Guid EmployeeRequestId { get; init; }
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required string PersonalId { get; init; }
    public required Gender Gender { get; init; }
    public required DateTime DateOfBirth { get; init; }
}