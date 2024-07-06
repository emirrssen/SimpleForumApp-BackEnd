using SimpleForumApp.Application.UnitOfWork.Core;

namespace SimpleForumApp.Application.UnitOfWork.Context
{
    public interface IContext : IInjectable
    {
        public IAppContext App { get; }
        public IIdentityContext Identity { get; }
        public INotificationContext Notification { get; }
        public ITraceabilityContext Traceability { get; }
    }
}
