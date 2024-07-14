using SimpleForumApp.Domain.Entities.Core;
using SimpleForumApp.Domain.Entities.Traceability;

namespace SimpleForumApp.Domain.Entities.Auth
{
    public class EndPointClaimBusinessRule : EntityWithStatus
    {
        public long EndPointId { get; set; }
        public long ClaimBusinessRuleId { get; set; }
        public long StatusId { get; set; }

        public EndPoint EndPoint { get; set; }
        public ClaimBusinessRule ClaimBusinessRule { get; set; }
        public Status Status { get; set; }
    }
}
