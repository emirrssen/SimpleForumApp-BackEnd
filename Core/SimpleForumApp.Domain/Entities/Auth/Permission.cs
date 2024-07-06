using SimpleForumApp.Domain.Entities.App;
using SimpleForumApp.Domain.Entities.Core;

namespace SimpleForumApp.Domain.Entities.Auth
{
    public class Permission : Entity
    {
        public long StatusId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public Status Status { get; set; } = null!;
        public ICollection<RolePermission> Roles { get; set; }
        public ICollection<EndPointPermission> EndPoints { get; set; }
    }
}
