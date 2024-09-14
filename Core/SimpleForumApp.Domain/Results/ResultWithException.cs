using System.Net;

namespace SimpleForumApp.Domain.Results
{
    public class ResultWithException
    {
        public string? Title { get; set; }
        public List<string>? Errors { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
