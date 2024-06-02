using SimpleForumApp.Application.Services.Email;

namespace SimpleForumApp.Application.UnitOfWork.Context
{
    public interface IEmailContext
    {
        public IEmailService EmailService { get; }
    }
}
