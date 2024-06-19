using SimpleForumApp.Domain.Entities.Auth;
using SimpleForumApp.Domain.Entities.Core;

namespace SimpleForumApp.Domain.Entities.App
{
    public class Group : Entity
    {
        public long StatusId { get; set; }
        public long OwnerUserId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? GroupImage { get; set; }
        public string? BackgroundImage { get; set; }

        public Status Status { get; set; }
        public User User { get; set; }
        public ICollection<GroupMember> GroupMembers { get; set; }
        public ICollection<Author> Authors { get; set; }
    }
}
