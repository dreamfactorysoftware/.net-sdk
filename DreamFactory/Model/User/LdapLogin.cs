namespace DreamFactory.Model.User
{
    using Newtonsoft.Json;

    /// <summary>
    /// Login.
    /// </summary>
    public class LdapLogin
    {
        /// <summary>
        /// e-mail.
        /// </summary>
        [JsonProperty(PropertyName = "username")]
        public string Username { get; set; }

        /// <summary>
        /// Password.
        /// </summary>
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }

        /// <summary>
        /// Password.
        /// </summary>
        [JsonProperty(PropertyName = "service")]
        public string Service { get; set; }

        /// <summary>
        /// Duration of the session, Defaults to 0, which means until browser is closed.
        /// </summary>
        [JsonProperty(PropertyName = "duration")]
        public int? Duration { get; set; }
    }
}
