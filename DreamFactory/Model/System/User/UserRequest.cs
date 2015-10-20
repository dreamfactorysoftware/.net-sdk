namespace DreamFactory.Model.System.User
{
    using global::System;
    using Newtonsoft.Json;

    /// <summary>
    /// UserRequest.
    /// </summary>
    public class UserRequest : IRecord
    {
        /// <summary>
        /// Identifier of this user.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>
        /// Displayable name of this user.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// The first name for this user.
        /// </summary>
        [JsonProperty(PropertyName = "first_name")]
        public string FirstName { get; set; }

        /// <summary>
        /// The last name for this user.
        /// </summary>
        [JsonProperty(PropertyName = "last_name")]
        public string LastName { get; set; }

        /// <summary>
        /// The last login date for this user.
        /// </summary>
        [JsonProperty(PropertyName = "last_login_date")]
        public DateTime? LastLoginDate { get; set; }

        /// <summary>
        /// The email address required for this user.
        /// </summary>
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        /// <summary>
        /// True if this user is active for use.
        /// </summary>
        [JsonProperty(PropertyName = "is_active")]
        public bool? IsActive { get; set; }

        /// <summary>
        /// Phone number for this user.
        /// </summary>
        [JsonProperty(PropertyName = "phone")]
        public string Phone { get; set; }

        /// <summary>
        /// The security question for this user.
        /// </summary>
        [JsonProperty(PropertyName = "security_question")]
        public string SecurityQuestion { get; set; }

        /// <summary>
        /// The security answer for this user.
        /// </summary>
        [JsonProperty(PropertyName = "security_answer")]
        public string SecurityAnswer { get; set; }

        /// <summary>
        /// The default launched app for this user.
        /// </summary>
        [JsonProperty(PropertyName = "default_app_id")]
        public int? DefaultAppId { get; set; }

        /// <summary>
        /// The adLDAP for this user.
        /// </summary>
        [JsonProperty(PropertyName = "adldap")]
        public string Adldap { get; set; }

        /// <summary>
        /// The OAuth provider for this user.
        /// </summary>
        [JsonProperty(PropertyName = "oauth_provider")]
        public string OauthProvider { get; set; }
    }
}
