namespace DreamFactory.Model.System.Email
{
    using DreamFactory.Model.Email;
    using global::System;
    using global::System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// EmailTemplateResponse.
    /// </summary>
    public class EmailTemplateResponse
    {
        /// <summary>
        /// Identifier of this email template.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>
        /// Displayable name of this email template.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Description of this email template.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Single or multiple receiver addresses.
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
        /// Required sender name and email.
        /// </summary>
        [JsonProperty(PropertyName = "from")]
        public EmailAddress From { get; set; }

        /// <summary>
        /// Optional reply to name and email.
        /// </summary>
        [JsonProperty(PropertyName = "reply_to")]
        public EmailAddress ReplyTo { get; set; }

        /// <summary>
        /// Array of default name value pairs for template replacement.
        /// </summary>
        [JsonProperty(PropertyName = "defaults")]
        public List<string> Defaults { get; set; }

        /// <summary>
        /// Date this email template was created.
        /// </summary>
        [JsonProperty(PropertyName = "created_date")]
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// User Id of who created this email template.
        /// </summary>
        [JsonProperty(PropertyName = "created_by_id")]
        public int? CreatedById { get; set; }

        /// <summary>
        /// Date this email template was last modified.
        /// </summary>
        [JsonProperty(PropertyName = "last_modified_date")]
        public DateTime? LastModifiedDate { get; set; }

        /// <summary>
        /// User Id of who last modified this email template.
        /// </summary>
        [JsonProperty(PropertyName = "last_modified_by_id")]
        public int? LastModifiedById { get; set; }
    }
}
