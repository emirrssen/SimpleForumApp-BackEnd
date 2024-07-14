using SimpleForumApp.Domain.Entities.Auth;

namespace SimpleForumApp.Domain.Entities.Core
{
    public class Page : Entity
    {
        public long StatusId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }

        public Status Status { get; set; }
        public ICollection<PagePermission> Permissions { get; set; }
        public ICollection<PageClaimBusinessRule> ClaimBusinessRules { get; set; }
    }
}
