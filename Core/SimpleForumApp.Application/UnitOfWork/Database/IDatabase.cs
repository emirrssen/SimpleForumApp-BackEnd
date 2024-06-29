using SimpleForumApp.Application.UnitOfWork.Core;

namespace SimpleForumApp.Application.UnitOfWork.Database
{
    public interface IDatabase : IService
    {
        public IEfCoreDb EfCoreDb { get; }
    }
}
