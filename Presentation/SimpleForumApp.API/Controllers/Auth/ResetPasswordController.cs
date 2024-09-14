using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimpleForumApp.API.Core;
using Commands = SimpleForumApp.Application.CQRS.Auth.ResetPassword.Commands;

namespace SimpleForumApp.API.Controllers.Auth
{
    [Route("api/auth/reset-password")]
    [ApiController]
    public class ResetPasswordController : BaseController
    {
        public ResetPasswordController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("validate-token")]
        public async Task<IActionResult> ValidateResetPasswordTokenAsync([FromBody] Commands.VerifyPasswordToken.Command command)
            => await ExecuteAsync(command);

        [HttpPost("reset")]
        public async Task<IActionResult> ResetPasswordAsync([FromBody] Commands.ResetPassword.Command command)
            => await ExecuteAsync(command);
    }
}
