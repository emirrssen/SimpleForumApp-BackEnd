using SimpleForumApp.Domain.Entities.Core;
using SimpleForumApp.Domain.Entities.Traceability;

namespace SimpleForumApp.Domain.Entities.Auth
{
    public class Guest : EntityWithId
    {
        public ICollection<EndPointGuestActivity> EndPointGuestActivities { get; set; }
    }
}
