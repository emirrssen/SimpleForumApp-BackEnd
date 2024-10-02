using SimpleForumApp.Application.UnitOfWork.Context;
using SimpleForumApp.Persistence.UnitOfWork.Core;

namespace SimpleForumApp.Persistence.UnitOfWork.Context
{
    public class Context : ServiceGetter, IContext
    {
        public Context(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public IAppContext App => GetService<IAppContext>();
        public IIdentityContext Identity => GetService<IIdentityContext>();
        public INotificationContext Notification => GetService<INotificationContext>();
        public ITraceabilityContext Traceability => GetService<ITraceabilityContext>();
        public IAuthContext Auth => GetService<IAuthContext>();
        public ICacheContext Cache => GetService<ICacheContext>();
    }
}
