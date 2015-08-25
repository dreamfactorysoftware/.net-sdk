namespace DreamFactory.Model.Email
{
    /// <summary>
    /// Email address.
    /// </summary>
    public class EmailAddress
    {
        /// <summary>
        /// Optional name displayed along with the email address.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Required email address.
        /// </summary>
        public string email { get; set; }
    }
}
