namespace DreamFactory.Model.User
{
    /// <summary>
    /// Register response.
    /// </summary>
    public class RegisterResponse : SuccessResponse
    {
        /// <summary>
        /// Token for the current session, used in X-DreamFactory-Session-Token header for API requests.
        /// SessionToken has value only if request had parameter login set to true.
        /// </summary>
        public string SessionToken { get; set; }
    }
}
