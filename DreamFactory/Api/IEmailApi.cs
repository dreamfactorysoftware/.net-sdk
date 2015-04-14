namespace DreamFactory.Api
{
    using System.Threading.Tasks;
    using DreamFactory.Model;
    using DreamFactory.Model.Email;

    /// <summary>
    /// Represents /email API.
    /// </summary>
    public interface IEmailApi
    {
        /// <summary>
        /// Sends email(s).
        /// </summary>
        /// <param name="emailRequest"><see cref="EmailRequest"/> instance.</param>
        /// <returns>Number of emails successfully sent.</returns>
        Task<int> SendEmailAsync(EmailRequest emailRequest);
    }
}