using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleForumApp.Application.UnitOfWork;

namespace SimpleForumApp.API.Controllers
{
    [Route("api/test")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> SayHello([FromQuery] Application.CQRS.Operations.Test.Query query)
            => Ok(await _mediator.Send(query));
    }
}
