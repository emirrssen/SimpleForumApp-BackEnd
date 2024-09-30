using SimpleForumApp.Domain.Entities;

namespace SimpleForumApp.Domain.DTOs.App.Title
{
    public class TitlePreview
    {
        public long Id { get; set; }
        public long AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? AuthorProfileImage { get; set; }
        public int LikeNumber { get; set; }
    }
}
