namespace DreamFactory.Api.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DreamFactory.Http;
    using DreamFactory.Model.Database;
    using DreamFactory.Model.System.Event;

    internal partial class SystemApi
    {
        public Task<EventScriptResponse> GetEventScriptAsync(string eventName, SqlQuery query)
        {
            return QueryRecordAsync<EventScriptResponse>("event", eventName, query);
        }

        public Task<EventScriptResponse> CreateEventScriptAsync(string eventName, EventScriptRequest eventScript, SqlQuery query)
        {
            return CreateOrUpdateRecordAsync<EventScriptRequest, EventScriptResponse>("event", eventName, eventScript, HttpMethod.Post, query);
        }

        public Task<EventScriptResponse> UpdateEventScriptAsync(string eventName, EventScriptRequest eventScript, SqlQuery query)
        {
            return CreateOrUpdateRecordAsync<EventScriptRequest, EventScriptResponse>("event", eventName, eventScript, HttpMethod.Patch, query);
        }

        public Task<EventScriptResponse> DeleteEventScriptAsync(string eventName, SqlQuery query)
        {
            return DeleteRecordAsync<EventScriptResponse>("event", eventName, query);
        }
    }
}
