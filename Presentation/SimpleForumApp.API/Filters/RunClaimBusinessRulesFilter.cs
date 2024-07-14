using Microsoft.AspNetCore.Mvc.Filters;
using SimpleForumApp.API.ClaimBusinessRules.Helpers;

namespace SimpleForumApp.API.Filters
{
    public class RunClaimBusinessRulesFilter : IAsyncActionFilter
    {
        public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var claimBusinessRules = ClaimBusinessRuleReaderHelper.GetClaimBusinessRulesInfo();

            return Task.CompletedTask;
        }
    }
}
