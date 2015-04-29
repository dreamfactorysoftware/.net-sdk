// ReSharper disable InconsistentNaming
namespace DreamFactory.Model.System.Email
{
    using DreamFactory.Model.Email;
    using global::System.Collections.Generic;

    /// <summary>
    /// EmailTemplateRequest.
    /// </summary>
    public class EmailTemplateRequest
    {
        /// <summary>
        /// Identifier of this email template.
        /// </summary>
        public int? id { get; set; }

        /// <summary>
        /// Displayable name of this email template.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Description of this email template.
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// Single or multiple receiver addresses.
        /// </summary>
        public List<EmailAddress> to { get; set; }

        /// <summary>
        /// Optional CC receiver addresses.
        /// </summary>
        public List<EmailAddress> cc { get; set; }

        /// <summary>
        /// Optional BCC receiver addresses.
        /// </summary>
        public List<EmailAddress> bcc { get; set; }

        /// <summary>
        /// Text only subject line.
        /// </summary>
        public string subject { get; set; }

        /// <summary>
        /// Text only version of the body.
        /// </summary>
        public string body_text { get; set; }

        /// <summary>
        /// Escaped HTML version of the body.
        /// </summary>
        public string body_html { get; set; }

        /// <summary>
        /// Required sender name and email.
        /// </summary>
        public EmailAddress from { get; set; }

        /// <summary>
        /// Optional reply to name and email.
        /// </summary>
        public EmailAddress reply_to { get; set; }

        /// <summary>
        /// Array of default name value pairs for template replacement.
        /// </summary>
        public List<string> defaults { get; set; }
    }
}
