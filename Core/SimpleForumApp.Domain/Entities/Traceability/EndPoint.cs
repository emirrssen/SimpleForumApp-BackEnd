using SimpleForumApp.Domain.Entities.Auth;
using SimpleForumApp.Domain.Entities.Core;

namespace SimpleForumApp.Domain.Entities.Traceability
{
    public class EndPoint : EntityWithId
    {
        public long ActionTypeId { get; set; }
        public string ControllerName { get; set; } = null!;
        public string MethodName { get; set; } = null!;
        public string EndPointRoute { get; set; } = null!;
        public bool IsUse { get; set; }
        public bool IsActive { get; set; }

        public ActionType ActionType { get; set; }
        public ICollection<EndPointActivity> EndPointActivities { get; set; }
        public ICollection<EndPointPermission> Permissions { get; set; }
        public ICollection<EndPointClaimBusinessRule> ClaimBusinessRules { get; set; }
    }
}
