using CarFactory.Employees.Application.Features.EmployeeRequests.Commands;
using CarFactory.Employees.Application.Features.EmployeeRequests.Queries;
using CarFactory.Employees.Contracts.DTOs.EmployeeRequests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarFactory.Employees.API.Controllers
{
    [Route("api/employee-requests")]
    [ApiController]
    public class EmployeeRequestsController : ControllerBase
    {
        private readonly ISender _mediator;

        public EmployeeRequestsController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("actual-requests-details")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<EmployeeRequestDetailsDto>> ActualRequestsDetails(CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetActualRequestesDetailsQuery(), cancellationToken);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<EmployeeRequestDetailsDto>> GetAll(CancellationToken token)
        {
            return await _mediator.Send(new GetEmployeeRequestsQuery(), token);
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<EmployeeRequestDetailsDto> Register(RegisterEmployeeRequestCommand command, CancellationToken token)
        {
            return await _mediator.Send(command, token);
        }

        [HttpPost("assign-candidate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EmployeeRequestCandidateDetailsDto>> AssignCandidate(AssignCandidateToRequestCommand command, CancellationToken token)
        {
            var dto = await _mediator.Send(command, token);
            if (dto is null)
            {
                return NotFound();
            }

            return Ok(dto);
        }
    }
}
