namespace DreamFactory.Model.File
{
    using global::System;
    using Newtonsoft.Json;

    /// <summary>
    /// FileResponse.
    /// </summary>
    public class FileResponse
    {
        /// <summary>
        /// Gets Identifier/Name for the file, localized to requested resource.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Full path of the file, from the service including container.
        /// </summary>
        [JsonProperty(PropertyName = "path")]
        public string Path { get; set; }

        /// <summary>
        /// The media type of the content of the file.
        /// </summary>
        [JsonProperty(PropertyName = "content_type")]
        public string ContentType { get; set; }

        /// <summary>
        /// Size of the file in bytes.
        /// </summary>
        [JsonProperty(PropertyName = "content_length")]
        public string ContentLength { get; set; }

        /// <summary>
        /// A GMT date timestamp of when the file was last modified.
        /// </summary>
        [JsonProperty(PropertyName = "last_modified")]
        public DateTime? LastModified { get; set; }
    }
}
