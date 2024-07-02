using SimpleForumApp.Domain.Entities.Auth;

namespace SimpleForumApp.Domain.Entities.Traceability
{
    public class EndPointGuestActivity
    {
        public long EndPointActivityId { get; set; }
        public long GuestId { get; set; }

        public EndPointActivity EndPointActivity { get; set; }
        public Guest Guest { get; set; }
    }
}
