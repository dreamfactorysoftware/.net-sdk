namespace DreamFactory.Api.Implementation
{
    using System.Globalization;
    using System.Threading.Tasks;
    using DreamFactory.Http;
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
    }
}
