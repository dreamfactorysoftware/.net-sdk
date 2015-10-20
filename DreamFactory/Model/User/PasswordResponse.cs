namespace DreamFactory.Model.User
{
    using Newtonsoft.Json;

    /// <summary>
    /// PasswordResponse.
    /// </summary>
    public class PasswordResponse
    {
        /// <summary>
        /// User's security question, returned on reset request when no email confirmation required.
        /// </summary>
        [JsonProperty(PropertyName = "security_question")]
        public string SecurityQuestion { get; set; }

        /// <summary>
        /// True if password updated or reset request granted via email confirmation.
        /// </summary>
        [JsonProperty(PropertyName = "success")]
        public bool? Success { get; set; }
    }
}
