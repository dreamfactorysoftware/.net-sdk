namespace DreamFactory.Model.User
{
    /// <summary>
    /// PasswordRequest.
    /// </summary>
    public class PasswordRequest
    {
        /// <summary>
        /// Old password to validate change during a session.
        /// </summary>
        public string old_password { get; set; }

        /// <summary>
        /// New password to be set.
        /// </summary>
        public string new_password { get; set; }

        /// <summary>
        /// User's email to be used with code to validate email confirmation.
        /// </summary>
        public string email { get; set; }

        /// <summary>
        /// Code required with new_password when using email confirmation.
        /// </summary>
        public string code { get; set; }

        /// <summary>
        /// Code required with new_password when using email confirmation.
        /// </summary>
        public string security_answer { get; set; }
    }
}
