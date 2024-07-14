using SimpleForumApp.API.ClaimBusinessRules.Abstraction;
using SimpleForumApp.Domain.DTOs.Auth.UserDtos;

namespace SimpleForumApp.API.ClaimBusinessRules.Rules
{
    public class RestrictIfCountryIsNotTurkey : IClaimBusinessRule
    {
        public string Code => "RESTRICT_IF_USERS_COUNTRY_IS_NOT_TURKEY";
        public int Priority => 1;
        public ExecutionOrder ExecutionOrder => ExecutionOrder.BeforeExecution;

        public Task<bool> Execute(UserFullDetail user) => Task.FromResult(user.CountryId == 186);
    }
}
