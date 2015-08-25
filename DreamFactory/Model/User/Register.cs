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
        public string email { get; set; }

        /// <summary>
        /// First name of the new user.
        /// </summary>
        public string first_name { get; set; }

        /// <summary>
        /// Last name of the new user.
        /// </summary>
        public string last_name { get; set; }

        /// <summary>
        /// Full display name of the new user.
        /// </summary>
        public string display_name { get; set; }

        /// <summary>
        /// Password for the new user.
        /// </summary>
        public string new_password { get; set; }

        /// <summary>
        /// Code required with new_password when using email confirmation.
        /// </summary>
        public string code { get; set; }
    }
}