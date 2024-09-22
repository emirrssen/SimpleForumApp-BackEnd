using SimpleForumApp.Domain.Entities;

namespace SimpleForumApp.Domain.DTOs.Traceability.EndPoint
{
    public class EndPointToList : EntityWithId
    {
        public string ActionMethodName { get; set; }
        public string ControllerName { get; set; }
        public string MethodName { get; set; }
        public string Route { get; set; }
        public bool IsUse { get; set; }
        public bool IsActive { get; set; }
    }
}
