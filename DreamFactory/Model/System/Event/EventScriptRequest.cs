namespace DreamFactory.Model.System.Event
{
    using Newtonsoft.Json;

    /// <summary>
    /// EventScriptRequest.
    /// </summary>
    public class EventScriptRequest
    {
        /// <summary>
        /// Name of this event script
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Type for this event script.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Indicator whether this event script is active.
        /// </summary>
        [JsonProperty(PropertyName = "is_active")]
        public bool? IsActive { get; set; }

        /// <summary>
        /// Indicator whether this event script affect process.
        /// </summary>
        [JsonProperty(PropertyName = "affects_process")]
        public bool? AffectsProcess { get; set; }

        /// <summary>
        /// Content of this event script.
        /// </summary>
        [JsonProperty(PropertyName = "content")]
        public string Content { get; set; }

        /// <summary>
        /// Config for this event script.
        /// </summary>
        [JsonProperty(PropertyName = "config")]
        public string Config { get; set; }
    }
}
