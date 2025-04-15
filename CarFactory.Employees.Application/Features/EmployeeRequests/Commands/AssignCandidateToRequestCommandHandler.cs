using CarFactory.Employees.Application.Features.EmployeeRequests.DTOs;
using CarFactory.Employees.Infrastructure.Repositories;
using CarFactory.Employees.SharedLibrary.Enums;
using MediatR;

namespace CarFactory.Employees.Application.Features.EmployeeRequests.Commands;

public class AssignCandidateToRequestCommandHandler : IRequestHandler<AssignCandidateToRequestCommand, EmployeeRequestCandidateDto?>
{
    private readonly IEmployeeRequestRepository _employeeRequestRepository;
    private readonly IEmployeeRequestCandidateRepository _candidateRepository;

    public AssignCandidateToRequestCommandHandler(IEmployeeRequestRepository employeeRequestRepository, IEmployeeRequestCandidateRepository candidateRepository)
    {
        _employeeRequestRepository = employeeRequestRepository ?? throw new ArgumentNullException(nameof(employeeRequestRepository));
        _candidateRepository = candidateRepository ?? throw new ArgumentNullException(nameof(candidateRepository));
    }

    public async Task<EmployeeRequestCandidateDto?> Handle(AssignCandidateToRequestCommand command, CancellationToken cancellationToken)
    {
        var employeeRequest = await _employeeRequestRepository.GetByIdAsync(command.EmployeeRequestId, cancellationToken);
        if (employeeRequest is null)
        {
            return null;
        }

        var employeeRequestCandidate = command.MapToCandidate(employeeRequest);
        await _candidateRepository.AddAsync(employeeRequestCandidate, cancellationToken);
        await _candidateRepository.SaveChangesAsync(cancellationToken);

        return employeeRequestCandidate.MapToDto();
    }
}

public class AssignCandidateToRequestCommand : IRequest<EmployeeRequestCandidateDto?>
{
    public Guid EmployeeRequestId { get; init; }
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required string PersonalId { get; init; }
    public required int Age { get; init; }
    public readonly EmployeeCandidateStatus Status = EmployeeCandidateStatus.Candidate;
}