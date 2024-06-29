using SimpleForumApp.Application.Repositories.PersonRepositories;
using SimpleForumApp.Application.UnitOfWork.Core;

namespace SimpleForumApp.Application.UnitOfWork.Context
{
    public interface IAppContext : IService
    {
        public IPersonWriteRepository PersonRepository { get; }
    }
}
