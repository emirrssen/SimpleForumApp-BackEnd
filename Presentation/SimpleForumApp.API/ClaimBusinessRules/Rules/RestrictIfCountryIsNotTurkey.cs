using SimpleForumApp.API.ClaimBusinessRules.Abstraction;
using SimpleForumApp.Domain.DTOs.Auth.UserDtos;

namespace SimpleForumApp.API.ClaimBusinessRules.Rules
{
    public class RestrictIfCountryIsNotTurkey : ClaimBusinessRuleBase
    {
        public override string Code => "RESTRICT_IF_USERS_COUNTRY_IS_NOT_TURKEY";
        public override int Priority => 1;
        public override ExecutionOrder ExecutionOrder => ExecutionOrder.BeforeExecution;

        public override Task<bool> Execute(UserFullDetail user) => Task.FromResult(user.CountryId == 186);
    }
}
