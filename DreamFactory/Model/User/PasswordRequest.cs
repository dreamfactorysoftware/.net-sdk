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
        public string OldPassword { get; set; }

        /// <summary>
        /// New password to be set.
        /// </summary>
        public string NewPassword { get; set; }

        /// <summary>
        /// User's email to be used with code to validate email confirmation.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Code required with new_password when using email confirmation.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Code required with new_password when using email confirmation.
        /// </summary>
        public string SecurityAnswer { get; set; }
    }
}
