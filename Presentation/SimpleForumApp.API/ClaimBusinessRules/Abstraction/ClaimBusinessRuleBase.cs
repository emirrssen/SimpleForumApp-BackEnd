using SimpleForumApp.Domain.DTOs.Auth.UserDtos;

namespace SimpleForumApp.API.ClaimBusinessRules.Abstraction
{
    public abstract class ClaimBusinessRuleBase : IClaimBusinessRule, IDisposable
    {
        public virtual int Priority => 0;
        public virtual ExecutionOrder ExecutionOrder => ExecutionOrder.None;
        public virtual string Code => "";

        public void Dispose() => GC.SuppressFinalize(this);
        public virtual Task<bool> Execute(UserFullDetail user) => Task.FromResult(true);
    }
}
