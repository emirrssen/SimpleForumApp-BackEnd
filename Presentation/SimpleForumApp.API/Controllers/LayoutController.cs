using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleForumApp.API.Core;

using Commands = SimpleForumApp.Application.CQRS.Layout.Commands;

namespace SimpleForumApp.API.Controllers
{
    [Route("api/layout")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "simple-forum-app")]
    public class LayoutController : BaseController
    {
        public LayoutController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("create-title")]
        public async Task<IActionResult> CreateTitleAsync([FromBody] Commands.CreateTitle.Command command)
            => await ExecuteAsync(command);
    }
}
