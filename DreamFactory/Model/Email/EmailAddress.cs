namespace DreamFactory.Model.Email
{
    using Newtonsoft.Json;

    /// <summary>
    /// Email address.
    /// </summary>
    public class EmailAddress
    {
        /// <summary>
        /// Optional name displayed along with the email address.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Required email address.
        /// </summary>
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }
    }
}
