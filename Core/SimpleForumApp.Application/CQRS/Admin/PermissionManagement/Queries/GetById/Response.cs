namespace SimpleForumApp.Application.CQRS.Admin.PermissionManagement.Queries.GetById
{
    public class Response
    {
        public long Id { get; set; }
        public long StatusId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
