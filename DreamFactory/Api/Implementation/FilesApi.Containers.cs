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
        #region --- /files ---

        public async Task<IEnumerable<string>> GetAccessComponentsAsync()
        {
            IHttpAddress address = baseAddress.WithResources(serviceName).WithParameter("as_access_components", true);
            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), baseHeaders);
            
            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            var data = new { resource = new List<string>() };
            return contentSerializer.Deserialize(response.Body, data).resource;
        }

        public async Task<IEnumerable<ContainerInfo>> GetContainersAsync()
        {
            IHttpAddress address = baseAddress.WithResources(serviceName).WithParameter("include_properties", true);
            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            var data = new { container = new List<ContainerInfo>() };
            return contentSerializer.Deserialize(response.Body, data).container;
        }

        public async Task CreateContainersAsync(IEnumerable<string> containers, bool checkExists = true)
        {
            IHttpAddress address = baseAddress.WithResources(serviceName).WithParameter("check_exist", checkExists);

            var data = new { container = containers.Select(x => new ContainerInfo { name = x, path = x }) };
            string body = contentSerializer.Serialize(data);
            IHttpRequest request = new HttpRequest(HttpMethod.Post, address.Build(), baseHeaders, body);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);
        }

        public async Task DeleteContainersAsync(IEnumerable<string> containers)
        {
            if (containers == null)
            {
                throw new ArgumentNullException("containers");
            }

            IHttpAddress address = baseAddress.WithResources(serviceName);

            var data = new { container = containers.Select(x => new ContainerInfo { name = x, path = x }) };
            string body = contentSerializer.Serialize(data);
            IHttpRequest request = new HttpRequest(HttpMethod.Delete, address.Build(), baseHeaders, body);
            request.SetTunnelingWith(HttpMethod.Post);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);
        }

        #endregion

        #region --- /files/{container} ---

        public async Task<ContainerResponse> GetContainerAsync(string container, ListingFlags flags)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            IHttpAddress address = baseAddress.WithResources(serviceName, container);
            address = AddListingParameters(address, flags);
            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            return contentSerializer.Deserialize<ContainerResponse>(response.Body);
        }

        public async Task<ContainerResponse> CreateContainerAsync(string container, ContainerRequest containerData, bool checkExists = true)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            if (containerData == null)
            {
                throw new ArgumentNullException("containerData");
            }

            IHttpAddress address = baseAddress.WithResources(serviceName, container).WithParameter("check_exist", checkExists);

            string body = contentSerializer.Serialize(containerData);
            IHttpRequest request = new HttpRequest(HttpMethod.Post, address.Build(), baseHeaders, body);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            return contentSerializer.Deserialize<ContainerResponse>(response.Body);
        }

        public async Task RenameContainerAsync(string container, string newContainer)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            if (newContainer == null)
            {
                throw new ArgumentNullException("newContainer");
            }

            IHttpAddress address = baseAddress.WithResources(serviceName, container);

            ContainerInfo containerData = new ContainerInfo { name = newContainer, path = newContainer };
            string body = contentSerializer.Serialize(containerData);
            IHttpRequest request = new HttpRequest(HttpMethod.Patch, address.Build(), baseHeaders, body);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);
        }

        public async Task<ContainerResponse> DeleteContainerAsync(string container, bool force = false, bool contentOnly = false)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            IHttpAddress address = baseAddress.WithResources(serviceName, container)
                                              .WithParameter("force", force)
                                              .WithParameter("content_only", contentOnly);

            IHttpRequest request = new HttpRequest(HttpMethod.Delete, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            return contentSerializer.Deserialize<ContainerResponse>(response.Body);
        }

        #endregion
    }
}
