namespace Job_Finder.Interface
{
    /// <summary>
    /// Defines the contract for email services.
    /// Provides methods to send emails with specified parameters.
    /// </summary>
    public interface IEmailService
    {
        /// <summary>
        /// Sends an email to the specified recipient with the given subject.
        /// </summary>
        /// <param name="toEmail">The recipient's email address.</param>
        /// <param name="subject">The subject of the email.</param>
        void SendEmail(string toEmail, string subject);
    }
}
