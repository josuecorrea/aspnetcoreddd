using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Accounting.Service.Application.UseCases.Account.Create.Request;
using Project.Accounting.Service.Application.UseCases.Account.Create.Response;

namespace Project.Accounting.Service.Api.Controllers
{
    [ApiController]
    [Route("api")]
    public class PersonController : DefaultController
    {
        private readonly IMediator _mediator;

        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("v1/create")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreatePersonResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Create([FromBody] CreatePersonRequest request)
        {
            var result = await _mediator.Send(request);

            return await DefaultResponse(result, StatusCodes.Status201Created);
        }
    }
}