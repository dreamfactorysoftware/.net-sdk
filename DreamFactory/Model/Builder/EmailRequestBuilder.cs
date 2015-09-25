namespace DreamFactory.Model.Builder
{
    using DreamFactory.Model.Email;
    using global::System;
    using global::System.Collections.Generic;

    /// <summary>
    /// <see cref="EmailRequest"/> builder.
    /// </summary>
    public class EmailRequestBuilder : IEmailRequestBuilder
    {
        private readonly List<EmailAddress> addresses;
        private string subjectCopy;
        private string bodyCopy;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailRequestBuilder"/> class.
        /// </summary>
        public EmailRequestBuilder()
        {
            addresses = new List<EmailAddress>();
        }

        /// <inheritdoc />
        public IEmailRequestBuilder AddTo(string email)
        {
            if (email == null)
            {
                throw new ArgumentNullException("email");
            }

            addresses.Add(new EmailAddress { Email = email });
            return this;
        }

        /// <inheritdoc />
        public IEmailRequestBuilder WithSubject(string subject)
        {
            if (subject == null)
            {
                throw new ArgumentNullException("subject");
            }

            subjectCopy = subject;
            return this;
        }

        /// <inheritdoc />
        public IEmailRequestBuilder WithBody(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }

            bodyCopy = text;
            return this;
        }

        /// <inheritdoc />
        public EmailRequest Build()
        {
            if (addresses.Count == 0)
            {
                throw new DreamFactoryException("At least one To.. address must be added.");
            }

            if (string.IsNullOrEmpty(subjectCopy))
            {
                throw new DreamFactoryException("Email subject was not provided.");
            }

            if (string.IsNullOrEmpty(bodyCopy))
            {
                throw new DreamFactoryException("Email body was not provided.");
            }

            return new EmailRequest { To = addresses, Subject = subjectCopy, BodyText = bodyCopy };
        }
    }
}