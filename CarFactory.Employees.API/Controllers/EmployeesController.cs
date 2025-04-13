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
    }

}
