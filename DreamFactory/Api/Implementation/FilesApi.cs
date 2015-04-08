namespace DreamFactory.Api.Implementation
{
    using System.Linq;
    using System.Threading.Tasks;
    using DreamFactory.Http;
    using DreamFactory.Model;
    using DreamFactory.Serialization;

    internal class FilesApi : IFilesApi
    {
        private readonly HttpAddress baseAddress;
        private readonly IHttpFacade httpFacade;
        private readonly IObjectSerializer objectSerializer;
        private readonly HttpHeaders baseHeaders;
        private readonly string serviceName;

        public FilesApi(HttpAddress baseAddress, IHttpFacade httpFacade, IObjectSerializer objectSerializer, HttpHeaders baseHeaders, string serviceName)
        {
            this.baseAddress = baseAddress;
            this.httpFacade = httpFacade;
            this.objectSerializer = objectSerializer;
            this.baseHeaders = baseHeaders;
            this.serviceName = serviceName;
        }

        public async Task<FileResponse> CreateFileAsync(string container, string filepath, string content, bool checkExists = true)
        {
            HttpAddress address = baseAddress.WithResources(serviceName, container, filepath)
                                             .WithParameter("check_exist", checkExists);

            IHttpRequest request = new HttpRequest(HttpMethod.Post, address.Build(), baseHeaders.Exclude(HttpHeaders.ContentTypeHeader), content);

            IHttpResponse response = await httpFacade.SendAsync(request);

            HttpUtils.ThrowOnBadStatus(response, objectSerializer);

            FileResponseModel model = objectSerializer.Deserialize<FileResponseModel>(response.Body);
            return model.file.FirstOrDefault();
        }

        public async Task<string> GetFileAsync(string container, string filepath, bool base64)
        {
            HttpAddress address = baseAddress.WithResources(serviceName, container, filepath);

            if (base64)
            {
                address = address.WithParameter("include_properties", true)
                                 .WithParameter("content", true);
            }

            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.SendAsync(request);
            HttpUtils.ThrowOnBadStatus(response, objectSerializer);

            if (!base64)
            {
                return response.Body;
            }

            FileResponseModel model = objectSerializer.Deserialize<FileResponseModel>(response.Body);
            return model.file.First().content;
        }

        public async Task<FileResponse> DeleteFileAsync(string container, string filepath)
        {
            HttpAddress address = baseAddress.WithResources(serviceName, container, filepath);

            IHttpRequest request = new HttpRequest(HttpMethod.Delete, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.SendAsync(request);
            HttpUtils.ThrowOnBadStatus(response, objectSerializer);

            FileResponseModel model = objectSerializer.Deserialize<FileResponseModel>(response.Body);
            return model.file.First();
        }
    }
}
