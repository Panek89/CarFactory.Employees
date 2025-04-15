﻿using CarFactory.Employees.Application.Features.EmployeeRequests.Commands;
using CarFactory.Employees.Application.Features.EmployeeRequests.DTOs;
using CarFactory.Employees.Application.Features.EmployeeRequests.Queries;
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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<EmployeeRequestDto>> GetAll(CancellationToken token)
        {
            return await _mediator.Send(new GetEmployeeRequestsQuery(), token);
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<EmployeeRequestDto> Register(RegisterEmployeeRequestCommand command, CancellationToken token)
        {
            return await _mediator.Send(command, token);
        }

        [HttpPost("assign-candidate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EmployeeRequestCandidateDto>> AssignCandidate(AssignCandidateToRequestCommand command, CancellationToken token)
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
