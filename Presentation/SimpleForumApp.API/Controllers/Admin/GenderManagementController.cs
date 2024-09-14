using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimpleForumApp.API.Core;
using Queries = SimpleForumApp.Application.CQRS.Admin.GenderManagement.Queries;

namespace SimpleForumApp.API.Controllers.Admin
{
    [Route("api/admin/gender-management")]
    [ApiController]
    public class GenderManagementController : BaseController
    {
        public GenderManagementController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetGendersAsync([FromQuery] Queries.GetGenders.Query query)
            => await ExecuteAsync(query);
    }
}
