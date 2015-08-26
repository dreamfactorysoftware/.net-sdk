namespace DreamFactory.Model.User
{
    using global::System.Collections.Generic;

    /// <summary>
    /// Session.
    /// </summary>
    public class Session
    {
        /// <summary>
        /// Identifier for the current user.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Email address of the current user.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Name of the current user.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// First name of the current user.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of the current user.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Is the current user a system administrator.
        /// </summary>
        public bool? IsSysAdmin { get; set; }

        /// <summary>
        /// Name of the role to which the current user is assigned.
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// Date timestamp of the last login for the current user.
        /// </summary>
        public string LastLoginDate { get; set; }

        /// <summary>
        /// App groups and the containing apps.
        /// </summary>
        public List<SessionApp> AppGroups { get; set; }

        /// <summary>
        /// Apps that are not in any app groups.
        /// </summary>
        public List<SessionApp> NoGroupApps { get; set; }
        
        /// <summary>
        /// Id for the current session, used in X-DreamFactory-Session-Token header for API requests.
        /// </summary>
        public string SessionId { get; set; }

        /// <summary>
        /// Token for the current session, used in X-DreamFactory-Session-Token header for API requests.
        /// </summary>
        public string SessionToken { get; set; }

        /// <summary>
        /// Timed ticket that can be used to start a separate session.
        /// </summary>
        public string Ticket { get; set; }

        /// <summary>
        /// Expiration time for the given ticket.
        /// </summary>
        public string TicketExpiry { get; set; }

        /// <summary>
        /// Name of the host.
        /// </summary>
        public string Host { get; set; }
    }
}