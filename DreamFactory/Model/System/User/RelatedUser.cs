namespace DreamFactory.Model.System.User
{
    using global::System;

    /// <summary>
    /// RelatedUser.
    /// </summary>
    public class RelatedUser
    {
        /// <summary>
        /// Identifier of this user.
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// The email address required for this user.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The set-able, but never readable, password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// The first name for this user.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The last name for this user.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Displayable name of this user.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Phone number for this user.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// True if this user is active for use.
        /// </summary>
        public bool? IsActive { get; set; }

        /// <summary>
        /// True if this user is a system admin.
        /// </summary>
        public bool? IsSysAdmin { get; set; }

        /// <summary>
        /// The default launched app for this user.
        /// </summary>
        public string DefaultAppId { get; set; }

        /// <summary>
        /// The role to which this user is assigned.
        /// </summary>
        public string RoleId { get; set; }

        /// <summary>
        /// Date this user was created.
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// User Id of who created this user.
        /// </summary>
        public int? CreatedById { get; set; }

        /// <summary>
        /// Date this user was last modified.
        /// </summary>
        public DateTime? LastModifiedDate { get; set; }

        /// <summary>
        /// User Id of who last modified this user.
        /// </summary>
        public int? LastModifiedById { get; set; }
    }
}
