using SimpleForumApp.Application.Repositories.PersonRepositories;
using SimpleForumApp.Application.UnitOfWork;

namespace SimpleForumApp.Persistence.UnitOfWork
{
    public class AppUnitOfWork : ServiceGetter, IAppUnitOfWork
    {
        public AppUnitOfWork(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public IPersonWriteRepository PersonRepository => GetService<IPersonWriteRepository>();
    }
}
