namespace DreamFactory.Model.System.Script
{
    using global::System;
    using Newtonsoft.Json;

    /// <summary>
    /// RelatedScriptType.
    /// </summary>
    public class RelatedScriptType
    {
        /// <summary>
        /// Name of this script type.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Class name of this script type.
        /// </summary>
        [JsonProperty(PropertyName = "class_name")]
        public string ClassName { get; set; }

        /// <summary>
        /// Label for this script type.
        /// </summary>
        [JsonProperty(PropertyName = "label")]
        public string Label { get; set; }

        /// <summary>
        /// Description for this script type.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Indicator whether this script type is sandboxed.
        /// </summary>
        [JsonProperty(PropertyName = "sandboxed")]
        public bool? Sandboxed { get; set; }

        /// <summary>
        /// Date this script type was created.
        /// </summary>
        [JsonProperty(PropertyName = "created_date")]
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Date this script type was last modified.
        /// </summary>
        [JsonProperty(PropertyName = "last_modified_date")]
        public DateTime? LastModifiedDate { get; set; }
    }
}
