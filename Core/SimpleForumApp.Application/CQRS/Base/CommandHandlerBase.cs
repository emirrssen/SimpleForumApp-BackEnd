using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleForumApp.Application.CQRS.Base
{
    public abstract class CommandHandlerBase<TCommand> : IRequestHandler<TCommand> where TCommand : CommandBase
    {
        public abstract Task Handle(TCommand request, CancellationToken cancellationToken);
    }
}
