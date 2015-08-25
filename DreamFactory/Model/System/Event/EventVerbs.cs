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
        public string type { get; set; }

        /// <summary>
        /// An array of event names triggered by this path/verb combo.
        /// </summary>
        public List<string> @event { get; set; }

        /// <summary>
        /// An array of scripts registered to this event.
        /// </summary>
        public List<string> scripts { get; set; }

        /// <summary>
        /// An array of listeners registered to this event.
        /// </summary>
        public List<string> listeners { get; set; }
    }
}