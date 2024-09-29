namespace SimpleForumApp.Application.CQRS.Admin.EndPointManagement.Queries.GetDetailsById
{
    public class Response
    {
        public long Id { get; set; }
        public string ActionTypeName { get; set; }
        public string ControllerName { get; set; }
        public string MethodName { get; set; }
        public string Route { get; set; }
        public bool IsUse { get; set; }
        public bool IsActive { get; set; }
        public string? Description { get; set; }
    }
}
