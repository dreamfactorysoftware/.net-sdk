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

            IHttpAddress address = baseAddress.WithResource(filepath).WithParameter("check_exist", checkExists);
            IHttpRequest request = new HttpRequest(HttpMethod.Post, address.Build(), baseHeaders, content);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);
            
            return contentSerializer.Deserialize<FileResponse>(response.Body);
        }

        public async Task<FileResponse> CreateFileAsync(string filepath, byte[] contents, bool checkExists = true)
        {
            return await CreateFileAsync(filepath, GetString(contents), checkExists);
        }

        public Task ReplaceFileContentsAsync(string filepath, byte[] contents)
        {
            return ReplaceFileContentsAsync(filepath, GetString(contents));
        }

        public async Task ReplaceFileContentsAsync(string filepath, string contents)
        {
            if (filepath == null)
            {
                throw new ArgumentNullException("filepath");
            }

            if (contents == null)
            {
                throw new ArgumentNullException("contents");
            }

            IHttpAddress address = baseAddress.WithResource(filepath);
            IHttpRequest request = new HttpRequest(HttpMethod.Put, address.Build(), baseHeaders.Exclude(HttpHeaders.ContentTypeHeader), contents);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);
        }

        public async Task<string> GetTextFileAsync(string filepath)
        {
            if (filepath == null)
            {
                throw new ArgumentNullException("filepath");
            }

            IHttpAddress address = baseAddress.WithResource(filepath);
            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            return response.Body;
        }

        public async Task<byte[]> GetBinaryFileAsync(string filepath)
        {
            if (filepath == null)
            {
                throw new ArgumentNullException("filepath");
            }

            IHttpAddress address = baseAddress.WithResource(filepath);
            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), baseHeaders.Include(HttpHeaders.AcceptHeader, OctetStream));

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            return response.RawBody;
        }

        public async Task<FileResponse> DeleteFileAsync(string filepath)
        {
            if (filepath == null)
            {
                throw new ArgumentNullException("filepath");
            }

            IHttpAddress address = baseAddress.WithResource(filepath);

            IHttpRequest request = new HttpRequest(HttpMethod.Delete, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            return contentSerializer.Deserialize<FileResponse>(response.Body);
        }

        private static IHttpAddress AddListingParameters(IHttpAddress source, ListingFlags mode)
        {
            int modeInt = (int)mode;

            if ((modeInt & (int)ListingFlags.IncludeFiles) != 0)
            {
                source = source.WithParameter("include_files", true);
            }

            if ((modeInt & (int)ListingFlags.IncludeFolders) != 0)
            {
                source = source.WithParameter("include_folders", true);
            }

            if ((modeInt & (int)ListingFlags.IncludeProperties) != 0)
            {
                source = source.WithParameter("include_properties", true);
            }

            if ((modeInt & (int)ListingFlags.IncludeSubFolders) != 0)
            {
                source = source.WithParameter("full_tree", true);
            }

            return source;
        }

        static string GetString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }
    }
}
