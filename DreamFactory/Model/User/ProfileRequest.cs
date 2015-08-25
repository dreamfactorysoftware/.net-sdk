namespace DreamFactory.Model.User
{
    /// <summary>
    /// ProfileRequest
    /// </summary>
    public class ProfileRequest
    {
        /// <summary>
        /// Email address of the current user.
        /// </summary>
        public string email { get; set; }

        /// <summary>
        /// First name of the current user.
        /// </summary>
        public string first_name { get; set; }

        /// <summary>
        /// Last name of the current user.
        /// </summary>
        public string last_name { get; set; }

        /// <summary>
        /// Full display name of the current user.
        /// </summary>
        public string display_name { get; set; }

        /// <summary>
        /// Phone number.
        /// </summary>
        public string phone { get; set; }

        /// <summary>
        /// Question to be answered to initiate password reset.
        /// </summary>
        public string security_question { get; set; }

        /// <summary>
        /// Id of the application to be launched at login.
        /// </summary>
        public int? default_app_id { get; set; }

        /// <summary>
        /// Answer to the security question.
        /// </summary>
        public string security_answer { get; set; } 
    }
}