namespace SimpleForumApp.Application.Services.Email
{
    public interface IEmailService
    {
        Task SendResetPasswordEmailAsync(string resetEmailLink, string toEmail);
    }
}
