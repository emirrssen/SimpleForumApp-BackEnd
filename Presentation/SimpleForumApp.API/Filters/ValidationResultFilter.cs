using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SimpleForumApp.Domain.Results;

namespace SimpleForumApp.API.Filters
{
    public class ValidationResultFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();

                var result = ResultFactory.FailResult(string.Join("\n", errors));

                context.Result = new ObjectResult(result);
            }
        }
    }
}
