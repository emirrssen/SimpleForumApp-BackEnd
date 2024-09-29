namespace SimpleForumApp.Application.CQRS.Admin.PermissionMatchingManagement.ForRoles.Queries.GetMatchingsByRoleId
{
    public class Response
    {
        public long PermissionId { get; set; }
        public long StatusId { get; set; }
        public string PermissionName { get; set; }
        public string CreatedDate { get; set; }
    }
}
