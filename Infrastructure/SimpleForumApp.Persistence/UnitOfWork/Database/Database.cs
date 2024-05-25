using SimpleForumApp.Application.UnitOfWork.Database;
using SimpleForumApp.Persistence.UnitOfWork.Core;

namespace SimpleForumApp.Persistence.UnitOfWork.Database
{
    public class Database : ServiceGetter, IDatabase
    {
        public Database(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public IEfCoreDb EfCoreDb => GetService<IEfCoreDb>();
    }
}
