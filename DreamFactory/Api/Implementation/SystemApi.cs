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
        private readonly IHttpHeaders baseHeaders;

        public SystemApi(IHttpAddress baseAddress, IHttpFacade httpFacade, IContentSerializer contentSerializer, IHttpHeaders baseHeaders)
        {
            this.baseAddress = baseAddress;
            this.httpFacade = httpFacade;
            this.contentSerializer = contentSerializer;
            this.baseHeaders = baseHeaders;
        }

        public async Task<byte[]> DownloadApplicationPackageAsync(int applicationId, bool includeFiles, bool includeServices, bool includeSchema)
        {
            IHttpAddress address = baseAddress.WithResources("system", "app",
                applicationId.ToString(CultureInfo.InvariantCulture))
                .WithParameter("pkg", true)
                .WithParameter("include_files", includeFiles)
                .WithParameter("include_services", includeServices)
                .WithParameter("include_schema", includeSchema);

            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            return response.RawBody;
        }

        public async Task<byte[]> DownloadApplicationSdkAsync(int applicationId)
        {
            IHttpAddress address = baseAddress.WithResources("system", "app",
                applicationId.ToString(CultureInfo.InvariantCulture))
                .WithParameter("sdk", true);

            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            return response.RawBody;
        }

        public async Task<ConfigResponse> GetConfigAsync()
        {
            IHttpAddress address = baseAddress.WithResources("system", "config");
            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            return contentSerializer.Deserialize<ConfigResponse>(response.Body);
        }

        public async Task<ConfigResponse> SetConfigAsync(ConfigRequest config)
        {
            IHttpAddress address = baseAddress.WithResources("system", "config");
            string body = contentSerializer.Serialize(config);
            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), baseHeaders, body);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            return contentSerializer.Deserialize<ConfigResponse>(response.Body);
        }
    }
}
