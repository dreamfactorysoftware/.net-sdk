namespace DreamFactory.Model.System.Service
{
    using global::System;
    using Newtonsoft.Json;

    /// <summary>
    /// RelatedServiceType.
    /// </summary>
    public class RelatedServiceType
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
        /// Config handler of this script type.
        /// </summary>
        [JsonProperty(PropertyName = "config_handler")]
        public string ConfigHandler { get; set; }

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
        /// Group for this script type.
        /// </summary>
        [JsonProperty(PropertyName = "group")]
        public string Group { get; set; }

        /// <summary>
        /// Indicator whether this service type is singleton.
        /// </summary>
        [JsonProperty(PropertyName = "singleton")]
        public bool? Singleton { get; set; }

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
