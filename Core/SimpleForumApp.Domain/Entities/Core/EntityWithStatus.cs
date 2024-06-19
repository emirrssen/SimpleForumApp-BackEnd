namespace SimpleForumApp.Domain.Entities.Core
{
    public class EntityWithStatus
    {
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime DeletedDate { get; set; }
    }
}
