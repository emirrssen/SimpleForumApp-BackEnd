using SimpleForumApp.Domain.Entities.Core;

namespace SimpleForumApp.Domain.Entities.App
{
    public class AuthorType : Entity
    {
        public long StatusId { get; set; }
        public string Name { get; set; }

        public Status Status { get; set; }
        public ICollection<Author> Authors { get; set; }
    }
}
