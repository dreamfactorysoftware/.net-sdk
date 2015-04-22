namespace DreamFactory.Model.Builder
{
    using DreamFactory.Model.Email;

    /// <summary>
    /// Represents <see cref="EmailRequest"/> builder.
    /// </summary>
    public interface IEmailRequestBuilder
    {
        /// <summary>
        /// Adds To email address.
        /// </summary>
        /// <param name="email">Email address.</param>
        /// <returns>Interface chaining.</returns>
        IEmailRequestBuilder AddTo(string email);

        /// <summary>
        /// Sets email subject.
        /// </summary>
        /// <param name="subject">Subject.</param>
        /// <returns>Interface chaining.</returns>
        IEmailRequestBuilder WithSubject(string subject);

        /// <summary>
        /// Sets email body text.
        /// </summary>
        /// <param name="text">Body text.</param>
        /// <returns>Interface chaining.</returns>
        IEmailRequestBuilder WithBody(string text);

        /// <summary>
        /// Builds resulting <see cref="EmailRequest"/> instance.
        /// </summary>
        /// <returns><see cref="EmailRequest"/> instance.</returns>
        EmailRequest Build();
    }
}