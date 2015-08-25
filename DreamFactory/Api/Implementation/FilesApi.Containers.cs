namespace DreamFactory.Api.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using DreamFactory.Http;
    using DreamFactory.Model.File;

    internal partial class FilesApi
    {
        #region --- /files ---

        public async Task<IEnumerable<ContainerInfo>> GetAccessComponentsAsync()
        {
            IHttpAddress address = baseAddress.WithParameter("include_properties", true);
            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), baseHeaders);
            
            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            var data = new { container = new List<ContainerInfo>() };
            return contentSerializer.Deserialize(response.Body, data).container;
        }

        public async Task<IEnumerable<string>> GetContainerNamesAsync()
        {
            var containers = await GetAccessComponentsAsync();
            return containers.Select(x => x.Name);
        }

        public async Task CreateContainersAsync(bool checkExists, params string[] containers)
        {
            if (containers == null)
            {
                throw new ArgumentNullException("containers");
            }

            if (containers.Length < 1)
            {
                throw new ArgumentException("At least one container name must be provided", "containers");
            }

            IHttpAddress address = baseAddress.WithParameter("check_exist", checkExists);

            var data = new { container = containers.Select(x => new ContainerInfo { Name = x, Path = x }) };
            string body = contentSerializer.Serialize(data);
            IHttpRequest request = new HttpRequest(HttpMethod.Post, address.Build(), baseHeaders, body);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);
        }

        public async Task DeleteContainersAsync(params string[] containers)
        {
            if (containers == null)
            {
                throw new ArgumentNullException("containers");
            }

            if (containers.Length < 1)
            {
                throw new ArgumentException("At least one container name must be provided", "containers");
            }

            var data = new { container = containers.Select(x => new { name = x, path = x }) };
            string body = contentSerializer.Serialize(data);
            IHttpRequest request = new HttpRequest(HttpMethod.Delete, baseAddress.Build(), baseHeaders, body);
            request.SetTunnelingWith(HttpMethod.Post);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);
        }

        #endregion

        #region --- /files/{container}/ ---

        public async Task<ContainerResponse> GetContainerAsync(string container, ListingFlags flags)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            IHttpAddress address = baseAddress.WithResource( container, string.Empty);
            address = AddListingParameters(address, flags);
            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            return contentSerializer.Deserialize<ContainerResponse>(response.Body);
        }

        public async Task<byte[]> DownloadContainerAsync(string container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            IHttpAddress address = baseAddress.WithResource( container, string.Empty)
                                              .WithParameter("zip", true);
            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            return response.RawBody;
        }

        public async Task UploadContainerAsync(string container, string url, bool clean)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            if (url == null)
            {
                throw new ArgumentNullException("url");
            }

            HttpUtils.CheckUrlString(url);

            IHttpAddress address = baseAddress
                .WithResource( container, string.Empty)
                .WithParameter("extract", true)
                .WithParameter("clean", clean)
                .WithParameter("url", url);

            IHttpRequest request = new HttpRequest(HttpMethod.Post, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);
        }

        public async Task DeleteContainerAsync(string container, bool force = false)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            IHttpAddress address = baseAddress.WithResource( container, string.Empty)
                                              .WithParameter("force", force);

            IHttpRequest request = new HttpRequest(HttpMethod.Delete, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);
        }

        #endregion
    }
}
