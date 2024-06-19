using SimpleForumApp.Domain.Entities.Core;

namespace SimpleForumApp.Domain.Entities.App
{
    public class Title : Entity
    {
        public long StatusId { get; set; }
        public long AuthorId { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        public Status Status { get; set; }
        public Author Author { get; set; }
        public ICollection<Entry> Entries { get; set; }
        public ICollection<TitleAction> Actions { get; set; }
    }
}
