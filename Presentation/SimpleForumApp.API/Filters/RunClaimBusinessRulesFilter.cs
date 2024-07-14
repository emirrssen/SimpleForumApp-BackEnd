using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SimpleForumApp.API.ClaimBusinessRules;
using SimpleForumApp.API.ClaimBusinessRules.Abstraction;
using SimpleForumApp.Application.Helpers;
using SimpleForumApp.Application.UnitOfWork;
using SimpleForumApp.Domain.Entities.Auth;
using System.Reflection;

namespace SimpleForumApp.API.Filters
{
    public class RunClaimBusinessRulesFilter : IAsyncActionFilter
    {
        private readonly IUnitOfWork _unitOfWork;

        public RunClaimBusinessRulesFilter(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var userName = context.HttpContext.User.Identity?.Name;

            if (!string.IsNullOrEmpty(userName))
            {
                var user = await _unitOfWork.Context.Identity.UserService.GetUserFullDetailByUserNameAsync(userName);

                List<IClaimBusinessRule> claimBusinessRulesToRunBeforeExecution = new();
                List<IClaimBusinessRule> claimBusinessRulesToRunAfterExecution = new();

                var contextActionType = context.HttpContext.Request.Method;
                var endPointActionType = ActionTypeConverterHelper.ConvertActionType(contextActionType);
                var endPointRoute = context.HttpContext.Request.Path.Value;

                var endPoint = await _unitOfWork.Context.Traceability.EndPointRepository.GetByRouteAndActionTypeId(endPointRoute.Substring(1), endPointActionType);
                var endPointClaimBusinessRules = await _unitOfWork.Context.Auth.EndPointClaimBusinessRuleRepository.GetDetailsByEndPointIdAsync(endPoint.Id);
            
                var assembly = Assembly.GetExecutingAssembly();
                var claimBusinessRules = assembly.GetTypes().Where(x => x.IsAssignableTo(typeof(IClaimBusinessRule)) && !x.IsAbstract).ToList();

                foreach (var item in claimBusinessRules)
                {
                    var currentRule = (IClaimBusinessRule)Activator.CreateInstance(item)!;

                    if (endPointClaimBusinessRules.Any(x => x.Code == currentRule.Code))
                    {
                        if (currentRule.ExecutionOrder == ExecutionOrder.BeforeExecution)
                            claimBusinessRulesToRunBeforeExecution.Add(currentRule);

                        if (currentRule.ExecutionOrder == ExecutionOrder.AfterExecution)
                            claimBusinessRulesToRunAfterExecution.Add(currentRule);
                    }
                }

                claimBusinessRulesToRunBeforeExecution.OrderBy(x => x.Priority);
                claimBusinessRulesToRunAfterExecution.OrderBy(x => x.Priority);

                foreach (var item in claimBusinessRulesToRunBeforeExecution)
                {
                    var ruleResult = await item.Execute(user);

                    if (!ruleResult)
                    {
                        context.Result = new UnauthorizedResult();
                        claimBusinessRulesToRunAfterExecution.ForEach(x => x.Dispose());
                        break;
                    }
                }

                if (context.Result?.GetType() != typeof(UnauthorizedResult))
                    await next();

                foreach (var item in claimBusinessRulesToRunAfterExecution)
                {
                    var ruleResult = await item.Execute(user);

                    if (!ruleResult)
                    {
                        context.Result = new UnauthorizedResult();
                        claimBusinessRulesToRunAfterExecution.ForEach(x => x.Dispose());
                        break;
                    }
                }

                return;
            }

            await next();
        }
    }
}
