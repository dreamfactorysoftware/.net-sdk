namespace DreamFactory.Model.Email
{
    using global::System.Collections.Generic;

    /// <summary>
    /// Email request.
    /// </summary>
    public class EmailRequest
    {
        /// <summary>
        /// Template name to base email on.
        /// </summary>
        public string Template { get; set; }

        /// <summary>
        /// Email Template id to base email on.
        /// </summary>
        public int? TemplateId { get; set; }

        /// <summary>
        /// Required single or multiple receiver addresses.
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
        /// Required sender name.
        /// </summary>
        public string FromName { get; set; }

        /// <summary>
        /// Required sender email.
        /// </summary>
        public string FromEmail { get; set; }

        /// <summary>
        /// Optional reply to name.
        /// </summary>
        public string ReplyToName { get; set; }

        /// <summary>
        /// Optional reply to email.
        /// </summary>
        public string ReplyToEmail { get; set; }
    }
}
