using SimpleForumApp.Domain.Entities.Auth;
using SimpleForumApp.Domain.Entities.Core;

namespace SimpleForumApp.Domain.Entities.App
{
    public class Author : Entity
    {
        public long StatusId { get; set; }
        public long? UserId { get; set; }
        public long? GroupId { get; set; }
        public long AuthorTypeId { get; set; }

        public Status Status { get; set; }
        public User User { get; set; }
        public Group Group { get; set; }
        public AuthorType AuthorType { get; set; }
        public ICollection<Title> Titles { get; set; }
        public ICollection<Entry> Entries { get; set; }
    }
}
