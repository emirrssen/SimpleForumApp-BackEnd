using SimpleForumApp.Application.BaseStructures.MediatR.CommandAbstractions;

namespace SimpleForumApp.Application.CQRS.Layout.Commands.CreateTitle
{
    public class Command : CommandBase
    {
        public long AuthorTypeId { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
    }
}
