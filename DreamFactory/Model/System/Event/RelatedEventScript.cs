namespace DreamFactory.Model.System.Event
{
    using global::System;
    using Newtonsoft.Json;

    /// <summary>
    /// RelatedEventScript.
    /// </summary>
    public class RelatedEventScript
    {
        /// <summary>
        /// Name of this event script.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Type of this event script.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Indicator whether this event script is active.
        /// </summary>
        [JsonProperty(PropertyName = "is_active")]
        public bool? IsActive { get; set; }

        /// <summary>
        /// Indicator whether this event script affects process.
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

        /// <summary>
        /// Id of the user that created this event script.
        /// </summary>
        [JsonProperty(PropertyName = "created_by_id")]
        public int? CreatedById { get; set; }

        /// <summary>
        /// Id of the user that last modified this event script.
        /// </summary>
        [JsonProperty(PropertyName = "modified_by_id")]
        public int? ModifiedById { get; set; }

        /// <summary>
        /// Date this event script was created.
        /// </summary>
        [JsonProperty(PropertyName = "created_date")]
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Date this event script was last modified.
        /// </summary>
        [JsonProperty(PropertyName = "last_modified_date")]
        public DateTime? LastModifiedDate { get; set; }
    }
}
