namespace SimpleForumApp.Application.CQRS.Home.Queries.GetTitles
{
    public class Response
    {
        public long TitleId { get; set; }
        public long? ActionId { get; set; }
        public string TitleSubject { get; set; }
        public string TitleContent { get; set; }
        public string LikeNumber { get; set; }
        public string CreatedAuthor { get; set; }
        public string CreatedDate { get; set; }
    }
}
