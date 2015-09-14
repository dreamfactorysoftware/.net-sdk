namespace DreamFactory.Api
{
    using DreamFactory.Model.Database;
    using DreamFactory.Model.System.Event;
    using global::System.Collections.Generic;
    using global::System.Threading.Tasks;

    /// <summary>
    /// Represents /system/event API.
    /// </summary>
    public interface ISystemEventApi
    {

        /// <summary>
        /// Gets all system events.
        /// </summary>
        /// <returns>List of all event names.</returns>
        Task<IEnumerable<string>> GetEventsAsync();

        /// <summary>
        /// Gets event script by name.
        /// </summary>
        /// <param name="eventName">Event script identifier.</param>
        /// <param name="query">Query parameters.</param>
        /// <returns>Event script with queried fields and relationships.</returns>
        Task<EventScriptResponse> GetEventScriptAsync(string eventName, SqlQuery query);

        /// <summary>
        /// Create event script.
        /// </summary>
        /// <param name="eventName">Event script identifier.</param>
        /// <param name="eventScript">Event script to create.</param>
        /// <param name="query">Query parameters.</param>
        /// <returns>Event script with queried fields and relationships.</returns>
        Task<EventScriptResponse> CreateEventScriptAsync(string eventName, EventScriptRequest eventScript, SqlQuery query);

        /// <summary>
        /// Update event script.
        /// </summary>
        /// <param name="eventName">Event script identifier.</param>
        /// <param name="eventScript">Event script to update.</param>
        /// <param name="query">Query parameters.</param>
        /// <returns>Event script with queried fields and relationships.</returns>
        Task<EventScriptResponse> UpdateEventScriptAsync(string eventName, EventScriptRequest eventScript, SqlQuery query);

        /// <summary>
        /// Delete event script.
        /// </summary>
        /// <param name="eventName">Event script identifier.</param>
        /// <param name="query">Query parameters.</param>
        /// <returns>Event script with queried fields and relationships.</returns>
        Task<EventScriptResponse> DeleteEventScriptAsync(string eventName, SqlQuery query);
    }
}
