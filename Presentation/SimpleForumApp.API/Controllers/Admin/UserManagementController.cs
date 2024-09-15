using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimpleForumApp.API.Core;
using Queries = SimpleForumApp.Application.CQRS.Admin.UserManagement.Queries;

namespace SimpleForumApp.API.Controllers.Admin
{
    [Route("api/admin/user-management")]
    [ApiController]
    public class UserManagementController : BaseController
    {
        public UserManagementController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("users-to-list")]
        public async Task<IActionResult> GetUsersToListAsync([FromQuery] Queries.GetAllUserForList.Query query)
            => await ExecuteAsync(query);
    }
}
