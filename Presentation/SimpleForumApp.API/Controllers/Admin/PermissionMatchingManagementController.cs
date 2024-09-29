using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleForumApp.API.Core;

using QueriesForEndPoints = SimpleForumApp.Application.CQRS.Admin.PermissionMatchingManagement.ForEndPoints.Queries;
using CommandsForEndPoints = SimpleForumApp.Application.CQRS.Admin.PermissionMatchingManagement.ForEndPoints.Commands;

using QueriesForRoles = SimpleForumApp.Application.CQRS.Admin.PermissionMatchingManagement.ForRoles.Queries;
using CommandsForRoles = SimpleForumApp.Application.CQRS.Admin.PermissionMatchingManagement.ForRoles.Commands;

namespace SimpleForumApp.API.Controllers.Admin
{
    [Route("api/admin/permission-matching-management")]
    [ApiController]
    public class PermissionMatchingManagementController : BaseController
    {
        public PermissionMatchingManagementController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("permissions-unmatched-for-endpoints")]
        public async Task<IActionResult> GetUnmatchedPermissionsForEndPointsAsync([FromQuery] QueriesForEndPoints.GetUnmatchedPermissions.Query query)
            => await ExecuteAsync(query);

        [HttpGet("for-end-points-by-endpoint")]
        public async Task<IActionResult> GetPermissionMatchingsForEndPointsByEndPointIdAsync([FromQuery] QueriesForEndPoints.GetMatchingByEndPointId.Query query)
            => await ExecuteAsync(query);

        [HttpPost("insert-end-point-match")]
        public async Task<IActionResult> InsertEndPointMatchAsync([FromBody] CommandsForEndPoints.Insert.Command command)
            => await ExecuteAsync(command);

        [HttpPut("update-end-point-matches")]
        public async Task<IActionResult> UpdateEndPointMatchesAsync([FromBody] CommandsForEndPoints.BulkUpdate.Command command)
            => await ExecuteAsync(command);

        [HttpGet("permissions-unmatched-for-roles")]
        public async Task<IActionResult> GetUnmatchedPermissionsForRolesAsync([FromQuery] QueriesForRoles.GetUnmatchedPermissions.Query query)
            => await ExecuteAsync(query);

        [HttpGet("for-roles-by-role")]
        public async Task<IActionResult> GetPermissionMatchingsForRolesByRoleIdAsync([FromQuery] QueriesForRoles.GetMatchingsByRoleId.Query query)
            => await ExecuteAsync(query);

        [HttpPost("insert-role-match")]
        public async Task<IActionResult> InsertRoleMatchAsync([FromBody] CommandsForRoles.Insert.Command command)
            => await ExecuteAsync(command);

        [HttpPut("update-role-matches")]
        public async Task<IActionResult> UpdateRoleMatchesAsync([FromBody] CommandsForRoles.BulkUpdate.Command command)
            => await ExecuteAsync(command);
    }
}
