using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimpleForumApp.API.Core;

using Queries = SimpleForumApp.Application.CQRS.Home.Queries;

namespace SimpleForumApp.API.Controllers
{
    [Route("api/home")]
    [ApiController]
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
    }
}
