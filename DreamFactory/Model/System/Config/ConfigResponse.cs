namespace DreamFactory.Model.System.Config
{
    using global::System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// ConfigResponse.
    /// </summary>
    public class ConfigResponse
    {
        /// <summary>
        /// Comma-delimited list of fields the user is allowed to edit.
        /// </summary>
        [JsonProperty(PropertyName = "editable_profile_fields")]
        public string EditableProfileFields { get; set; }

        /// <summary>
        /// An array of HTTP verbs that must be tunneled on this server.
        /// </summary>
        [JsonProperty(PropertyName = "restricted_verbs")]
        public List<string> RestrictedVerbs { get; set; }

        /// <summary>
        /// The date/time format used for timestamps.
        /// </summary>
        [JsonProperty(PropertyName = "timestamp_format")]
        public string TimestampFormat { get; set; }
    }
}
