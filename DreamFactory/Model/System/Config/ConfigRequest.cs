namespace DreamFactory.Model.System.Config
{
    using global::System.Collections.Generic;

    /// <summary>
    /// ConfigRequest.
    /// </summary>
    public class ConfigRequest
    {
        /// <summary>
        /// Comma-delimited list of fields the user is allowed to edit.
        /// </summary>
        public string EditableProfileFields { get; set; }

        /// <summary>
        /// An array of HTTP verbs that must be tunneled on this server.
        /// </summary>
        public List<string> RestrictedVerbs { get; set; }

        /// <summary>
        /// The date/time format used for timestamps.
        /// </summary>
        public string TimestampFormat { get; set; }
    }
}
