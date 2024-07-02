using SimpleForumApp.Domain.Entities.App;
using SimpleForumApp.Domain.Entities.Core;
using SimpleForumApp.Domain.Entities.Traceability;

namespace SimpleForumApp.Domain.Entities.Auth
{
    public class EndPointPermission : EntityWithStatus
    {
        public long EndPointId { get; set; }
        public long PermissionId { get; set; }
        public long StatusId { get; set; }

        public EndPoint EndPoint { get; set; }
        public Permission Permission { get; set; }
        public Status Status { get; set; }
    }
}
