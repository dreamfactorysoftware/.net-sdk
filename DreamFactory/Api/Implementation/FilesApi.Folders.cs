namespace DreamFactory.Api.Implementation
{
    using System;
    using System.Threading.Tasks;
    using DreamFactory.Http;
    using DreamFactory.Model.File;

    internal partial class FilesApi
    {
        public async Task<FolderResponse> GetFolderAsync(string path, ListingFlags flags)
        {
            if (path == null)
            {
                throw new ArgumentNullException("path");
            }

            IHttpAddress address = baseAddress.WithResource(path, string.Empty);
            address = AddListingParameters(address, flags);
            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            return contentSerializer.Deserialize<FolderResponse>(response.Body);
        }

        public async Task<byte[]> DownloadFolderAsync(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException("path");
            }

            IHttpAddress address = baseAddress.WithResource(path, string.Empty)
                                              .WithParameter("zip", true);
            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            return response.RawBody;
        }

        public async Task<FolderResponse> CreateFolderAsync(string path, bool checkExists = true)
        {
            if (path == null)
            {
                throw new ArgumentNullException("path");
            }

            IHttpAddress address = baseAddress.WithResource(path, string.Empty);
            if (checkExists)
            {
                address = address.WithParameter("check_exist", true);
            }

            IHttpRequest request = new HttpRequest(HttpMethod.Post, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            return contentSerializer.Deserialize<FolderResponse>(response.Body);
        }

        public async Task<FolderResponse> UploadFolderAsync(string path, string url, bool clean)
        {
            if (url == null)
            {
                throw new ArgumentNullException("url");
            }

            HttpUtils.CheckUrlString(url);

            IHttpAddress address = baseAddress
                .WithResource(path, string.Empty)
                .WithParameter("extract", true)
                .WithParameter("clean", clean)
                .WithParameter("url", url);

            IHttpRequest request = new HttpRequest(HttpMethod.Post, address.Build(), baseHeaders, string.Empty);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            return contentSerializer.Deserialize<FolderResponse>(response.Body);
        }

        public async Task<FolderResponse> DeleteFolderAsync(string path, bool force = false)
        {
            if (path == null)
            {
                throw new ArgumentNullException("path");
            }

            IHttpAddress address = baseAddress.WithResource(path, string.Empty)
                                              .WithParameter("force", force);

            IHttpRequest request = new HttpRequest(HttpMethod.Delete, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            return contentSerializer.Deserialize<FolderResponse>(response.Body);
        }
    }
}
