using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimpleForumApp.API.Core;
using Queries = SimpleForumApp.Application.CQRS.Admin.PermissionManagement.Queries;

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
    }
}
