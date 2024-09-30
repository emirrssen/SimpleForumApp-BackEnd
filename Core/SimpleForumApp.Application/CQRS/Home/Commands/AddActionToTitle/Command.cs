using SimpleForumApp.Application.BaseStructures.MediatR.CommandAbstractions;

namespace SimpleForumApp.Application.CQRS.Home.Commands.AddActionToTitle
{
    public class Command : CommandBase
    {
        public long ActionId { get; set; }
        public long TitleId { get; set; }
    }
}
