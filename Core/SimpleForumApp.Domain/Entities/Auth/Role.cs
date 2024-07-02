using SimpleForumApp.Domain.Entities.App;
using SimpleForumApp.Domain.Entities.Core;

namespace SimpleForumApp.Domain.Entities.Auth
{
    public class Role : Entity
    {
        public long StatusId { get; set; }
        public string Name { get; set; }

        public Status Status { get; set; }
        public ICollection<RolePermission> Permissions { get; set; }
        public ICollection<UserRole> Users { get; set; }
    }
}
