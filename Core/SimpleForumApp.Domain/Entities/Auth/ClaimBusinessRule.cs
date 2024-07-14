using SimpleForumApp.Domain.Entities.Core;

namespace SimpleForumApp.Domain.Entities.Auth
{
    public class ClaimBusinessRule : Entity
    {
        public long StatusId { get; set; }
        public long ExecutionOrderId { get; set; }
        public string Code { get; set; }
        public int Priority { get; set; }

        public Status Status { get; set; }
        public ExecutionOrder ExecutionOrder { get; set; }
        public ICollection<EndPointClaimBusinessRule> EndPoints { get; set; }
        public ICollection<PageClaimBusinessRule> Pages { get; set; }

    }
}
