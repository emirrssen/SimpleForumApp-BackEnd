using SimpleForumApp.Application.UnitOfWork.Context;
using SimpleForumApp.Application.UnitOfWork.Database;

namespace SimpleForumApp.Application.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IContext Context { get; }
        public IDatabase Database { get; }
    }
}
