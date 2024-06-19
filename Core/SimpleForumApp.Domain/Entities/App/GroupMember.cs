using SimpleForumApp.Domain.Entities.Auth;
using SimpleForumApp.Domain.Entities.Core;

namespace SimpleForumApp.Domain.Entities.App
{
    public class GroupMember : EntityWithStatus
    {
        public long GroupId { get; set; }
        public long UserId { get; set; }
        public long StatusId { get; set; }

        public Status Status { get; set; }
        public User User { get; set; }
        public Group Group { get; set; }
    }
}
