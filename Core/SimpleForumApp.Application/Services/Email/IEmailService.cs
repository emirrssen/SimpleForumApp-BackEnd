using SimpleForumApp.Application.UnitOfWork.Core;

namespace SimpleForumApp.Application.Services.Email
{
    public interface IEmailService : IService
    {
        Task SendMailAsync(string subject, string body, bool isBodyHtml, string sendFrom, params string[] emails);
        Task SendMailForPasswordResetAsync(string email, string token);
    }
}
