namespace DreamFactory.Model.File
{
    using Newtonsoft.Json;

    /// <summary>
    /// FileRequest.
    /// </summary>
    public class FileRequest
    {
        /// <summary>
        /// Gets Identifier/Name for the file, localized to requested resource.
        /// </summary>
        [JsonProperty(PropertyName = @"name")]
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
    }
}
