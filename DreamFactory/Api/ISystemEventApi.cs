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
        /// <param name="query">Query parameters.</param>
        /// <param name="eventScript">Event script to create.</param>
        /// <returns>Event script with queried fields and relationships.</returns>
        Task<EventScriptResponse> CreateEventScriptAsync(string eventName, SqlQuery query, EventScriptRequest eventScript);

        /// <summary>
        /// Update event script.
        /// </summary>
        /// <param name="eventName">Event script identifier.</param>
        /// <param name="query">Query parameters.</param>
        /// <param name="eventScript">Event script to update.</param>
        /// <returns>Event script with queried fields and relationships.</returns>
        Task<EventScriptResponse> UpdateEventScriptAsync(string eventName, SqlQuery query, EventScriptRequest eventScript);

        /// <summary>
        /// Delete event script.
        /// </summary>
        /// <param name="eventName">Event script identifier.</param>
        /// <param name="query">Query parameters.</param>
        /// <returns>Event script with queried fields and relationships.</returns>
        Task<EventScriptResponse> DeleteEventScriptAsync(string eventName, SqlQuery query);
    }
}
