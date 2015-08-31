namespace DreamFactory.Api.Implementation
{
    using System.Globalization;
    using System.Threading.Tasks;
    using DreamFactory.Http;
    using DreamFactory.Model.System.Config;
    using DreamFactory.Serialization;

    internal partial class SystemApi : ISystemApi
    {
        private readonly IHttpAddress baseAddress;
        private readonly IHttpFacade httpFacade;
        private readonly IContentSerializer contentSerializer;
        private readonly HttpHeaders baseHeaders;

        public SystemApi(IHttpAddress baseAddress, IHttpFacade httpFacade, IContentSerializer contentSerializer, HttpHeaders baseHeaders)
        {
            this.baseAddress = baseAddress.WithResource("system");
            this.httpFacade = httpFacade;
            this.contentSerializer = contentSerializer;
            this.baseHeaders = baseHeaders;
        }

        public async Task<ConfigResponse> GetConfigAsync()
        {
            IHttpAddress address = baseAddress.WithResource("config");
            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            return contentSerializer.Deserialize<ConfigResponse>(response.Body);
        }

        public async Task<ConfigResponse> SetConfigAsync(ConfigRequest config)
        {
            IHttpAddress address = baseAddress.WithResource("config");
            string body = contentSerializer.Serialize(config);
            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), baseHeaders, body);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            return contentSerializer.Deserialize<ConfigResponse>(response.Body);
        }
    }
}
