namespace DreamFactory.Model.System.Event
{
    /// <summary>
    /// EventScriptRequest.
    /// </summary>
    public class EventScriptRequest
    {
        /// <summary>
        /// Name of this event script
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Type for this event script.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Indicator whether this event script is active.
        /// </summary>
        public bool? IsActive { get; set; }

        /// <summary>
        /// Indicator whether this event script affect process.
        /// </summary>
        public bool? AffectsProcess { get; set; }

        /// <summary>
        /// Content of this event script.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Config for this event script.
        /// </summary>
        public string Config { get; set; }
    }
}
