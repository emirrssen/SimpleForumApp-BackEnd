using SimpleForumApp.Domain.Entities.Auth;

namespace SimpleForumApp.Domain.Entities.Traceability
{
    public class EndPointUserActivity
    {
        public long EndPointActivityId { get; set; }
        public long UserId { get; set; }

        public EndPointActivity EndPointActivity { get; set; }
        public User User { get; set; }
    }
}
