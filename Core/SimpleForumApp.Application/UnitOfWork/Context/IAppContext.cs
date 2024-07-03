using SimpleForumApp.Application.Repositories.App;
using SimpleForumApp.Application.Repositories.Traceability;
using SimpleForumApp.Application.UnitOfWork.Core;

namespace SimpleForumApp.Application.UnitOfWork.Context
{
    public interface IAppContext : IInjectable
    {
        public IPersonRepository PersonRepository { get; }
        public IEndPointRepository EndPointRepository { get; }
    }
}
