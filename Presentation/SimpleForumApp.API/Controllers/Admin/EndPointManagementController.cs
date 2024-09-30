using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimpleForumApp.API.Core;
using Queries = SimpleForumApp.Application.CQRS.Admin.EndPointManagement.Queries;
using Commands = SimpleForumApp.Application.CQRS.Admin.EndPointManagement.Commands;
using Microsoft.AspNetCore.Authorization;
using SimpleForumApp.Domain.Results;

namespace SimpleForumApp.API.Controllers.Admin
{
    [Route("api/admin/end-point-management")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "simple-forum-app")]
    public class EndPointManagementController : BaseController
    {
        public EndPointManagementController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetDetailsByStatusAsync([FromQuery] Queries.GetAllByStatus.Query query)
            => await ExecuteAsync(query);

        [HttpGet("by-id")]
        public async Task<IActionResult> GetDetailsByIdAsync([FromQuery] Queries.GetDetailsById.Query query)
            => await ExecuteAsync(query);

        [HttpPut]
        public async Task<IActionResult> UpdateByIdAsync([FromBody] Commands.UpdateById.Command command)
            => await ExecuteAsync(command);

        [HttpGet("can-enter")]
        public async Task<IActionResult> CanEnterAsync()
            => await Task.FromResult(Ok(ResultFactory.SuccessResult()));
    }
}
