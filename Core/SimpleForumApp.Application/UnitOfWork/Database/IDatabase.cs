using SimpleForumApp.Application.UnitOfWork.Core;

namespace SimpleForumApp.Application.UnitOfWork.Database
{
    public interface IDatabase : IInjectable
    {
        public IEfCoreDb EfCoreDb { get; }
    }
}
