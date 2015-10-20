namespace DreamFactory.Model.User
{
    using global::System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Session.
    /// </summary>
    public class Session
    {
        /// <summary>
        /// Identifier for the current user.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Email address of the current user.
        /// </summary>
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        /// <summary>
        /// Name of the current user.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

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
        /// Is the current user a system administrator.
        /// </summary>
        [JsonProperty(PropertyName = "is_sys_admin")]
        public bool? IsSysAdmin { get; set; }

        /// <summary>
        /// Name of the role to which the current user is assigned.
        /// </summary>
        [JsonProperty(PropertyName = "role")]
        public string Role { get; set; }

        /// <summary>
        /// Date timestamp of the last login for the current user.
        /// </summary>
        [JsonProperty(PropertyName = "last_login_date")]
        public string LastLoginDate { get; set; }

        /// <summary>
        /// App groups and the containing apps.
        /// </summary>
        [JsonProperty(PropertyName = "app_groups")]
        public List<SessionApp> AppGroups { get; set; }

        /// <summary>
        /// Apps that are not in any app groups.
        /// </summary>
        [JsonProperty(PropertyName = "no_group_apps")]
        public List<SessionApp> NoGroupApps { get; set; }

        /// <summary>
        /// Id for the current session, used in X-DreamFactory-Session-Token header for API requests.
        /// </summary>
        [JsonProperty(PropertyName = "session_id")]
        public string SessionId { get; set; }

        /// <summary>
        /// Token for the current session, used in X-DreamFactory-Session-Token header for API requests.
        /// </summary>
        [JsonProperty(PropertyName = "session_token")]
        public string SessionToken { get; set; }
    }
}