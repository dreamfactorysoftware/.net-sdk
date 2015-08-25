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
        public string template { get; set; }

        /// <summary>
        /// Email Template id to base email on.
        /// </summary>
        public int? template_id { get; set; }

        /// <summary>
        /// Required single or multiple receiver addresses.
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
        /// Required sender name.
        /// </summary>
        public string from_name { get; set; }

        /// <summary>
        /// Required sender email.
        /// </summary>
        public string from_email { get; set; }

        /// <summary>
        /// Optional reply to name.
        /// </summary>
        public string reply_to_name { get; set; }

        /// <summary>
        /// Optional reply to email.
        /// </summary>
        public string reply_to_email { get; set; }
    }
}
