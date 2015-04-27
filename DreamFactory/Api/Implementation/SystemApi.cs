namespace DreamFactory.Api.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DreamFactory.Http;
    using DreamFactory.Model.System;
    using DreamFactory.Serialization;

    internal class SystemApi : ISystemApi
    {
        private readonly IHttpAddress baseAddress;
        private readonly IHttpFacade httpFacade;
        private readonly IContentSerializer contentSerializer;
        private readonly IHttpHeaders baseHeaders;

        public SystemApi(IHttpAddress baseAddress, IHttpFacade httpFacade, IContentSerializer contentSerializer, IHttpHeaders baseHeaders)
        {
            this.baseAddress = baseAddress;
            this.httpFacade = httpFacade;
            this.contentSerializer = contentSerializer;
            this.baseHeaders = baseHeaders;
        }

        public async Task<IEnumerable<AppResponse>> GetAppsAsync()
        {
            IHttpAddress address = baseAddress.WithResources("system", "app");
            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            var apps = new { record = new List<AppResponse>() };
            return contentSerializer.Deserialize(response.Body, apps).record;
        }

        public async Task<IEnumerable<AppResponse>> CreateAppsAsync(params AppRequest[] apps)
        {
            IHttpResponse response = await CreateOrUpdateApps(HttpMethod.Post, apps);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            var responses = new { record = new List<AppResponse>() };
            return contentSerializer.Deserialize(response.Body, responses).record;
        }

        public async Task UpdateAppsAsync(params AppRequest[] apps)
        {
            await CreateOrUpdateApps(HttpMethod.Patch, apps);
        }

        public async Task DeleteAppsAsync(bool deleteStorage = false, params int[] ids)
        {
            if (ids == null || ids.Length < 1)
            {
                throw new ArgumentException("At least one application ID must be specificed", "ids");
            }

            string list = string.Join(",", ids);
            IHttpAddress address = baseAddress.WithResources("system", "app").WithParameter("ids", list);
            if (deleteStorage)
            {
                address = address.WithParameter("delete_storage", true);
            }
            
            IHttpRequest request = new HttpRequest(HttpMethod.Delete, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);
        }

        private async Task<IHttpResponse> CreateOrUpdateApps(HttpMethod method, params AppRequest[] apps)
        {
            if (apps == null || apps.Length < 1)
            {
                throw new ArgumentException("At least one application must be specificed", "apps");
            }

            IHttpAddress address = baseAddress.WithResources("system", "app");
            var requests = new { record = new List<AppRequest>(apps) };
            string body = contentSerializer.Serialize(requests);
            IHttpRequest request = new HttpRequest(method, address.Build(), baseHeaders, body);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            return response;
        }
    }
}
