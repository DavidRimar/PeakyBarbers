using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using PeakyBarbers.Web.Settings;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace PeakyBarbers.Web.WebServices
{
    public class EmailSender : IEmailSender
    {
        private readonly MailSettings mailSettings;

        public EmailSender(IOptions<MailSettings> mailSettings)
        {

            this.mailSettings = mailSettings.Value;
        }
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // define client
            var client = new SmtpClient(mailSettings.Host, mailSettings.Port)
            {

                Credentials = new NetworkCredential(mailSettings.Mail, mailSettings.Password),
                EnableSsl = true
            };

            // send mail async
            await client.SendMailAsync(new MailMessage(mailSettings.Mail, email, subject, htmlMessage) { IsBodyHtml = true });
        }
    }
}
