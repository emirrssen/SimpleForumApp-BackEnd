using MediatR;
using SimpleForumApp.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleForumApp.Application.BaseStructures.MediatR.Command
{
    public abstract class CommandBase : IRequest<Result>, IBase { }
}
