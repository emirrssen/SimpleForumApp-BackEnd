using SimpleForumApp.Domain.Entities;

namespace SimpleForumApp.Domain.DTOs.App.Title
{
    public class AgendaItem : EntityWithId
    {
        public int EntryNumbers { get; set; }
        public string TitleSubject { get; set; }
    }
}
