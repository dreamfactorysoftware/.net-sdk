namespace DreamFactory.Model.System.Event
{
    using global::System.Collections.Generic;

    /// <summary>
    /// EventPaths.
    /// </summary>
    public class EventPaths
    {
        /// <summary>
        /// The full path to which triggers this event.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// An array of path/verb combinations which contain events.
        /// </summary>
        public List<EventVerbs> Verbs { get; set; }
    }
}
