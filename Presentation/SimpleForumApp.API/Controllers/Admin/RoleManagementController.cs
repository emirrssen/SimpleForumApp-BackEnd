using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimpleForumApp.API.Core;
using Queries = SimpleForumApp.Application.CQRS.Admin.RoleManagement.Queries;
using Commands = SimpleForumApp.Application.CQRS.Admin.RoleManagement.Commands;

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

        [HttpPost]
        public async Task<IActionResult> InsertAsync([FromBody] Commands.Insert.Command command)
            => await ExecuteAsync(command);
    }
}
