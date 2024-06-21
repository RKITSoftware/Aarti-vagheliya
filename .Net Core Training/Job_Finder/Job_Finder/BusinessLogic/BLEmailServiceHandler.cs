using Job_Finder.Interface;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace Job_Finder.BusinessLogic
{
    /// <summary>
    /// Handles email services for the application, specifically sending registration notifications.
    /// </summary>
    public class BLEmailServiceHandler : IEmailService
    {
        /// <summary>
        /// Sends a registration confirmation email to the specified recipient.
        /// </summary>
        /// <param name="toEmail">The recipient's email address.</param>
        /// <param name="subject">The subject of the email.</param>
        /// <remarks>
        /// This method constructs an HTML-formatted email message and uses the Outlook SMTP server
        /// to send the email. Ensure the SMTP credentials are valid and securely managed.
        /// </remarks>
        public void SendEmail(string toEmail, string subject)
        {
            // Set up SMTP client
            SmtpClient client = new SmtpClient("smtp-mail.outlook.com", 587);
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("notify.cert-gen@outlook.com", "Mahadev11@");

            // Create email message
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("notify.cert-gen@outlook.com");
            mailMessage.To.Add(toEmail);
            mailMessage.Subject = subject;
            mailMessage.IsBodyHtml = true;
            StringBuilder mailBody = new StringBuilder();
            mailBody.AppendFormat("<h1>User Registered</h1>");
            mailBody.AppendFormat("<br />");
            mailBody.AppendFormat("<p>Thank you For Registering account</p>");
            mailMessage.Body = mailBody.ToString();

            // Send email
            client.Send(mailMessage);
        }
    }
}
