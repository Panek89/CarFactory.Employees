﻿using CarFactory.Employees.Application.Features.EmployeeRequests.Commands;
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

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Register(RegisterEmployeeRequestQuery query)
        {

            return Ok();
        }
    }
}
