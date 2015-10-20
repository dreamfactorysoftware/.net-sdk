namespace DreamFactory.Model.System.Cors
{
    using Newtonsoft.Json;

    /// <summary>
    /// CORS request.
    /// </summary>
    public class CorsRequest : IRecord
    {
        /// <summary>
        /// Identifier of the record.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>
        /// Path of the CORS.
        /// </summary>
        [JsonProperty(PropertyName = "path")]
        public string Path { get; set; }

        /// <summary>
        /// Origin of the CORS.
        /// </summary>
        [JsonProperty(PropertyName = "origin")]
        public string Origin { get; set; }

        /// <summary>
        /// Header of the CORS.
        /// </summary>
        [JsonProperty(PropertyName = "header")]
        public string Header { get; set; }

        /// <summary>
        /// HTTP methods allowed.
        /// </summary>
        [JsonProperty(PropertyName = "method")]
        public int? Method { get; set; }

        /// <summary>
        /// Max age.
        /// </summary>
        [JsonProperty(PropertyName = "max_age")]
        public int? MaxAge { get; set; }

        /// <summary>
        /// Indicates whether it is enabled.
        /// </summary>
        [JsonProperty(PropertyName = "enabled")]
        public bool Enabled { get; set; }
    }
}
