using SimpleForumApp.Domain.Entities.Core;

namespace SimpleForumApp.Domain.Entities.Traceability
{
    public class ActionType : EntityWithId
    {
        public string Name { get; set; }

        public ICollection<EndPoint> EndPoints { get; set; }
    }
}
