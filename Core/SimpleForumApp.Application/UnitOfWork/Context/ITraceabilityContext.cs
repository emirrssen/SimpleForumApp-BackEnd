using SimpleForumApp.Application.Repositories.Auth;
using SimpleForumApp.Application.Repositories.Traceability;
using SimpleForumApp.Application.UnitOfWork.Core;

namespace SimpleForumApp.Application.UnitOfWork.Context
{
    public interface ITraceabilityContext : IInjectable
    {
        public IEndPointRepository EndPointRepository { get; }
        public IEndPointActivityRepository EndPointActivityRepository { get; }
    }
}
