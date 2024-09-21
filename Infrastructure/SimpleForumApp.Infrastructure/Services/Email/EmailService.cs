using SimpleForumApp.Application.Helpers;
using SimpleForumApp.Application.Services.Email;
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

        public async Task SendMailWithFromAsync(string subject, string body, bool isBodyHtml, string sendFrom, params string[] emails)
        {
            using MailMessage mailMessage = new();

            mailMessage.From = new MailAddress(sendFrom);

            foreach (var email in emails) 
            {
                mailMessage.To.Add(email);            
            }

            mailMessage.IsBodyHtml = isBodyHtml;
            mailMessage.Subject = subject;
            mailMessage.Body = body;

            await _smtpClient.SendMailAsync(mailMessage);
        }

        public async Task SendMailAsync(string subject, string body, bool isBodyHtml, params string[] emails)
        {
            using MailMessage mailMessage = new();

            mailMessage.From = new MailAddress(AppSettingsReaderHelper.GetEmailSettingsEmail());

            foreach (var email in emails)
            {
                mailMessage.To.Add(email);
            }

            mailMessage.IsBodyHtml = isBodyHtml;
            mailMessage.Subject = subject;
            mailMessage.Body = body;

            await _smtpClient.SendMailAsync(mailMessage);
        }

        public async Task SendMailForPasswordResetAsync(string email, string token)
        {
            using MailMessage mailMessage = new();

            mailMessage.From = new MailAddress(AppSettingsReaderHelper.GetEmailSettingsEmail());
            mailMessage.To.Add(email);

            mailMessage.IsBodyHtml = true;
            mailMessage.Subject = "Şifre Sıfırlama Linki";
            mailMessage.Body = @$"
                <p>Değerli Simple Forum App Kullanıcısı,</p>
                <p>Şifrenizi yenilemek için <a href={token}>bu linke</a> tıklayabilirsiniz.</p>
                <p>Saygılarımızla</p>
            ";

            await _smtpClient.SendMailAsync(mailMessage);
        }
    }
}
