namespace DreamFactory.Rest
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DreamFactory.Http;
    using DreamFactory.Model;
    using DreamFactory.Serialization;

    /// <inheritdoc />
    public class RestContext : IRestContext
    {
        private readonly HttpAddress address;

        private HttpHeaders httpHeaders;

        /// <summary>
        /// Initializes a new instance of the <see cref="RestContext"/> class.
        /// </summary>
        /// <param name="baseAddress">Base address (URL).</param>
        /// <param name="applicationName">Application name.</param>
        /// <param name="applicationApiKey">Application API key.</param>
        /// <param name="apiVersion">REST API version to use.</param>
        public RestContext(string baseAddress, string applicationName, string applicationApiKey, RestApiVersion apiVersion = RestApiVersion.V2)
            : this(baseAddress, applicationName, applicationApiKey, null, new UnirestHttpFacade(), new JsonContentSerializer(), apiVersion)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RestContext"/> class.
        /// </summary>
        /// <param name="baseAddress">Base address (URL).</param>
        /// <param name="applicationName">Application name.</param>
        /// <param name="applicationApiKey">Application API key.</param>
        /// <param name="sessionId">SessionId to be added to base headers.</param>
        /// <param name="apiVersion">REST API version to use.</param>
        public RestContext(string baseAddress, string applicationName, string applicationApiKey, string sessionId, RestApiVersion apiVersion = RestApiVersion.V2)
            : this(baseAddress, applicationName, applicationApiKey, sessionId, new UnirestHttpFacade(), new JsonContentSerializer(), apiVersion)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RestContext"/> class.
        /// </summary>
        /// <param name="baseAddress">Base address (URL).</param>
        /// <param name="applicationName">Application name.</param>
        /// <param name="applicationApiKey">Application API key.</param>
        /// <param name="sessionId">SessionId to be added to base headers.</param>
        /// <param name="httpFacade">User defined instance of <see cref="IHttpFacade"/>.</param>
        /// <param name="serializer">User defined instance of <see cref="IContentSerializer"/>.</param>
        /// <param name="apiVersion">REST API version to use.</param>
        public RestContext(string baseAddress, string applicationName, string applicationApiKey, string sessionId, IHttpFacade httpFacade, IContentSerializer serializer, RestApiVersion apiVersion = RestApiVersion.V2)
        {
            HttpUtils.CheckUrlString(baseAddress);

            if (applicationName == null)
            {
                throw new ArgumentNullException("applicationName");
            }

            if (applicationApiKey == null)
            {
                throw new ArgumentNullException("applicationApiKey");
            }

            if (httpFacade == null)
            {
                throw new ArgumentNullException("httpFacade");
            }

            if (serializer == null)
            {
                throw new ArgumentNullException("serializer");
            }

            address = new HttpAddress(baseAddress, apiVersion);

            HttpFacade = httpFacade;
            ContentSerializer = serializer;

            SetBaseHeaders(applicationName, applicationApiKey, sessionId);

            Factory = new ServiceFactory(address, HttpFacade, ContentSerializer, httpHeaders);
        }

        /// <inheritdoc />
        public IHttpFacade HttpFacade { get; private set; }

        /// <inheritdoc />
        public IContentSerializer ContentSerializer { get; private set; }

        /// <inheritdoc />
        public IHttpHeaders BaseHeaders { get { return httpHeaders; } }

        /// <inheritdoc />
        public IServiceFactory Factory { get; private set; }

        /// <inheritdoc />
        public void SetApplicationName(string applicationName)
        {
            if (applicationName == null)
            {
                throw new ArgumentNullException("applicationName");
            }

            httpHeaders.AddOrUpdate(HttpHeaders.FolderNameHeader, applicationName);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<string>> GetServicesAsync()
        {
            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), BaseHeaders);

            IHttpResponse response = await HttpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, ContentSerializer);

            var services = new { resource = new List<string>() };
            return ContentSerializer.Deserialize(response.Body, services).resource;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Resource>> GetResourcesAsync(string serviceName)
        {
            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.WithResource(serviceName).Build(), BaseHeaders);

            IHttpResponse response = await HttpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, ContentSerializer);

            var resources = new { resource = new List<Resource>() };
            return ContentSerializer.Deserialize(response.Body, resources).resource;
        }

        private void SetBaseHeaders(string applicationName, string applicationApiKey, string sessionId)
        {
            httpHeaders = new HttpHeaders();
            httpHeaders.AddOrUpdate(HttpHeaders.FolderNameHeader, applicationName);
            httpHeaders.AddOrUpdate(HttpHeaders.DreamFactoryApiKeyHeader, applicationApiKey);
            httpHeaders.AddOrUpdate(HttpHeaders.ContentTypeHeader, ContentSerializer.ContentType);
            httpHeaders.AddOrUpdate(HttpHeaders.AcceptHeader, ContentSerializer.ContentType);

            if (!string.IsNullOrEmpty(sessionId))
            {
                httpHeaders.AddOrUpdate(HttpHeaders.DreamFactorySessionTokenHeader, sessionId);
            }
        }
    }
}
