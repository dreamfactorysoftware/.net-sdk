namespace DreamFactory.Model.Email
{
    using Newtonsoft.Json;

    /// <summary>
    /// Email response.
    /// </summary>
    public class EmailResponse
    {
        /// <summary>
        /// Number of emails successfully sent.
        /// </summary>
        [JsonProperty(PropertyName = "count")]
        public int? Count { get; set; }
    }
}
