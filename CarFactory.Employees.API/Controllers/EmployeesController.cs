using CarFactory.Employees.Application.Features.Employees.DTOs;
using CarFactory.Employees.Application.Features.Employees.Queries;
using CarFactory.Employees.Domain.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarFactory.Employees.API.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ISender _mediator;

        public EmployeesController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("details-by-id/{id}")]
        public async Task<ActionResult<EmployeeDetailsDto>> EmployeeDetails(Guid id, CancellationToken token)
        {
            var employeeDetails = await _mediator.Send(new GetEmployeeDetailsQuery() { Id = id }, token);

            if (employeeDetails is null)
            {
                return NotFound();
            }

            return Ok(employeeDetails);
        }

        [HttpGet("details-by-personalId/{personalId}")]
        public async Task<ActionResult<EmployeeDetailsDto>> EmployeeDetailsByPersonalId(PersonalId personalId, CancellationToken token)
        {
            var employeeDetails = await _mediator.Send(new GetEmployeeDetailsByPersonalIdQuery() { PersonalId = personalId }, token);

            if (employeeDetails is null)
            {
                return NotFound();
            }

            return Ok(employeeDetails);
        }
    }

}
