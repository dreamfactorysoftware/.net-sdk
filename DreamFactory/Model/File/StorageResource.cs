namespace DreamFactory.Model.File
{
    using global::System;
    using global::System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// A storage resource information.
    /// </summary>
    public class StorageResource
    {
        /// <summary>
        /// Identifier/Name for the resource.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Path for the resource.
        /// </summary>
        [JsonProperty(PropertyName = "path")]
        public string Path { get; set; }

        /// <summary>
        /// Date and time of last modification.
        /// </summary>
        [JsonProperty(PropertyName = "last_modified")]
        public DateTime? LastModified { get; set; }

        /// <summary>
        /// Resource content length.
        /// </summary>
        [JsonProperty(PropertyName = "content_length")]
        public int ContentLength { get; set; }

        /// <summary>
        /// Resource type.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Resource content type.
        /// </summary>
        [JsonProperty(PropertyName = "content_type")]
        public string ContentType { get; set; }
    }
}
