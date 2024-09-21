using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimpleForumApp.API.Core;
using Queries = SimpleForumApp.Application.CQRS.Admin.RoleManagement.Queries;

namespace SimpleForumApp.API.Controllers.Admin
{
    [Route("api/admin/role-management")]
    [ApiController]
    public class RoleManagementController : BaseController
    {
        public RoleManagementController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDetailsByStatusIdAsync([FromQuery] Queries.GetAll.Query query)
            => await ExecuteAsync(query);
    }
}
