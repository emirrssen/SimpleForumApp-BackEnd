using MediatR;
using SimpleForumApp.Domain.Results;

namespace SimpleForumApp.Application.BaseStructures.MediatR.CommandAbstractions
{
    public abstract class CommandHandlerBase<TCommand> : IRequestHandler<TCommand, Result> where TCommand : CommandBase
    {
        public abstract Task<Result> Handle(TCommand request, CancellationToken cancellationToken);
    }
}
