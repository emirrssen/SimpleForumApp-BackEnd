using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimpleForumApp.API.Core;

using Queries = SimpleForumApp.Application.CQRS.Home.Queries;
using Commands = SimpleForumApp.Application.CQRS.Home.Commands;
using Microsoft.AspNetCore.Authorization;
using SimpleForumApp.Domain.Results;

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

        [HttpGet("can-enter")]
        public async Task<IActionResult> CanEnterAsync()
            => await Task.FromResult(Ok(ResultFactory.SuccessResult()));

        [HttpGet("agenda")]
        public async Task<IActionResult> GetAgendaAsync([FromQuery] Queries.GetAgenda.Query query)
            => await ExecuteAsync(query);

        [HttpGet("titles")]
        public async Task<IActionResult> GetTitlesAsync([FromQuery] Queries.GetTitles.Query query)
            => await ExecuteAsync(query);

        [HttpGet("weekly-favourite-titles")]
        public async Task<IActionResult> GetWeeklyFavouriteTitlesAsync([FromQuery] Queries.GetWeeklyFavouriteTitles.Query query)
            => await ExecuteAsync(query);

        [HttpGet("weekly-favourite-groups")]
        public async Task<IActionResult> GetWeeklyFavouriteGroupsAsync([FromQuery] Queries.GetWeeklyFavouriteGroups.Query query)
            => await ExecuteAsync(query);

        [HttpGet("weekly-favourite-authors")]
        public async Task<IActionResult> GetWeeklyFavouriteAuthorsAsync([FromQuery] Queries.GetWeeklyFavouriteAuthors.Query query)
            => await ExecuteAsync(query);

        [Authorize]
        [HttpPut("add-action-to-title")]
        public async Task<IActionResult> AddActionToTitleAsync([FromBody] Commands.AddActionToTitle.Command command)
            => await ExecuteAsync(command);

        [Authorize]
        [HttpPost("add-entry-to-title")]
        public async Task<IActionResult> AddEntryToTitleAsync([FromBody] Commands.AddEntryToTitle.Command command)
            => await ExecuteAsync(command);
    }
}
