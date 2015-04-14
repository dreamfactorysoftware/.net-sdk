namespace DreamFactory.Api.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using DreamFactory.Http;
    using DreamFactory.Model.File;
    using DreamFactory.Serialization;

    internal class FilesApi : IFilesApi
    {
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

        public async Task<FileResponse> CreateFileAsync(string container, string filepath, string content,
            bool checkExists = true)
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

            IHttpAddress address = baseAddress.WithResources(serviceName, container, filepath)
                .WithParameter("check_exist", checkExists);

            IHttpRequest request = new HttpRequest(HttpMethod.Post, address.Build(),
                baseHeaders.Exclude(HttpHeaders.ContentTypeHeader), content);

            IHttpResponse response = await httpFacade.SendAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            var data = new { file = new List<FileResponse>() };
            return contentSerializer.Deserialize(response.Body, data).file.First();
        }

        public async Task<string> GetFileAsync(string container, string filepath, bool base64)
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

            if (base64)
            {
                address = address.WithParameter("include_properties", true)
                                 .WithParameter("content", true);
            }

            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.SendAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            if (!base64)
            {
                return response.Body;
            }

            var data = new { file = new List<FileResponse>() };
            return contentSerializer.Deserialize(response.Body, data).file.First().content;
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

            IHttpResponse response = await httpFacade.SendAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            var data = new { file = new List<FileResponse>() };
            return contentSerializer.Deserialize(response.Body, data).file.First();
        }
    }
}
