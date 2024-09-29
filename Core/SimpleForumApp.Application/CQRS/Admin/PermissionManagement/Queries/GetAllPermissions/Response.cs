namespace SimpleForumApp.Application.CQRS.Admin.PermissionManagement.Queries.GetAllPermissions
{
    public class Response
    {
        public long Id { get; set; }
        public string StatusName { get; set; }
        public string Name { get; set; }
        public string CreatedDate { get; set; }
    }
}
