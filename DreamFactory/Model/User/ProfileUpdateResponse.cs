namespace DreamFactory.Model.User
{
    using Newtonsoft.Json;

    /// <summary>
    /// ProfileUpdateResponse.
    /// </summary>
    public class ProfileUpdateResponse
    {
        /// <summary>
        /// Indicator whether updating profile was successful.
        /// </summary>
        [JsonProperty(PropertyName = "success")]
        public bool? Success { get; set; }
    }
}
