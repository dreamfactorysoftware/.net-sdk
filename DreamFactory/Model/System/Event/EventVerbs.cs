namespace DreamFactory.Model.System.Event
{
    using global::System.Collections.Generic;

    /// <summary>
    /// EventVerbs.
    /// </summary>
    public class EventVerbs
    {
        /// <summary>
        /// The verb for this path.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// An array of event names triggered by this path/verb combo.
        /// </summary>
        public List<string> Event { get; set; }

        /// <summary>
        /// An array of scripts registered to this event.
        /// </summary>
        public List<string> Scripts { get; set; }

        /// <summary>
        /// An array of listeners registered to this event.
        /// </summary>
        public List<string> Listeners { get; set; }
    }
}