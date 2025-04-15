using CarFactory.Employees.Application.Features.EmployeeRequests.Commands;
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
        public async Task<IEnumerable<EmployeeRequestDto>> GetAll()
        {
            return await _mediator.Send(new GetEmployeeRequestsQuery());
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<EmployeeRequestDto> Register(RegisterEmployeeRequestCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
