namespace SimpleForumApp.Application.Services.Email
{
    public interface IEmailService
    {
        Task SendMailAsync(string subject, string body, bool isBodyHtml, string sendFrom, params string[] emails);
        Task SendMailForPasswordResetAsync(string email, string token);
    }
}
