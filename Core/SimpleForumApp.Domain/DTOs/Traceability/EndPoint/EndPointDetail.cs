using SimpleForumApp.Domain.Entities;

namespace SimpleForumApp.Domain.DTOs.Traceability.EndPoint
{
    public class EndPointDetail : EntityWithId
    {
        public string ActionTypeName { get; set; }
        public string ControllerName { get; set; }
        public string MethodName { get; set; }
        public string Route { get; set; }
        public bool IsUse { get; set; }
        public bool IsActive { get; set; }
        public string? Description { get; set; }
    }
}
