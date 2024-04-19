using SimpleForumApp.Application.UnitOfWork;

namespace SimpleForumApp.Persistence.UnitOfWork
{
    public class UnitOfWork : ServiceGetter, IUnitOfWork
    {
        public UnitOfWork(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public IAppUnitOfWork App => GetService<IAppUnitOfWork>();
        public IIdentityUnitOfWork Identity => GetService<IIdentityUnitOfWork>();
    }
}
