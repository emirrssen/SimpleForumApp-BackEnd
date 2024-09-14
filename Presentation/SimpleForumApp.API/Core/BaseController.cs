using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimpleForumApp.Domain.Results;

namespace SimpleForumApp.API.Core
{
    public abstract class BaseController : ControllerBase
    {
        protected IMediator Mediator { get; }

        protected BaseController(IMediator mediator) 
            => Mediator = mediator;

        [NonAction]
        protected async Task<IActionResult> ExecuteAsync(IRequest<Result> request)
        {
            var result = await Mediator.Send(request);
            return Ok(result);
        }

        [NonAction]
        protected async Task<IActionResult> ExecuteAsync<TResponse>(IRequest<ResultWithData<TResponse>> request)
        {
            var result = await Mediator.Send(request);
            return Ok(result);
        }
    }
}
