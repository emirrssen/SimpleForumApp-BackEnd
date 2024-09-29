namespace SimpleForumApp.Domain.DTOs.Auth.RolePermission
{
    public class RolePermissionDetail
    {
        public long RoleId { get; set; }
        public long PermissionId { get; set; }
        public long StatusId { get; set; }
        public string RoleName { get; set; }
        public string PermissionName { get; set; }
        public string StatusName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
