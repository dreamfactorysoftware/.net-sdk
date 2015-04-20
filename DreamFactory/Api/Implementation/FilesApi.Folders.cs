namespace DreamFactory.Api.Implementation
{
    using System;
    using System.Threading.Tasks;
    using DreamFactory.Http;
    using DreamFactory.Model.File;

    internal partial class FilesApi
    {
        public async Task<FolderResponse> GetFolderAsync(string container, string path, ListingFlags flags)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            if (path == null)
            {
                throw new ArgumentNullException("path");
            }

            IHttpAddress address = baseAddress.WithResources(serviceName, container, path);
            address = AddListingParameters(address, flags);
            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            return contentSerializer.Deserialize<FolderResponse>(response.Body);
        }

        public async Task<byte[]> DownloadFolderAsync(string container, string path, ListingFlags flags)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            if (path == null)
            {
                throw new ArgumentNullException("path");
            }

            IHttpAddress address = baseAddress.WithResources(serviceName, container, path);
            address = AddListingParameters(address, flags).WithParameter("zip", true);
            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            return response.RawBody;
        }

        public async Task CreateFolderAsync(string container, string path, bool checkExists = true)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            if (path == null)
            {
                throw new ArgumentNullException("path");
            }

            IHttpAddress address = baseAddress.WithResources(serviceName, container, path, string.Empty);
            if (checkExists)
            {
                address = address.WithParameter("check_exist", true);
            }

            IHttpRequest request = new HttpRequest(HttpMethod.Post, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);
        }

        public async Task UploadFolderAsync(string container, string path, string url, bool clean)
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
                .WithResources(serviceName, container)
                .WithParameter("extract", true)
                .WithParameter("clean", clean)
                .WithParameter("url", url);

            IHttpRequest request = new HttpRequest(HttpMethod.Post, address.Build(), baseHeaders, string.Empty);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);
        }

        public async Task<FolderResponse> DeleteFolderAsync(string container, string path, bool force = false, bool contentOnly = false)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            if (path == null)
            {
                throw new ArgumentNullException("path");
            }

            IHttpAddress address = baseAddress.WithResources(serviceName, container)
                                              .WithParameter("force", force)
                                              .WithParameter("content_only", contentOnly);

            IHttpRequest request = new HttpRequest(HttpMethod.Delete, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            return contentSerializer.Deserialize<FolderResponse>(response.Body);
        }
    }
}
