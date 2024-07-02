using SimpleForumApp.Domain.Entities.App;
using SimpleForumApp.Domain.Entities.Core;

namespace SimpleForumApp.Domain.Entities.Auth
{
    public class RolePermission : EntityWithStatus
    {
        public long RoleId { get; set; }
        public long PermissionId { get; set; }
        public long StatusId { get; set; }

        public Status Status { get; set; }
        public Role Role { get; set; }
        public Permission Permission { get; set; }
    }
}
