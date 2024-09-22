namespace SimpleForumApp.Application.CQRS.Admin.EndPointManagement.Queries.GetAllByStatus
{
    public class Response
    {
        public string ControllerName { get; set; }
        public EndPoint[] EndPoints { get; set; }
    }

    public class EndPoint
    {
        public long Id { get; set; }
        public string ActionTypeName { get; set; }
        public string MethodName { get; set; }
        public string EndPointRoute { get; set; }
        public string IsUse { get; set; }
        public string IsActive { get; set; }
    }
}
