using SimpleForumApp.Domain.Entities.Traceability;

namespace SimpleForumApp.Domain.Entities.Core
{
    public class ActionType : EntityWithId
    {
        public string Name { get; set; }

        public ICollection<EndPoint> EndPoints { get; set; }
    }
}
