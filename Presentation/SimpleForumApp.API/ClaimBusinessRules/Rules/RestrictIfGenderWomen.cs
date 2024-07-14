using SimpleForumApp.API.ClaimBusinessRules.Abstraction;
using SimpleForumApp.Domain.DTOs.Auth.UserDtos;

namespace SimpleForumApp.API.ClaimBusinessRules.Rules
{
    public class RestrictIfGenderWomen : ClaimBusinessRuleBase
    {
        public override string Code => "RESTRICT_IF_GENDER_IS_WOMEN";
        public override ExecutionOrder ExecutionOrder => ExecutionOrder.BeforeExecution;
        public override int Priority => 2;

        public override Task<bool> Execute(UserFullDetail user) => Task.FromResult(user.GenderId != 2);
    }
}
