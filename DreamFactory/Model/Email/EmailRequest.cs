namespace DreamFactory.Model.Email
{
    using global::System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Email request.
    /// </summary>
    public class EmailRequest
    {
        /// <summary>
        /// Template name to base email on.
        /// </summary>
        [JsonProperty(PropertyName = "template")]
        public string Template { get; set; }

        /// <summary>
        /// Email Template id to base email on.
        /// </summary>
        [JsonProperty(PropertyName = "template_id")]
        public int? TemplateId { get; set; }

        /// <summary>
        /// Required single or multiple receiver addresses.
        /// </summary>
        [JsonProperty(PropertyName = "to")]
        public List<EmailAddress> To { get; set; }

        /// <summary>
        /// Optional CC receiver addresses.
        /// </summary>
        [JsonProperty(PropertyName = "cc")]
        public List<EmailAddress> Cc { get; set; }

        /// <summary>
        /// Optional BCC receiver addresses.
        /// </summary>
        [JsonProperty(PropertyName = "bcc")]
        public List<EmailAddress> Bcc { get; set; }

        /// <summary>
        /// Text only subject line.
        /// </summary>
        [JsonProperty(PropertyName = "subject")]
        public string Subject { get; set; }

        /// <summary>
        /// Text only version of the body.
        /// </summary>
        [JsonProperty(PropertyName = "body_text")]
        public string BodyText { get; set; }

        /// <summary>
        /// Escaped HTML version of the body.
        /// </summary>
        [JsonProperty(PropertyName = "body_html")]
        public string BodyHtml { get; set; }

        /// <summary>
        /// Required sender name.
        /// </summary>
        [JsonProperty(PropertyName = "from_name")]
        public string FromName { get; set; }

        /// <summary>
        /// Required sender email.
        /// </summary>
        [JsonProperty(PropertyName = "from_email")]
        public string FromEmail { get; set; }

        /// <summary>
        /// Optional reply to name.
        /// </summary>
        [JsonProperty(PropertyName = "reply_to_name")]
        public string ReplyToName { get; set; }

        /// <summary>
        /// Optional reply to email.
        /// </summary>
        [JsonProperty(PropertyName = "reply_to_email")]
        public string ReplyToEmail { get; set; }
    }
}
