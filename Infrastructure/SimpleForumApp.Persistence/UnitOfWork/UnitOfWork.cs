using SimpleForumApp.Application.UnitOfWork;
using SimpleForumApp.Application.UnitOfWork.Context;
using SimpleForumApp.Application.UnitOfWork.Database;
using SimpleForumApp.Persistence.UnitOfWork.Core;

namespace SimpleForumApp.Persistence.UnitOfWork
{
    public class UnitOfWork : ServiceGetter, IUnitOfWork
    {
        public UnitOfWork(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
        public IContext Context => GetService<IContext>();
        public IDatabase Database => GetService<IDatabase>();
    }
}
