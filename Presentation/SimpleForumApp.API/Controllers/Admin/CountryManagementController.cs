using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleForumApp.API.Core;
using Queries = SimpleForumApp.Application.CQRS.Admin.CountryManagement.Queries;

namespace SimpleForumApp.API.Controllers.Admin
{
    [Route("api/admin/country-management")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "simple-forum-app")]

    public class CountryManagementController : BaseController
    {
        public CountryManagementController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetCountriesAsync([FromQuery] Queries.GetCountries.Query query)
            => await ExecuteAsync(query);
    }
}
