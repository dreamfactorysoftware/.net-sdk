namespace DreamFactory.Model.System.Event
{
    using global::System.Collections.Generic;

    /// <summary>
    /// EventResponse.
    /// </summary>
    public class EventResponse
    {
        /// <summary>
        /// The name of this event.
        /// </summary>
        public string EventName { get; set; }

        /// <summary>
        /// An array of listeners attached to this event.
        /// </summary>
        public List<string> Listeners { get; set; }
    }
}
