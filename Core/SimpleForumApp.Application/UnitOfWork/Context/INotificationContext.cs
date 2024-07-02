using SimpleForumApp.Application.Services.Email;
using SimpleForumApp.Application.UnitOfWork.Core;

namespace SimpleForumApp.Application.UnitOfWork.Context
{
    public interface INotificationContext : IInjectable
    {
        public IEmailService EmailService { get; }
    }
}
