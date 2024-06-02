using SimpleForumApp.Application.Helpers;
using SimpleForumApp.Application.Services.Email;
using System.Net;
using System.Net.Mail;

namespace SimpleForumApp.Infrastructure.Services.Email
{
    public class EmailService : IEmailService
    {
        private readonly SmtpClient _smtpClient;

        public EmailService(SmtpClient smtpClient)
        {
            _smtpClient = smtpClient;
        }

        public async Task SendResetPasswordEmailAsync(string resetEmailLink, string toEmail)
        {
            var mailMessage = new MailMessage();

            mailMessage.IsBodyHtml = true;

            mailMessage.From = new MailAddress(AppSettingsReaderHelper.GetEmailSettingsEamil());
            mailMessage.To.Add(toEmail);

            mailMessage.Subject = "Şifre Sıfırlama Linki";
            mailMessage.Body = @$"
                <p>Değerli Simple Forum App Kullanıcısı,</p>
                <p>Şifrenizi yenilemek için <a href={resetEmailLink}>bu linke</a> tıklayabilirsiniz.</p><br>
            ";

            await _smtpClient.SendMailAsync(mailMessage);
        }
    }
}
