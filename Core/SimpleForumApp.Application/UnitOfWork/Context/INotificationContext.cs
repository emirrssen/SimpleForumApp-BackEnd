using SimpleForumApp.Application.Services.Email;

namespace SimpleForumApp.Application.UnitOfWork.Context
{
    public interface INotificationContext
    {
        public IEmailService EmailService { get; }
    }
}
