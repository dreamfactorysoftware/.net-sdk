namespace DreamFactory.Model.System.Config
{
    using global::System.Collections.Generic;

    /// <summary>
    /// HostInfo.
    /// </summary>
    public class HostInfo
    {
        /// <summary>
        /// URL, server name, or * to define the CORS host.
        /// </summary>
        public string host { get; set; }

        /// <summary>
        /// Allow this host's configuration to be used by CORS.
        /// </summary>
        public bool? is_enabled { get; set; }

        /// <summary>
        /// Allowed HTTP verbs for this host.
        /// </summary>
        public List<string> verbs { get; set; }
    }
}