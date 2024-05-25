using SimpleForumApp.Application.Repositories.PersonRepositories;

namespace SimpleForumApp.Application.UnitOfWork.Context
{
    public interface IAppContext
    {
        public IPersonWriteRepository PersonRepository { get; }
    }
}
