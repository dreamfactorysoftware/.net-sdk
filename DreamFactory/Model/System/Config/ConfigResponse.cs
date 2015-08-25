namespace DreamFactory.Model.System.Config
{
    using global::System.Collections.Generic;

    /// <summary>
    /// ConfigResponse.
    /// </summary>
    public class ConfigResponse
    {
        /// <summary>
        /// CORS whitelist of allowed remote hosts.
        /// </summary>
        public List<HostInfo> AllowedHosts { get; set; }

        /// <summary>
        /// Version of the database schema.
        /// </summary>
        public string DbVersion { get; set; }

        /// <summary>
        /// Version of the DSP software.
        /// </summary>
        public string DspVersion { get; set; }

        /// <summary>
        /// Comma-delimited list of fields the user is allowed to edit.
        /// </summary>
        public string EditableProfileFields { get; set; }

        /// <summary>
        /// Role Id assigned for all guest sessions, set to null to require authenticated sessions.
        /// </summary>
        public int? GuestRoleId { get; set; }

        /// <summary>
        /// The name of the installation type for this server.
        /// </summary>
        public string InstallName { get; set; }

        /// <summary>
        /// The internal installation type ID for this server.
        /// </summary>
        public int? InstallType { get; set; }

        /// <summary>
        /// Set to an email-type service id to allow user invites and invite confirmations via email service.
        /// </summary>
        public int? InviteEmailServiceId { get; set; }

        /// <summary>
        /// Default email template used for user invitations and confirmations via email service.
        /// </summary>
        public int? InviteEmailTemplateId { get; set; }

        /// <summary>
        /// True if the current user has not logged in.
        /// </summary>
        public bool? IsGuest { get; set; }

        /// <summary>
        /// True if this is a free hosted DreamFactory DSP.
        /// </summary>
        public bool? IsHosted { get; set; }

        /// <summary>
        /// True if this is a non-free DreamFactory hosted DSP.
        /// </summary>
        public bool? IsPrivate { get; set; }

        /// <summary>
        /// Set to an email-type service id to require email confirmation of newly registered users.
        /// </summary>
        public int? OpenRegEmailServiceId { get; set; }

        /// <summary>
        /// Default email template used for open registration email confirmations.
        /// </summary>
        public int? OpenRegEmailTemplateId { get; set; }

        /// <summary>
        /// Default Role Id assigned to newly registered users, set to null to turn off open registration.
        /// </summary>
        public int? OpenRegRoleId { get; set; }

        /// <summary>
        /// Set to an email-type service id to require email confirmation to reset passwords, otherwise defaults to security question and answer.
        /// </summary>
        public int? PasswordEmailServiceId { get; set; }

        /// <summary>
        /// Default email template used for password reset email confirmations.
        /// </summary>
        public int? PasswordEmailTemplateId { get; set; }

        /// <summary>
        /// An array of the various absolute paths of this server.
        /// </summary>
        public Dictionary<string, string> Paths { get; set; }

        /// <summary>
        /// An array of HTTP verbs that must be tunnelled on this server.
        /// </summary>
        public List<string> RestrictedVerbs { get; set; }

        /// <summary>
        /// An array of the current platform state from various perspectives.
        /// </summary>
        public StateInfo States { get; set; }

        /// <summary>
        /// The date/time format used for timestamps.
        /// </summary>
        public string TimestampFormat { get; set; }
    }
}
