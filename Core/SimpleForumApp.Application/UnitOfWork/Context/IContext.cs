namespace SimpleForumApp.Application.UnitOfWork.Context
{
    public interface IContext
    {
        public IAppContext App { get; }
        public IIdentityContext Identity { get; }
        public INotificationContext Notification { get; }
    }
}
