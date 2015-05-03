namespace DreamFactory.Api.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DreamFactory.Http;
    using DreamFactory.Model.System.Event;

    internal partial class SystemApi
    {
        public async Task<IEnumerable<EventCacheResponse>> GetEventsAsync(bool allEvents, bool asCached)
        {
            IHttpAddress address = baseAddress.WithResources(SystemService, "event");
            if (allEvents)
            {
                address = address.WithParameter("all_events", true);
            }
            if (asCached)
            {
                address = address.WithParameter("as_cached", true);
            }

            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            var records = new { record = new List<EventCacheResponse>() };
            return contentSerializer.Deserialize(response.Body, records).record;
        }

        public async Task RegisterEventsAsync(params EventRequest[] requests)
        {
            if (requests == null || requests.Length < 1)
            {
                throw new ArgumentException("At least one parameter must be specificed", "requests");
            }

            IHttpAddress address = baseAddress.WithResources(SystemService, "event");
            var records = new { record = new List<EventRequest>(requests) };
            string body = contentSerializer.Serialize(records);
            IHttpRequest request = new HttpRequest(HttpMethod.Post, address.Build(), baseHeaders, body);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);
        }

        public async Task UnregisterEventsAsync(params EventRequest[] requests)
        {
            if (requests == null || requests.Length < 1)
            {
                throw new ArgumentException("At least one parameter must be specificed", "requests");
            }

            IHttpAddress address = baseAddress.WithResources(SystemService, "event");
            var records = new { record = new List<EventRequest>(requests) };
            string body = contentSerializer.Serialize(records);
            IHttpRequest request = new HttpRequest(HttpMethod.Delete, address.Build(), baseHeaders, body);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);
        }
    }
}
