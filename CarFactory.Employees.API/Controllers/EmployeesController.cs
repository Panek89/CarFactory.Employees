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

        [HttpGet("{id}")]
        public async Task<EmployeeDetails> EmployeeDetails(Guid id)
        {
            return await _mediator.Send(new GetEmployeeDetailsQuery() { Id = id });
        }
    }

}
