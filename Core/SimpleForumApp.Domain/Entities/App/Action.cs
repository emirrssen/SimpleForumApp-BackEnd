using SimpleForumApp.Domain.Entities.Core;

namespace SimpleForumApp.Domain.Entities.App
{
    public class Action : EntityWithId
    {
        public long StatusId { get; set; }
        public string Name { get; set; }

        public Status Status { get; set; }
        public ICollection<TitleAction> Titles { get; set; }
        public ICollection<EntryAction> Entries { get; set; }
    }
}
