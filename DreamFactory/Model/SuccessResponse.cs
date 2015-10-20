namespace DreamFactory.Model
{
    using Newtonsoft.Json;

    /// <summary>
    /// Success response.
    /// </summary>
    public class SuccessResponse
    {
        /// <summary>
        /// Indicator whether request was successful.
        /// </summary>
        [JsonProperty(PropertyName = "success")]
        public bool? Success { get; set; }
    }
}
