namespace DreamFactory.Model.System.User
{
    using global::System;
    using Newtonsoft.Json;

    /// <summary>
    /// RelatedUser.
    /// </summary>
    public class RelatedUser
    {
        /// <summary>
        /// Identifier of this user.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>
        /// The email address required for this user.
        /// </summary>
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        /// <summary>
        /// The set-able, but never readable, password.
        /// </summary>
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }

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
        /// Displayable name of this user.
        /// </summary>
        [JsonProperty(PropertyName = "display_name")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Phone number for this user.
        /// </summary>
        [JsonProperty(PropertyName = "phone")]
        public string Phone { get; set; }

        /// <summary>
        /// True if this user is active for use.
        /// </summary>
        [JsonProperty(PropertyName = "is_active")]
        public bool? IsActive { get; set; }

        /// <summary>
        /// True if this user is a system admin.
        /// </summary>
        [JsonProperty(PropertyName = "is_sys_admin")]
        public bool? IsSysAdmin { get; set; }

        /// <summary>
        /// The default launched app for this user.
        /// </summary>
        [JsonProperty(PropertyName = "default_app_id")]
        public string DefaultAppId { get; set; }

        /// <summary>
        /// The role to which this user is assigned.
        /// </summary>
        [JsonProperty(PropertyName = "role_id")]
        public string RoleId { get; set; }

        /// <summary>
        /// Date this user was created.
        /// </summary>
        [JsonProperty(PropertyName = "created_date")]
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// User Id of who created this user.
        /// </summary>
        [JsonProperty(PropertyName = "created_by_id")]
        public int? CreatedById { get; set; }

        /// <summary>
        /// Date this user was last modified.
        /// </summary>
        [JsonProperty(PropertyName = "last_modified_date")]
        public DateTime? LastModifiedDate { get; set; }

        /// <summary>
        /// User Id of who last modified this user.
        /// </summary>
        [JsonProperty(PropertyName = "last_modified_by_id")]
        public int? LastModifiedById { get; set; }
    }
}
