using SimpleForumApp.Application.Repositories;
using SimpleForumApp.Application.Repositories.PersonRepositories;
using SimpleForumApp.Application.UnitOfWork.Core;

namespace SimpleForumApp.Application.UnitOfWork.Context
{
    public interface IAppContext : IInjectable
    {
        public IPersonWriteRepository PersonWriteRepository { get; }
        public IPersonReadRepository PersonReadRepository { get; }
        public IEndPointRepository EndPointRepository { get; }
    }
}
