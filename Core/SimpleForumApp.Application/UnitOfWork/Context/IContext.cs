using SimpleForumApp.Application.UnitOfWork.Core;

namespace SimpleForumApp.Application.UnitOfWork.Context
{
    public interface IContext : IService
    {
        public IAppContext App { get; }
        public IIdentityContext Identity { get; }
        public INotificationContext Notification { get; }
    }
}
