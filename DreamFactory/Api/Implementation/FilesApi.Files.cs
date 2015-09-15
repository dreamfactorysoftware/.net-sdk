namespace DreamFactory.Api.Implementation
{
    using System;
    using System.Threading.Tasks;
    using DreamFactory.Http;
    using DreamFactory.Model.Database;
    using DreamFactory.Model.File;

    internal partial class FilesApi
    {
        public async Task<FileResponse> CreateFileAsync(string filepath, string content, bool checkExists = true)
        {
            if (filepath == null)
            {
                throw new ArgumentNullException("filepath");
            }

            if (content == null)
            {
                throw new ArgumentNullException("content");
            }

            IHttpAddress address = base.BaseAddress.WithResource(filepath);
            address = address.WithParameter("check_exist", checkExists);
            IHttpRequest request = new HttpRequest(HttpMethod.Post, address.Build(), base.BaseHeaders, content);
            return await ExecuteRequest<FileResponse>(request);
        }

        public async Task<FileResponse> CreateFileAsync(string filepath, byte[] contents, bool checkExists = true)
        {
            return await CreateFileAsync(filepath, GetString(contents), checkExists);
        }

        public async Task<FileResponse> ReplaceFileContentsAsync(string filepath, byte[] contents)
        {
            return await ReplaceFileContentsAsync(filepath, GetString(contents));
        }

        public async Task<FileResponse> ReplaceFileContentsAsync(string filepath, string contents)
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

            return await base.ExecuteRequest<FileResponse>(request);
        }

        public async Task<string> GetTextFileAsync(string filepath)
        {
            if (filepath == null)
            {
                throw new ArgumentNullException("filepath");
            }

            IHttpAddress address = base.BaseAddress.WithResource(filepath);
            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), base.BaseHeaders);
            IHttpResponse response = await base.HttpFacade.RequestAsync(request);

            HttpUtils.ThrowOnBadStatus(response, base.ContentSerializer);

            return response.Body;
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

        public async Task<FileResponse> DeleteFileAsync(string filepath)
        {
            if (filepath == null)
            {
                throw new ArgumentNullException("filepath");
            }

            return await base.RequestSingleAsync<FileResponse>(HttpMethod.Delete, new[] { filepath }, new SqlQuery());
        }

        static string GetString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }
    }
}
