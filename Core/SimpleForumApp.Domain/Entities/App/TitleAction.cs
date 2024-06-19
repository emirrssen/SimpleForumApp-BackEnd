using SimpleForumApp.Domain.Entities.Auth;
using SimpleForumApp.Domain.Entities.Core;

namespace SimpleForumApp.Domain.Entities.App
{
    public class TitleAction : EntityWithStatus
    {
        public long ActionId { get; set; }
        public long TitleId { get; set; }
        public long StatusId { get; set; }
        public long UserId { get; set; }

        public Status Status { get; set; }
        public Action Action { get; set; }
        public Title Title { get; set; }
        public User User{ get; set; }
    }
}
