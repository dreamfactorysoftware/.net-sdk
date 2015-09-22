namespace DreamFactory.Model.System.Email
{
    using DreamFactory.Model.Email;
    using global::System.Collections.Generic;

    /// <summary>
    /// EmailTemplateRequest.
    /// </summary>
    public class EmailTemplateRequest : IRecord
    {
        /// <summary>
        /// Identifier of this email template.
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Displayable name of this email template.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of this email template.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Single or multiple receiver addresses.
        /// </summary>
        public List<EmailAddress> To { get; set; }

        /// <summary>
        /// Optional CC receiver addresses.
        /// </summary>
        public List<EmailAddress> Cc { get; set; }

        /// <summary>
        /// Optional BCC receiver addresses.
        /// </summary>
        public List<EmailAddress> Bcc { get; set; }

        /// <summary>
        /// Text only subject line.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Text only version of the body.
        /// </summary>
        public string BodyText { get; set; }

        /// <summary>
        /// Escaped HTML version of the body.
        /// </summary>
        public string BodyHtml { get; set; }

        /// <summary>
        /// Required sender name and email.
        /// </summary>
        public EmailAddress From { get; set; }

        /// <summary>
        /// Optional reply to name and email.
        /// </summary>
        public EmailAddress ReplyTo { get; set; }

        /// <summary>
        /// Array of default name value pairs for template replacement.
        /// </summary>
        public List<string> Defaults { get; set; }
    }
}
