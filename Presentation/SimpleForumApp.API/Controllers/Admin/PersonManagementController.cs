using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleForumApp.API.Core;
using SimpleForumApp.Domain.Results;

namespace SimpleForumApp.API.Controllers.Admin
{
    [Route("api/admin/person-management")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "simple-forum-app")]
    public class PersonManagementController : BaseController
    {
        public PersonManagementController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("all-detail-test")]
        public async Task<IActionResult> GetAllPersonDetailsAsync([FromQuery] Application.CQRS.Admin.PersonManagement.Queries.GetAllPersonDetails.Query query)
            => await ExecuteAsync(query);
    }
}