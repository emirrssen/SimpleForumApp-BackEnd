using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimpleForumApp.API.Core;
using Queries = SimpleForumApp.Application.CQRS.Admin.PermissionManagement.Queries;
using Commands = SimpleForumApp.Application.CQRS.Admin.PermissionManagement.Commands;

namespace SimpleForumApp.API.Controllers.Admin
{
    [Route("api/admin/permission-management")]
    [ApiController]
    public class PermissionManagementController : BaseController
    {
        public PermissionManagementController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetPermissionsAsync([FromQuery] Queries.GetAllPermissions.Query query)
            => await ExecuteAsync(query);

        [HttpGet("by-id")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] Queries.GetById.Query query)
            => await ExecuteAsync(query);

        [HttpPost]
        public async Task<IActionResult> InsertAsync([FromBody] Commands.Insert.Command command)
            => await ExecuteAsync(command);

        [HttpPut]
        public async Task<IActionResult> UpdateByIdAsync([FromBody] Commands.UpdateById.Command command)
            => await ExecuteAsync(command);
    }
}
