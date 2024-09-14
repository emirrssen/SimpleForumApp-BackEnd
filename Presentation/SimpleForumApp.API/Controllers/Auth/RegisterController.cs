using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimpleForumApp.API.Core;
using Commands = SimpleForumApp.Application.CQRS.Auth.Register.Commands;

namespace SimpleForumApp.API.Controllers.Auth
{
    [Route("api/auth/register")]
    [ApiController]
    public class RegisterController : BaseController
    {
        public RegisterController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync([FromBody] Commands.Register.Command command)
            => await ExecuteAsync(command);
    }
}
