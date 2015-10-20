namespace DreamFactory.Model.User
{
    using Newtonsoft.Json;

    /// <summary>
    /// ProfileResponse.
    /// </summary>
    public class ProfileResponse
    {
        /// <summary>
        /// Email address of the current user.
        /// </summary>
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        /// <summary>
        /// First name of the current user.
        /// </summary>
        [JsonProperty(PropertyName = "first_name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of the current user.
        /// </summary>
        [JsonProperty(PropertyName = "last_name")]
        public string LastName { get; set; }

        /// <summary>
        /// Full display name of the current user.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Phone number.
        /// </summary>
        [JsonProperty(PropertyName = "phone")]
        public string Phone { get; set; }

        /// <summary>
        /// Question to be answered to initiate password reset.
        /// </summary>
        [JsonProperty(PropertyName = "security_question")]
        public string SecurityQuestion { get; set; }

        /// <summary>
        /// Id of the application to be launched at login.
        /// </summary>
        [JsonProperty(PropertyName = "default_app_id")]
        public int? DefaultAppId { get; set; }
    }
}
