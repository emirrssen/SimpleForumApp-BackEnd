using SimpleForumApp.Domain.Entities.Core;

namespace SimpleForumApp.Domain.Entities.Auth
{
    public class PagePermission : EntityWithStatus
    {
        public long PageId { get; set; }
        public long PermissionId { get; set; }
        public long StatusId { get; set; }

        public Page Page { get; set; }
        public Permission Permission { get; set; }
        public Status Status { get; set; }
    }
}
