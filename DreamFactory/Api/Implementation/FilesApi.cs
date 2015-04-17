namespace DreamFactory.Api.Implementation
{
    using System;
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
        private readonly string serviceName;

        public FilesApi(IHttpAddress baseAddress, IHttpFacade httpFacade, IContentSerializer contentSerializer, IHttpHeaders baseHeaders, string serviceName)
        {
            this.baseAddress = baseAddress;
            this.httpFacade = httpFacade;
            this.contentSerializer = contentSerializer;
            this.baseHeaders = baseHeaders;
            this.serviceName = serviceName;
        }

        public async Task<FileResponse> CreateFileAsync(string container, string filepath, string content, bool checkExists = true)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            if (filepath == null)
            {
                throw new ArgumentNullException("filepath");
            }

            if (content == null)
            {
                throw new ArgumentNullException("content");
            }

            IHttpAddress address = baseAddress.WithResources(serviceName, container, filepath).WithParameter("check_exist", checkExists);
            IHttpRequest request = new HttpRequest(HttpMethod.Post, address.Build(), baseHeaders.Exclude(HttpHeaders.ContentTypeHeader), content);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            var data = new { file = new List<FileResponse>() };
            return contentSerializer.Deserialize(response.Body, data).file.First();
        }

        public async Task<FileResponse> CreateFileAsync(string container, string filepath, byte[] content, bool checkExists = true)
        {
            return await CreateFileAsync(container, filepath, GetString(content), checkExists);
        }

        public async Task<FileResponse> ReplaceFileAsync(string container, string filepath, string contents)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            if (filepath == null)
            {
                throw new ArgumentNullException("filepath");
            }

            if (contents == null)
            {
                throw new ArgumentNullException("contents");
            }

            IHttpAddress address = baseAddress.WithResources(serviceName, container, filepath);
            IHttpRequest request = new HttpRequest(HttpMethod.Put, address.Build(), baseHeaders.Exclude(HttpHeaders.ContentTypeHeader), contents);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            var data = new { file = new List<FileResponse>() };
            return contentSerializer.Deserialize(response.Body, data).file.First();
        }

        public async Task RenameFileAsync(string container, string filepath, string newFile, string newType)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            if (filepath == null)
            {
                throw new ArgumentNullException("filepath");
            }

            if (newFile == null)
            {
                throw new ArgumentNullException("newFile");
            }

            if (newType == null)
            {
                throw new ArgumentNullException("newType");
            }

            IHttpAddress address = baseAddress.WithResources(serviceName, container, filepath);

            var fileData = new { name = newFile, path = newFile, content_type = newType };
            string body = contentSerializer.Serialize(fileData);
            IHttpRequest request = new HttpRequest(HttpMethod.Patch, address.Build(), baseHeaders, body);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);
        }

        public async Task<string> GetTextFileAsync(string container, string filepath)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            if (filepath == null)
            {
                throw new ArgumentNullException("filepath");
            }

            IHttpAddress address = baseAddress.WithResources(serviceName, container, filepath);
            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            return response.Body;
        }

        public async Task<byte[]> GetBinaryFileAsync(string container, string filepath)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            if (filepath == null)
            {
                throw new ArgumentNullException("filepath");
            }

            IHttpAddress address = baseAddress.WithResources(serviceName, container, filepath);
            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), baseHeaders.Include(HttpHeaders.AcceptHeader, OctetStream));

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            return response.RawBody;
        }

        public async Task<FileResponse> DeleteFileAsync(string container, string filepath)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            if (filepath == null)
            {
                throw new ArgumentNullException("filepath");
            }

            IHttpAddress address = baseAddress.WithResources(serviceName, container, filepath);

            IHttpRequest request = new HttpRequest(HttpMethod.Delete, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            var data = new { file = new List<FileResponse>() };
            return contentSerializer.Deserialize(response.Body, data).file.First();
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
