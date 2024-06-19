using SimpleForumApp.Domain.Entities.Core;

namespace SimpleForumApp.Domain.Entities.App
{
    public class Entry : Entity
    {
        public long StatusId { get; set; }
        public long TitleId { get; set; }
        public long AuthorId { get; set; }
        public string Content { get; set; }

        public Status Status { get; set; }
        public Title Title { get; set; }
        public Author Author { get; set; }
        public ICollection<EntryAction> Actions { get; set; }
    }
}
