namespace DreamFactory.Api.Implementation
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DreamFactory.Http;
    using DreamFactory.Model.System.Config;
    using DreamFactory.Model.System.Environment;
    using DreamFactory.Serialization;

    internal partial class SystemApi : BaseApi, ISystemApi
    {
        public SystemApi(IHttpAddress baseAddress, IHttpFacade httpFacade, IContentSerializer contentSerializer, HttpHeaders baseHeaders)
            : base(baseAddress, httpFacade, contentSerializer, baseHeaders, "system")
        {
        }

        public async Task<EnvironmentResponse> GetEnvironmentAsync()
        {
            IHttpAddress address = BaseAddress.WithResource("environment");
            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), BaseHeaders);

            IHttpResponse response = await HttpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, ContentSerializer);

            return ContentSerializer.Deserialize<EnvironmentResponse>(response.Body);
        }

        public async Task<IEnumerable<string>> GetConstantsAsync()
        {
            IHttpAddress address = BaseAddress.WithResource("constant");
            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), BaseHeaders);

            IHttpResponse response = await HttpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, ContentSerializer);

            Dictionary<string, object> types = ContentSerializer.Deserialize<Dictionary<string, object>>(response.Body);
            return types.Keys;
        }

        public async Task<Dictionary<string, string>> GetConstantAsync(string constant)
        {
            IHttpAddress address = BaseAddress.WithResource("constant", constant);
            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), BaseHeaders);

            IHttpResponse response = await HttpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, ContentSerializer);

            return ContentSerializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(response.Body)[constant];
        }

        public async Task<ConfigResponse> GetConfigAsync()
        {
            IHttpAddress address = BaseAddress.WithResource("config");
            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), BaseHeaders);

            IHttpResponse response = await HttpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, ContentSerializer);

            return ContentSerializer.Deserialize<ConfigResponse>(response.Body);
        }

        public async Task<ConfigResponse> SetConfigAsync(ConfigRequest config)
        {
            IHttpAddress address = BaseAddress.WithResource("config");
            string body = ContentSerializer.Serialize(config);
            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), BaseHeaders, body);

            IHttpResponse response = await HttpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, ContentSerializer);

            return ContentSerializer.Deserialize<ConfigResponse>(response.Body);
        }
    }
}
