using SimpleForumApp.API.ClaimBusinessRules.Abstraction;
using SimpleForumApp.Domain.DTOs.Auth.UserDtos;
using System.Reflection;

namespace SimpleForumApp.API.ClaimBusinessRules.Helpers
{
    public class ClaimBusinessRuleReaderHelper
    {
        public static IList<ClaimBusinessRuleInfo> GetClaimBusinessRulesInfo()
        {
            List<ClaimBusinessRuleInfo> claimBusinessRulesInfo = new();

            var assembly = Assembly.GetExecutingAssembly();
            var claimBusinessRules = assembly.GetTypes().Where(x => x.IsAssignableTo(typeof(IClaimBusinessRule)) && !x.IsAbstract).ToList();

            foreach ( var claimBusinessRule in claimBusinessRules)
            {
                var currentRule = Activator.CreateInstance(claimBusinessRule);
                var codePropertyInfo = claimBusinessRule.GetProperty(nameof(ClaimBusinessRuleInfo.Code));
                var executionOrderPropertyInfo = claimBusinessRule.GetProperty(nameof(ClaimBusinessRuleInfo.ExecutionOrder));
                var priorityPropertyInfo = claimBusinessRule.GetProperty(nameof(ClaimBusinessRuleInfo.Priority));

                var codePropertyValue = codePropertyInfo?.GetValue(currentRule);
                var executionOrderPropertyValue = executionOrderPropertyInfo?.GetValue(currentRule);
                var priorityPropertyValue = priorityPropertyInfo?.GetValue(currentRule);

                // For execution

                //var currentExecuteMethod = claimBusinessRule.GetMethod("Execute");
                //var result = currentExecuteMethod.Invoke(currentRule, new object[] { new UserFullDetail() { CountryId = 185 } });

                claimBusinessRulesInfo.Add(new()
                {
                    Code = (string)codePropertyValue,
                    ExecutionOrder = (ExecutionOrder)executionOrderPropertyValue,
                    Priority = (int)priorityPropertyValue

                });
            }

            return claimBusinessRulesInfo;
        }
    }
}
