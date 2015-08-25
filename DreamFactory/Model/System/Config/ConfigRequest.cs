namespace DreamFactory.Model.System.Config
{
    using global::System.Collections.Generic;

    /// <summary>
    /// ConfigRequest.
    /// </summary>
    public class ConfigRequest
    {
        /// <summary>
        /// CORS whitelist of allowed remote hosts.
        /// </summary>
        public List<HostInfo> allowed_hosts { get; set; }

        /// <summary>
        /// Comma-delimited list of fields the user is allowed to edit.
        /// </summary>
        public string editable_profile_fields { get; set; }

        /// <summary>
        /// Role Id assigned for all guest sessions, set to null to require authenticated sessions.
        /// </summary>
        public int? guest_role_id { get; set; }

        /// <summary>
        /// The name of the installation type for this server.
        /// </summary>
        public string install_name { get; set; }

        /// <summary>
        /// The internal installation type ID for this server.
        /// </summary>
        public int? install_type { get; set; }

        /// <summary>
        /// Set to an email-type service id to allow user invites and invite confirmations via email service.
        /// </summary>
        public int? invite_email_service_id { get; set; }

        /// <summary>
        /// Default email template used for user invitations and confirmations via email service.
        /// </summary>
        public int? invite_email_template_id { get; set; }

        /// <summary>
        /// True if the current user has not logged in.
        /// </summary>
        public bool? is_guest { get; set; }

        /// <summary>
        /// True if this is a free hosted DreamFactory DSP.
        /// </summary>
        public bool? is_hosted { get; set; }

        /// <summary>
        /// True if this is a non-free DreamFactory hosted DSP.
        /// </summary>
        public bool? is_private { get; set; }

        /// <summary>
        /// Set to an email-type service id to require email confirmation of newly registered users.
        /// </summary>
        public int? open_reg_email_service_id { get; set; }

        /// <summary>
        /// Default email template used for open registration email confirmations.
        /// </summary>
        public int? open_reg_email_template_id { get; set; }

        /// <summary>
        /// Default Role Id assigned to newly registered users, set to null to turn off open registration.
        /// </summary>
        public int? open_reg_role_id { get; set; }

        /// <summary>
        /// Set to an email-type service id to require email confirmation to reset passwords, otherwise defaults to security question and answer.
        /// </summary>
        public int? password_email_service_id { get; set; }

        /// <summary>
        /// Default email template used for password reset email confirmations.
        /// </summary>
        public int? password_email_template_id { get; set; }

        /// <summary>
        /// An array of the various absolute paths of this server.
        /// </summary>
        public Dictionary<string, string> paths { get; set; }

        /// <summary>
        /// An array of HTTP verbs that must be tunnelled on this server.
        /// </summary>
        public List<string> restricted_verbs { get; set; }

        /// <summary>
        /// An array of the current platform state from various perspectives.
        /// </summary>
        public StateInfo states { get; set; }

        /// <summary>
        /// The date/time format used for timestamps.
        /// </summary>
        public string timestamp_format { get; set; }
    }
}
