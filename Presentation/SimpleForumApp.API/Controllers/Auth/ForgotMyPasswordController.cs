using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimpleForumApp.API.Core;
using Queries = SimpleForumApp.Application.CQRS.Auth.ForgotMyPassword.Queries;

namespace SimpleForumApp.API.Controllers.Auth
{
    [Route("api/auth/forgot-my-password")]
    [ApiController]
    public class ForgotMyPasswordController : BaseController
    {
        public ForgotMyPasswordController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("send-mail-for-password-reset")]
        public async Task<IActionResult> SendMailForPasswordResetAsync([FromQuery] Queries.SendMailForPasswordReset.Query query)
            => await ExecuteAsync(query);
    }
}
