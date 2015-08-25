namespace DreamFactory.Model.System.User
{
    using DreamFactory.Model.System.App;
    using DreamFactory.Model.System.Role;

    /// <summary>
    /// UserRequest.
    /// </summary>
    public class UserRequest
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
        /// Related app by default_app_id.
        /// </summary>
        public RelatedApp DefaultApp { get; set; }

        /// <summary>
        /// Related role by role_id.
        /// </summary>
        public RelatedRole Role { get; set; }
    }
}
