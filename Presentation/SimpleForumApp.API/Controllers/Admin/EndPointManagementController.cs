using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimpleForumApp.API.Core;
using Queries = SimpleForumApp.Application.CQRS.Admin.EndPointManagement.Queries;

namespace SimpleForumApp.API.Controllers.Admin
{
    [Route("api/admin/end-point-management")]
    [ApiController]
    public class EndPointManagementController : BaseController
    {
        public EndPointManagementController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetDetailsByStatusAsync([FromQuery] Queries.GetAllByStatus.Query query)
            => await ExecuteAsync(query);
    }
}
