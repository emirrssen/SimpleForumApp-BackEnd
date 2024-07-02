using SimpleForumApp.Domain.Entities.App;
using SimpleForumApp.Domain.Entities.Core;

namespace SimpleForumApp.Domain.Entities.Auth
{
    public class UserRole : EntityWithStatus
    {
        public long UserId { get; set; }
        public long RoleId { get; set; }
        public long StatusId { get; set; }

        public Status Status { get; set; }
        public User User { get; set; }
        public Role Role { get; set; }
    }
}
