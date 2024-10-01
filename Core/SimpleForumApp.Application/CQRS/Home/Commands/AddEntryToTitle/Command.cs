using SimpleForumApp.Application.BaseStructures.MediatR.CommandAbstractions;

namespace SimpleForumApp.Application.CQRS.Home.Commands.AddEntryToTitle
{
    public class Command : CommandBase
    {
        public long TitleId { get; set; }
        public string Entry { get; set; }
        public long AuthorTypeId { get; set; }
    }
}
