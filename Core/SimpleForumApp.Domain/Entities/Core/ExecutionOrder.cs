using SimpleForumApp.Domain.Entities.Auth;

namespace SimpleForumApp.Domain.Entities.Core
{
    public class ExecutionOrder : EntityWithId
    {
        public string Name { get; set; }

        public ICollection<ClaimBusinessRule> ClaimBusinessRules { get; set; }
    }
}
