namespace DreamFactory.Api.Implementation
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using DreamFactory.Http;
    using DreamFactory.Model.File;
    using DreamFactory.Serialization;

    internal partial class FilesApi : IFilesApi
    {
        private const string OctetStream = "application/octet-stream";

        private readonly IHttpAddress baseAddress;
        private readonly IHttpFacade httpFacade;
        private readonly IContentSerializer contentSerializer;
        private readonly IHttpHeaders baseHeaders;

        public FilesApi(IHttpAddress baseAddress, IHttpFacade httpFacade, IContentSerializer contentSerializer, IHttpHeaders baseHeaders, string serviceName)
        {
            this.baseAddress = baseAddress.WithResource(serviceName);
            this.httpFacade = httpFacade;
            this.contentSerializer = contentSerializer;
            this.baseHeaders = baseHeaders;
        }

        public async Task<IEnumerable<StorageResource>> GetResourcesAsync(ListingFlags flags)
        {
            IHttpAddress address = baseAddress.WithResource(string.Empty);
            address = AddListingParameters(address, flags);
            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            var resources = new { resource = new List<StorageResource>() };
            return contentSerializer.Deserialize(response.Body, resources).resource;
        }

        public async Task<IEnumerable<string>> GetResourceNamesAsync()
        {
            var containers = await GetResourcesAsync(ListingFlags.IncludeFiles | ListingFlags.IncludeFolders);
            return containers.Select(x => x.Name);
        }
    }
}
