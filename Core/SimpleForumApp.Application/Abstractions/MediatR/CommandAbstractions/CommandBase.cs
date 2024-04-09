using MediatR;
using SimpleForumApp.Domain.Results;

namespace SimpleForumApp.Application.BaseStructures.MediatR.CommandAbstractions
{
    public abstract class CommandBase : IRequest<Result>, IMediatrAbstractionCore { }
}
