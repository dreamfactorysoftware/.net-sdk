namespace DreamFactory.Api.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using DreamFactory.Http;
    using DreamFactory.Model;
    using DreamFactory.Model.System.Custom;
    using DreamFactory.Serialization;

    internal class CustomSettingsApi : ICustomSettingsApi
    {
        private const string CustomResource = "custom";

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

        public async Task<IEnumerable<CustomResponse>> GetCustomSettingsAsync()
        {
            var address = baseAddress.WithResource(CustomResource);
            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            var settings = new { resource = new List<CustomResponse>() };
            return contentSerializer.Deserialize(response.Body, settings).resource;
        }

        public async Task<IEnumerable<CustomResponse>> SetCustomSettingAsync(List<CustomRequest> customSettings)
        {
            var address = baseAddress.WithResource(CustomResource);

            var body = new { resource = customSettings, ids = customSettings.Select((item, index) => index) };
            string content = contentSerializer.Serialize(body);
            IHttpRequest request = new HttpRequest(HttpMethod.Post, address.Build(), baseHeaders, content);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            var resources = new { resource = new List<CustomResponse>() };
            return contentSerializer.Deserialize(response.Body, resources).resource;
        }

        public async Task<string> GetCustomSettingAsync(string settingName)
        {
            if (settingName == null)
            {
                throw new ArgumentNullException("settingName");
            }

            var address = baseAddress.WithResource(CustomResource, settingName);
            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            return contentSerializer.Deserialize<string>(response.Body);
        }

        public async Task<CustomResponse> DeleteCustomSettingAsync(string settingName)
        {
            if (settingName == null)
            {
                throw new ArgumentNullException("settingName");
            }

            var address = baseAddress.WithResource(CustomResource, settingName);
            IHttpRequest request = new HttpRequest(HttpMethod.Delete, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            return contentSerializer.Deserialize<CustomResponse>(response.Body);
        }
    }
}
