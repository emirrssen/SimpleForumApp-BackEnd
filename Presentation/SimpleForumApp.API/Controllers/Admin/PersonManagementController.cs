using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SimpleForumApp.API.Controllers.Admin
{
    [Route("api/admin/person-management")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "simple-forum-app")]
    public class PersonManagementController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PersonManagementController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all-detail-test")]
        public async Task<IActionResult> GetAllPersonDetailsAsync([FromQuery] Application.CQRS.Admin.PersonManagement.Queries.GetAllPersonDetails.Query query)
            => Ok(await _mediator.Send(query));
    }
}