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

        public async Task<IEnumerable<string>> GetAccessComponentsAsync()
        {
            IHttpAddress address = baseAddress.WithResources(serviceName).WithParameter("as_access_components", true);
            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), baseHeaders);
            
            IHttpResponse response = await httpFacade.SendAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            var data = new { resource = new List<string>() };
            return contentSerializer.Deserialize(response.Body, data).resource;
        }

        public async Task<IEnumerable<Container>> GetContainersAsync()
        {
            IHttpAddress address = baseAddress.WithResources(serviceName).WithParameter("include_properties", true);
            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.SendAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            var data = new { container = new List<Container>() };
            return contentSerializer.Deserialize(response.Body, data).container;
        }

        public async Task CreateContainersAsync(IEnumerable<string> containers, bool checkExists = true)
        {
            IHttpAddress address = baseAddress.WithResources(serviceName).WithParameter("check_exist", checkExists);

            var data = new { container = containers.Select(x => new Container { name = x, path = x }) };
            string body = contentSerializer.Serialize(data);
            IHttpRequest request = new HttpRequest(HttpMethod.Post, address.Build(), baseHeaders, body);

            IHttpResponse response = await httpFacade.SendAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);
        }

        public async Task DeleteContainersAsync(IEnumerable<string> names)
        {
            if (names == null)
            {
                throw new ArgumentNullException("names");
            }

            IHttpAddress address = baseAddress.WithResources(serviceName);

            var data = new { container = names.Select(x => new Container { name = x, path = x }) };
            string body = contentSerializer.Serialize(data);
            IHttpRequest request = new HttpRequest(HttpMethod.Delete, address.Build(), baseHeaders, body);
            request.SetTunnelingWith(HttpMethod.Post);

            IHttpResponse response = await httpFacade.SendAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);
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

        public async Task<string> GetFileAsync(string container, string filepath)
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

            IHttpResponse response = await httpFacade.SendAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            return response.Body;
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
