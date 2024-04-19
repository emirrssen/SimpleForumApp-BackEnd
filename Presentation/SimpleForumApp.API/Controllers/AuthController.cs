using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SimpleForumApp.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _meditor;

        public AuthController(IMediator meditor)
        {
            _meditor = meditor;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] Application.CQRS.Auth.Commands.Register.Command command)
            => Ok(await _meditor.Send(command));

        [HttpGet("login")]
        public async Task<IActionResult> LoginAsync([FromQuery] Application.CQRS.Auth.Queries.Login.Query query)
            => Ok(await _meditor.Send(query));


        [HttpPost("login-with-refresh-token")]
        public async Task<IActionResult> LoginWithRefreshTokenAsync([FromBody] Application.CQRS.Auth.Queries.LoginWithRefreshToken.Query query)
            => Ok(await _meditor.Send(query));
    }
}
