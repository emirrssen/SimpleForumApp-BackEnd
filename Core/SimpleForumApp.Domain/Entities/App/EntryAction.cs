using SimpleForumApp.Domain.Entities.Auth;
using SimpleForumApp.Domain.Entities.Core;

namespace SimpleForumApp.Domain.Entities.App
{
    public class EntryAction : EntityWithStatus
    {
        public long StatusId { get; set; }
        public long ActionId { get; set; }
        public long EntryId { get; set; }
        public long UserId { get; set; }

        public Status Status { get; set; }
        public Action Action { get; set; }
        public Entry Entry { get; set; }
        public User User { get; set; }
    }
}
