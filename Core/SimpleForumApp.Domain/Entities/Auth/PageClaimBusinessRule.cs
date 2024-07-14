using SimpleForumApp.Domain.Entities.Core;

namespace SimpleForumApp.Domain.Entities.Auth
{
    public class PageClaimBusinessRule : EntityWithStatus
    {
        public long PageId { get; set; }
        public long ClaimBusinessRuleId { get; set; }
        public long StatusId { get; set; }

        public Page Page { get; set; }
        public ClaimBusinessRule ClaimBusinessRule { get; set; }
        public Status Status { get; set; }
    }
}
