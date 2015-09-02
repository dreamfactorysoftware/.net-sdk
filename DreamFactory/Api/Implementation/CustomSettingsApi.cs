namespace DreamFactory.Api.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using DreamFactory.Http;
    using DreamFactory.Model;
    using DreamFactory.Model.Database;
    using DreamFactory.Model.System.Custom;
    using DreamFactory.Serialization;

    internal class CustomSettingsApi : ICustomSettingsApi
    {
        private readonly IHttpAddress baseAddress;
        private readonly IHttpFacade httpFacade;
        private readonly IContentSerializer contentSerializer;
        private readonly IHttpHeaders baseHeaders;

        public CustomSettingsApi(
            IHttpAddress baseAddress,
            IHttpFacade httpFacade,
            IContentSerializer contentSerializer,
            IHttpHeaders baseHeaders,
            string serviceName)
        {
            this.baseAddress = baseAddress.WithResource(serviceName);
            this.httpFacade = httpFacade;
            this.contentSerializer = contentSerializer;
            this.baseHeaders = baseHeaders;
        }

        public async Task<IEnumerable<CustomResponse>> GetCustomSettingsAsync(SqlQuery query = null)
        {
            IHttpAddress address = baseAddress.WithResource("custom");
            if (query != null)
            {
                address = address.WithSqlQuery(query);
            }

            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            var settings = new { resource = new List<CustomResponse>() };
            return contentSerializer.Deserialize(response.Body, settings).resource;
        }
        
        public async Task<IEnumerable<CustomResponse>> SetCustomSettingsAsync(List<CustomRequest> customs, SqlQuery query = null)
        {
            IHttpAddress address = baseAddress.WithResource("custom");

            if (query != null)
            {
                address.WithSqlQuery(query);
            }

            var body = new { resource = customs, ids = customs.Select((item, index) => index) };
            string content = contentSerializer.Serialize(body);
            IHttpRequest request = new HttpRequest(HttpMethod.Post, address.Build(), baseHeaders, content);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            var resources = new { resource = new List<CustomResponse>() };
            return contentSerializer.Deserialize(response.Body, resources).resource;
        }

        public async Task<IEnumerable<CustomResponse>> UpdateCustomSettingsAsync(List<CustomRequest> customs, SqlQuery query = null)
        {
            IHttpAddress address = baseAddress.WithResource("custom");

            if (query != null)
            {
                address.WithSqlQuery(query);
            }

            var body = new { resource = customs, ids = customs.Select((item, index) => index) };
            string content = contentSerializer.Serialize(body);
            IHttpRequest request = new HttpRequest(HttpMethod.Patch, address.Build(), baseHeaders, content);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            var resources = new { resource = new List<CustomResponse>() };
            return contentSerializer.Deserialize(response.Body, resources).resource;
        }

        public async Task<IEnumerable<CustomResponse>> DeleteAllCustomSettingsAsync(SqlQuery query = null)
        {
            IHttpAddress address = baseAddress.WithResource("custom");

            address = address.WithParameter("force", true);

            if (query != null)
            {
                address = address.WithSqlQuery(query);
            }

            IHttpRequest request = new HttpRequest(HttpMethod.Delete, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            var settings = new { resource = new List<CustomResponse>() };
            return contentSerializer.Deserialize(response.Body, settings).resource;
        }

        public async Task<CustomResponse> GetCustomSettingAsync(string settingName, SqlQuery query = null)
        {
            if (settingName == null)
            {
                throw new ArgumentNullException("settingName");
            }

            IHttpAddress address = baseAddress.WithResource("custom", settingName);

            if (query != null)
            {
                address = address.WithSqlQuery(query);
            }

            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            return new CustomResponse
            {
                Name = settingName,
                Value = response.Body
            };
        }

        public async Task<CustomResponse> UpdateCustomSettingAsync(string settingName, CustomRequest custom, SqlQuery query = null)
        {
            if (settingName == null)
            {
                throw new ArgumentNullException("settingName");
            }

            IHttpAddress address = baseAddress.WithResource("custom", settingName);

            if (query != null)
            {
                address = address.WithSqlQuery(query);
            }

            string content = contentSerializer.Serialize(custom);
            IHttpRequest request = new HttpRequest(HttpMethod.Patch, address.Build(), baseHeaders, content);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            return contentSerializer.Deserialize<CustomResponse>(response.Body);
        }

        public async Task<CustomResponse> DeleteCustomSettingAsync(string settingName, SqlQuery query = null)
        {
            if (settingName == null)
            {
                throw new ArgumentNullException("settingName");
            }

            var address = baseAddress.WithResource("custom", settingName);
            IHttpRequest request = new HttpRequest(HttpMethod.Delete, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            return contentSerializer.Deserialize<CustomResponse>(response.Body);
        }
    }
}
