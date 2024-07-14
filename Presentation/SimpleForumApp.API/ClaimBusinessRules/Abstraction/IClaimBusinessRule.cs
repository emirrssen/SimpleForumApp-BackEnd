using SimpleForumApp.Domain.DTOs.Auth.UserDtos;

namespace SimpleForumApp.API.ClaimBusinessRules.Abstraction
{
    public interface IClaimBusinessRule
    {
        public int Priority { get; }
        public ExecutionOrder ExecutionOrder { get; }
        public string Code { get; }

        Task<bool> Execute(UserFullDetail user);
    }
}
