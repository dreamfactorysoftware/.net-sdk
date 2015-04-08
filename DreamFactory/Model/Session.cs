// ReSharper disable InconsistentNaming
namespace DreamFactory.Model
{
    using System.Collections.Generic;

    /// <summary>
    /// Session.
    /// </summary>
    public class Session
    {
        /// <summary>
        /// Identifier for the current user.
        /// </summary>
        public string id { get; set; }

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
        /// Is the current user a system administrator.
        /// </summary>
        public bool? is_sys_admin { get; set; }

        /// <summary>
        /// Name of the role to which the current user is assigned.
        /// </summary>
        public string role { get; set; }

        /// <summary>
        /// Date timestamp of the last login for the current user.
        /// </summary>
        public string last_login_date { get; set; }

        /// <summary>
        /// App groups and the containing apps.
        /// </summary>
        public List<SessionApp> app_groups { get; set; }

        /// <summary>
        /// Apps that are not in any app groups.
        /// </summary>
        public List<SessionApp> no_group_apps { get; set; }
        
        /// <summary>
        /// Id for the current session, used in X-DreamFactory-Session-Token header for API requests.
        /// </summary>
        public string session_id { get; set; }

        /// <summary>
        /// Timed ticket that can be used to start a separate session.
        /// </summary>
        public string ticket { get; set; }

        /// <summary>
        /// Expiration time for the given ticket.
        /// </summary>
        public string ticket_expiry { get; set; }
    }
}