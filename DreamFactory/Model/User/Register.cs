namespace DreamFactory.Model.User
{
    /// <summary>
    /// Register (new user).
    /// </summary>
    public class Register
    {
        /// <summary>
        /// Email address of the new user.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// First name of the new user.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of the new user.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Full display name of the new user.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Password for the new user.
        /// </summary>
        public string NewPassword { get; set; }

        /// <summary>
        /// Code required with new_password when using email confirmation.
        /// </summary>
        public string Code { get; set; }
    }
}