using Microsoft.AspNetCore.Identity;
using SimpleForumApp.Domain.Entities.App;
using SimpleForumApp.Domain.Entities.Traceability;

namespace SimpleForumApp.Domain.Entities.Auth
{
    public class User : IdentityUser<long>
    {
        public long PersonId { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }

        public Person Person { get; set; }
        public ICollection<Group> Groups { get; set; }
        public ICollection<GroupMember> GroupMembers { get; set; }
        public ICollection<Author> Authors { get; set; }
        public ICollection<TitleAction> TitleActions { get; set; }
        public ICollection<EntryAction> EntryActions { get; set; }
        public ICollection<UserRole> Roles { get; set; }
        public ICollection<EndPointUserActivity> EndPointUserActivities { get; set; }
    }
}
