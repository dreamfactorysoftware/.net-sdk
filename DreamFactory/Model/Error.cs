namespace DreamFactory.Model
{
    using Newtonsoft.Json;

    /// <summary>
    /// Error data.
    /// </summary>
    public class Error
    {
        /// <summary>
        /// Gets error message.
        /// </summary>
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        /// <summary>
        /// Gets HTTP status code.
        /// </summary>
        [JsonProperty(PropertyName = "code")]
        public int Code { get; set; }
    }
}
