namespace DreamFactory.Model.User
{
    using Newtonsoft.Json;

    /// <summary>
    /// PasswordRequest.
    /// </summary>
    public class PasswordRequest
    {
        /// <summary>
        /// Old password to validate change during a session.
        /// </summary>
        [JsonProperty(PropertyName = "old_password")]
        public string OldPassword { get; set; }

        /// <summary>
        /// New password to be set.
        /// </summary>
        [JsonProperty(PropertyName = "new_password")]
        public string NewPassword { get; set; }

        /// <summary>
        /// User's email to be used with code to validate email confirmation.
        /// </summary>
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        /// <summary>
        /// Code required with new_password when using email confirmation.
        /// </summary>
        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }

        /// <summary>
        /// Code required with new_password when using email confirmation.
        /// </summary>
        [JsonProperty(PropertyName = "security_answer")]
        public string SecurityAnswer { get; set; }
    }
}
