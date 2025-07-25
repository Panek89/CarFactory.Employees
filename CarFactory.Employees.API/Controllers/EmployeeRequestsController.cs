using CarFactory.Employees.Application.Features.EmployeeRequests.Commands;
using CarFactory.Employees.Application.Features.EmployeeRequests.Queries;
using CarFactory.Employees.Contracts.DTOs.EmployeeRequests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarFactory.Employees.API.Controllers
{
    [Route("api/employee-requests")]
    [Authorize]
    [ApiController]
    public class EmployeeRequestsController : ControllerBase
    {
        private readonly ISender _mediator;

        public EmployeeRequestsController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<EmployeeRequestDetailsDto>> GetAll(CancellationToken token)
        {
            return await _mediator.Send(new GetEmployeeRequestsQuery(), token);
        }

        [HttpGet("actual-requests-details")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<EmployeeRequestDetailsDto>> ActualRequestsDetails(CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetActualRequestesDetailsQuery(), cancellationToken);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EmployeeRequestDetailsDto>> Get(Guid id, CancellationToken cancellationToken)
        {
            var dto = await _mediator.Send(new GetEmployeeRequestByIdQuery() { Id = id }, cancellationToken);
            if (dto is null)
            {
                return NotFound();
            }

            return Ok(dto);
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Guid>> Register(RegisterEmployeeRequestCommand command, CancellationToken token)
        {
            var id = await _mediator.Send(command, token);

            return CreatedAtAction(nameof(Get), new { id }, null);
        }

        [HttpPost("assign-candidate")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Guid>> AssignCandidate(AssignCandidateToRequestCommand command, CancellationToken token)
        {
            var candidateId = await _mediator.Send(command, token);
            if (candidateId is null)
            {
                return NotFound();
            }

            return Created();
        }
    }
}
