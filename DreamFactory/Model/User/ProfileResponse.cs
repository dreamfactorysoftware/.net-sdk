namespace DreamFactory.Model.User
{
    /// <summary>
    /// ProfileResponse.
    /// </summary>
    public class ProfileResponse
    {
        /// <summary>
        /// Email address of the current user.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// First name of the current user.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of the current user.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Full display name of the current user.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Phone number.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Question to be answered to initiate password reset.
        /// </summary>
        public string SecurityQuestion { get; set; }

        /// <summary>
        /// Id of the application to be launched at login.
        /// </summary>
        public int? DefaultAppId { get; set; }
    }
}
