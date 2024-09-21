using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleForumApp.API.Core;
using Queries = SimpleForumApp.Application.CQRS.Admin.StatusManagement.Queries;

namespace SimpleForumApp.API.Controllers.Admin
{
    [Route("api/admin/status-management")]
    [ApiController]
    public class StatusManagementController : BaseController
    {
        public StatusManagementController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] Queries.GetAll.Query query)
            => await ExecuteAsync(query);
    }
}
