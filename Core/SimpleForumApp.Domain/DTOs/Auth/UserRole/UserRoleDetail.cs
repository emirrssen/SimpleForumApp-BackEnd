namespace SimpleForumApp.Domain.DTOs.Auth.UserRole
{
    public class UserRoleDetail
    {
        public long UserId { get; set; }
        public long RoleId { get; set; }
        public long StatusId { get; set; }
        public string Username { get; set; }
        public string RoleName { get; set; }
        public string StatusName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
