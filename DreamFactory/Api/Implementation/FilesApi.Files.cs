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
        public Task<FileResponse> CreateFileAsync(string filepath, string content, bool checkExists = true)
        {
            if (filepath == null)
            {
                throw new ArgumentNullException("filepath");
            }

            if (content == null)
            {
                throw new ArgumentNullException("content");
            }

            SqlQuery query = new SqlQuery { Fields = null };
            query.CustomParameters.Add("check_exists", checkExists);
            IHttpRequest request = base.BuildRequest(HttpMethod.Post, content, new[] { filepath }, query);

            return ExecuteRequest<FileResponse>(request);
        }

        public Task<FileResponse> CreateFileAsync(string filepath, byte[] contents, bool checkExists = true)
        {
            return CreateFileAsync(filepath, GetString(contents), checkExists);
        }

        public Task<FileResponse> ReplaceFileContentsAsync(string filepath, byte[] contents)
        {
            return ReplaceFileContentsAsync(filepath, GetString(contents));
        }

        public Task<FileResponse> ReplaceFileContentsAsync(string filepath, string contents)
        {
            if (filepath == null)
            {
                throw new ArgumentNullException("filepath");
            }

            if (contents == null)
            {
                throw new ArgumentNullException("contents");
            }

            IHttpAddress address = base.BaseAddress.WithResource(filepath);
            IHttpRequest request = new HttpRequest(HttpMethod.Put, address.Build(), base.BaseHeaders.Exclude(HttpHeaders.ContentTypeHeader), contents);

            return base.ExecuteRequest<FileResponse>(request);
        }

        public Task<string> GetTextFileAsync(string filepath)
        {
            if (filepath == null)
            {
                throw new ArgumentNullException("filepath");
            }

            return base.RequestBodyAsync(HttpMethod.Get, new[] { filepath }, null);
        }

        public async Task<byte[]> GetBinaryFileAsync(string filepath)
        {
            if (filepath == null)
            {
                throw new ArgumentNullException("filepath");
            }

            IHttpAddress address = base.BaseAddress.WithResource(filepath);
            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), base.BaseHeaders.Include(HttpHeaders.AcceptHeader, OctetStream));
            IHttpResponse response = await base.HttpFacade.RequestAsync(request);

            HttpUtils.ThrowOnBadStatus(response, base.ContentSerializer);

            return response.RawBody;
        }

        public Task<FileResponse> DeleteFileAsync(string filepath)
        {
            if (filepath == null)
            {
                throw new ArgumentNullException("filepath");
            }

            return base.RequestAsync<FileResponse>(HttpMethod.Delete, filepath, new SqlQuery());
        }

        static string GetString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }
    }
}
