using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimpleForumApp.API.Core;
using Microsoft.AspNetCore.Authorization;

using Queries = SimpleForumApp.Application.CQRS.Admin.UserManagement.Queries;
using Commands = SimpleForumApp.Application.CQRS.Admin.UserManagement.Commands;

using QueriesForMatching = SimpleForumApp.Application.CQRS.Admin.UserManagement.RoleMatchingManagement.Queries;

namespace SimpleForumApp.API.Controllers.Admin
{
    [Route("api/admin/user-management")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = "simple-forum-app")]
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

        [HttpPut]
        public async Task<IActionResult> UpdateByIdAsync([FromBody] Commands.UpdateById.Command command)
            => await ExecuteAsync(command);

        [HttpPost]
        public async Task<IActionResult> InsertAsync([FromBody] Commands.Insert.Command command)
            => await ExecuteAsync(command);

        [HttpGet("roles-to-select")]
        public async Task<IActionResult> GetRolesToSelectAsync([FromQuery] QueriesForMatching.GetRolesToSelect.Query query)
            => await ExecuteAsync(query);

        [HttpGet("role-matchings")]
        public async Task<IActionResult> GetRoleMatchings([FromQuery] QueriesForMatching.GetRoleMatchings.Query query)
            => await ExecuteAsync(query);
    }
}
