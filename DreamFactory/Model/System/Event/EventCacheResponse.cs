namespace DreamFactory.Model.System.Event
{
    using global::System.Collections.Generic;

    /// <summary>
    /// EventCacheResponse.
    /// </summary>
    public class EventCacheResponse
    {
        /// <summary>
        /// The owner API of this event.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// An array of paths which trigger this event.
        /// </summary>
        public List<EventPaths> Paths { get; set; }
    }
}
