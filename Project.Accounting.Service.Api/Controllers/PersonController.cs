using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Accounting.Service.Application.UseCases.Account.Create.Request;

namespace Project.Accounting.Service.Api.Controllers
{
    [ApiController]
    [Route("api")]
    public class PersonController : Controller
    {
        private readonly IMediator _mediator;

        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("v1/create")]
        public async Task<IActionResult> Create([FromBody] CreatePersonRequest request)
        {
            var result = await _mediator.Send(request);

            if (result.Error)
            {
                return BadRequest();
            }

            return StatusCode(201, result);
        }
    }
}
