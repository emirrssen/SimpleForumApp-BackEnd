namespace SimpleForumApp.Domain.Entities.Traceability
{
    public class EndPointActivity : EntityWithId
    {
        public long EndPointId { get; set; }
        public string? Description { get; set; }
        public DateTime ActivityStartDate { get; set; }
        public DateTime ActivityEndDate { get; set; }

        public EndPoint EndPoint { get; set; }
    }
}
