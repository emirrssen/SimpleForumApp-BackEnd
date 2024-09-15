using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimpleForumApp.API.Core;
using SimpleForumApp.Application.CQRS.Admin.StatusManagement.Queries.GetAll;
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

        [HttpGet("details-by-username")]
        public async Task<IActionResult> GetUserDetailByUserNameAsync([FromQuery] Queries.GetUserFullDetailByUsername.Query query)
            => await ExecuteAsync(query);

        [HttpGet("statuses")]
        public async Task<IActionResult> GetStatusesAsync([FromQuery] Query query)
            => await ExecuteAsync(query);
    }
}
