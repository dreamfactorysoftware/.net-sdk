namespace DreamFactory.Model.System.Event
{
    using global::System.Collections.Generic;

    /// <summary>
    /// EventRequest.
    /// </summary>
    public class EventRequest
    {
        /// <summary>
        /// The name of this event.
        /// </summary>
        public string event_name { get; set; }

        /// <summary>
        /// An array of listeners attached to this event.
        /// </summary>
        public List<string> listeners { get; set; }
    }
}
