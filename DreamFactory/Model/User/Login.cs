namespace DreamFactory.Model.User
{
    /// <summary>
    /// Login.
    /// </summary>
    public class Login
    {
        /// <summary>
        /// e-mail.
        /// </summary>
        public string Email { get; set; }
        
        /// <summary>
        /// Password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Duration of the session, Defaults to 0, which means until browser is closed.
        /// </summary>
        public int? Duration { get; set; }
    }
}
