using SimpleForumApp.Domain.Entities;

namespace SimpleForumApp.Domain.DTOs.Auth.EndPointPermission
{
    public class EndPointPermissionDetail
    {
        public long EndPointId { get; set; }
        public long StatusId { get; set; }
        public long PermissonId { get; set; }
        public string EndPointMethodName { get; set; }
        public string EndPointControllerName { get; set; }
        public string EndPointRoute { get; set; }
        public string StatusName { get; set; }
        public string PermissionName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
