using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimpleForumApp.API.Core;
using Queries = SimpleForumApp.Application.CQRS.Auth.Login.Queries;

namespace SimpleForumApp.API.Controllers.Auth
{
    [Route("api/auth/login")]
    [ApiController]
    public class LoginController : BaseController
    {
        public LoginController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> LoginAsync([FromQuery] Queries.Login.Query query)
            => await ExecuteAsync(query);

        [HttpGet("with-refresh-token")]
        public async Task<IActionResult> LoginWithRefreshTokenAsync([FromQuery] Queries.LoginWithRefreshToken.Query query)
            => await ExecuteAsync(query);
    }
}
