namespace SimpleForumApp.Application.CQRS.Admin.UserManagement.RoleMatchingManagement.Queries.GetRoleMatchings
{
    public class Response
    {
        public long RoleId { get; set; }
        public long StatusId { get; set; }
        public string RoleName { get; set; }
        public string CreatedDate { get; set; }
    }
}
