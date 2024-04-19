using SimpleForumApp.Application.Repositories.PersonRepositories;

namespace SimpleForumApp.Application.UnitOfWork
{
    public interface IAppUnitOfWork
    {
        public IPersonWriteRepository PersonRepository { get; }
    }
}
