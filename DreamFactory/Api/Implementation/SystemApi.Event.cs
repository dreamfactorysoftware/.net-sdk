namespace DreamFactory.Api.Implementation
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DreamFactory.Http;
    using DreamFactory.Model;
    using DreamFactory.Model.Database;
    using DreamFactory.Model.System.Event;

    internal partial class SystemApi
    {
        public Task<EventScriptResponse> GetEventScriptAsync(string eventName, SqlQuery query)
        {
            return base.RequestAsync<EventScriptResponse>(
                method: HttpMethod.Get,
                resource: "event",
                resourceIdentifier: eventName,
                query: query
                );
        }

        public async Task<IEnumerable<string>> GetEventsAsync()
        {
            ResourceWrapper<string> response = await base.RequestAsync<ResourceWrapper<string>>(
                method: HttpMethod.Get,
                resource: "event",
                query: new SqlQuery { Fields = null, CustomParameters = new Dictionary<string, object> { { "as_list", true } } }
                );

            return response.Records;
        }


        public Task<EventScriptResponse> CreateEventScriptAsync(string eventName, SqlQuery query, EventScriptRequest eventScript)
        {
            return base.RequestWithPayloadAsync<EventScriptRequest, EventScriptResponse>(
                method: HttpMethod.Post,
                resource: "event",
                resourceIdentifier: eventName,
                query: query,
                payload: eventScript
                );
        }

        public Task<EventScriptResponse> DeleteEventScriptAsync(string eventName, SqlQuery query)
        {
            return base.RequestAsync<EventScriptResponse>(
                method: HttpMethod.Delete,
                resource: "event",
                resourceIdentifier: eventName,
                query: query
                );
        }
    }
}
