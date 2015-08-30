namespace DreamFactory.Model.System.User
{
    using DreamFactory.Model.System.App;
    using DreamFactory.Model.System.Role;
    using global::System;

    /// <summary>
    /// UserRequest.
    /// </summary>
    public class UserRequest : IRecord
    {
        /// <summary>
        /// Identifier of this user.
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Displayable name of this user.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The first name for this user.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The last name for this user.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The last login date for this user.
        /// </summary>
        public DateTime? LastLoginDate { get; set; }

        /// <summary>
        /// The email address required for this user.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// True if this user is active for use.
        /// </summary>
        public bool? IsActive { get; set; }

        /// <summary>
        /// Phone number for this user.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// The security question for this user.
        /// </summary>
        public string SecurityQuestion { get; set; }

        /// <summary>
        /// The security answer for this user.
        /// </summary>
        public string SecurityAnswer { get; set; }

        /// <summary>
        /// The default launched app for this user.
        /// </summary>
        public int? DefaultAppId { get; set; }

        /// <summary>
        /// The adLDAP for this user.
        /// </summary>
        public string Adldap { get; set; }

        /// <summary>
        /// The OAuth provider for this user.
        /// </summary>
        public string OauthProvider { get; set; }
    }
}
