namespace DreamFactory.Model.User
{
    /// <summary>
    /// RegisterResponse.
    /// </summary>
    public class RegisterResponse
    {
        /// <summary>
        /// Indicator whether register was successful.
        /// </summary>
        public bool? Success { get; set; }

        /// <summary>
        /// Token for the current session, used in X-DreamFactory-Session-Token header for API requests.
        /// SessionToken has value only if request had parameter login set to true.
        /// </summary>
        public string SessionToken { get; set; }
    }
}
