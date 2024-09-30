using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimpleForumApp.API.Core;

using Queries = SimpleForumApp.Application.CQRS.Home.Queries;
using Commands = SimpleForumApp.Application.CQRS.Home.Commands;
using Microsoft.AspNetCore.Authorization;

namespace SimpleForumApp.API.Controllers
{
    [Route("api/home")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "simple-forum-app")]
    public class HomeController : BaseController
    {
        public HomeController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("agenda")]
        public async Task<IActionResult> GetAgendaAsync([FromQuery] Queries.GetAgenda.Query query)
            => await ExecuteAsync(query);

        [HttpGet("titles")]
        public async Task<IActionResult> GetTitlesAsync([FromQuery] Queries.GetTitles.Query query)
            => await ExecuteAsync(query);

        [Authorize]
        [HttpPut("add-action-to-title")]
        public async Task<IActionResult> AddActionToTitleAsync([FromBody] Commands.AddActionToTitle.Command command)
            => await ExecuteAsync(command);
    }
}
