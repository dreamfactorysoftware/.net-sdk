namespace DreamFactory.Api.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DreamFactory.Http;
    using DreamFactory.Model.Database;
    using DreamFactory.Model.File;

    internal partial class FilesApi
    {
        public async Task<FolderResponse> GetFolderAsync(string path, ListingFlags flags)
        {
            if (path == null)
            {
                throw new ArgumentNullException("path");
            }

            SqlQuery query = new SqlQuery();
            query.CustomParameters = AddListingParameters(query.CustomParameters, flags);

            return await base.RequestSingleAsync<FolderResponse>(HttpMethod.Get, path, string.Empty, query);
        }

        public async Task<byte[]> DownloadFolderAsync(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException("path");
            }

            IHttpAddress address = base.BaseAddress.WithResource(path, string.Empty);
            address = address.WithParameter("zip", true);

            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), base.BaseHeaders);
            IHttpResponse response = await base.HttpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, base.ContentSerializer);

            return response.RawBody;
        }

        public async Task<FolderResponse> CreateFolderAsync(string path, bool checkExists = true)
        {
            if (path == null)
            {
                throw new ArgumentNullException("path");
            }

            SqlQuery query = new SqlQuery();
            query.CustomParameters.Add("check_exist", checkExists);

            return await base.RequestSingleAsync<FolderResponse>(HttpMethod.Post, path, string.Empty, query);
        }

        public async Task<FolderResponse> UploadFolderAsync(string path, string url, bool clean)
        {
            if (path == null)
            {
                throw new ArgumentNullException("path");
            }

            if (url == null)
            {
                throw new ArgumentNullException("url");
            }

            HttpUtils.CheckUrlString(url);

            SqlQuery query = new SqlQuery();
            query.CustomParameters.Add("extract", true);
            query.CustomParameters.Add("clean", clean);
            query.CustomParameters.Add("url", url);

            return await RequestSingleAsync<FolderResponse>(HttpMethod.Post, path, string.Empty, query);
        }

        public async Task<FolderResponse> DeleteFolderAsync(string path, bool force = false)
        {
            if (path == null)
            {
                throw new ArgumentNullException("path");
            }

            return await RequestSingleAsync<FolderResponse>(
                HttpMethod.Delete,
                path, 
                string.Empty,
                new SqlQuery { CustomParameters = new Dictionary<string, object> { { "force", force } } }
                );
        }
    }
}
