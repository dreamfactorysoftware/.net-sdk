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
        public Task<FolderResponse> GetFolderAsync(string path, ListingFlags flags)
        {
            if (path == null)
            {
                throw new ArgumentNullException("path");
            }

            SqlQuery query = new SqlQuery { Fields = null };
            query.CustomParameters = AddListingParameters(query.CustomParameters, flags);

            return base.RequestAsync<FolderResponse>(
                method: HttpMethod.Get,
                resource: path, 
                resourceIdentifier: string.Empty, 
                query: query
                );
        }

        public async Task<byte[]> DownloadFolderAsync(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException("path");
            }

            SqlQuery query = new SqlQuery { Fields = null };
            query.CustomParameters.Add("zip", true);
            IHttpRequest request = base.BuildRequest(HttpMethod.Get, null, new[] { path, string.Empty }, query);

            IHttpResponse response = await base.HttpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, base.ContentSerializer);

            return response.RawBody;
        }

        public Task<FolderResponse> CreateFolderAsync(string path, bool checkExists = true)
        {
            if (path == null)
            {
                throw new ArgumentNullException("path");
            }

            SqlQuery query = new SqlQuery { Fields = null };
            query.CustomParameters.Add("check_exist", checkExists);

            return base.RequestAsync<FolderResponse>(
                method: HttpMethod.Post, 
                resource: path, 
                resourceIdentifier: string.Empty, 
                query: query
                );
        }

        public Task<FolderResponse> UploadFolderAsync(string path, string url, bool clean)
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

            SqlQuery query = new SqlQuery { Fields = null };
            query.CustomParameters.Add("extract", true);
            query.CustomParameters.Add("clean", clean);
            query.CustomParameters.Add("url", url);

            return base.RequestAsync<FolderResponse>(
                method: HttpMethod.Post, 
                resource: path,
                resourceIdentifier: string.Empty,
                query: query
                );
        }

        public Task<FolderResponse> DeleteFolderAsync(string path, bool force = false)
        {
            if (path == null)
            {
                throw new ArgumentNullException("path");
            }

            SqlQuery query = new SqlQuery { Fields = null };
            query.CustomParameters.Add("force", force);

            return base.RequestAsync<FolderResponse>(
                method: HttpMethod.Delete,
                resource: path, 
                resourceIdentifier: string.Empty,
                query: query
                );
        }
    }
}
