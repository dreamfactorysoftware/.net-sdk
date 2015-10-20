namespace DreamFactory.Model.User
{
    using Newtonsoft.Json;

    /// <summary>
    /// Register response.
    /// </summary>
    public class RegisterResponse : SuccessResponse
    {
        /// <summary>
        /// Token for the current session, used in X-DreamFactory-Session-Token header for API requests.
        /// SessionToken has value only if request had parameter login set to true.
        /// </summary>
        [JsonProperty(PropertyName = "session_token")]
        public string SessionToken { get; set; }
    }
}
