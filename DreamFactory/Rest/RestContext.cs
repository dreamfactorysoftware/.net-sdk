namespace DreamFactory.Rest
{
    using System;
    using System.Collections.Generic;
    using DreamFactory.Api;
    using DreamFactory.Api.Implementation;
    using DreamFactory.Http;
    using DreamFactory.Serialization;

    /// <inheritdoc />
    public class RestContext : IRestContext
    {
        private readonly Dictionary<string, Func<string, IServiceApi>> serviceFactories;

        private readonly HttpAddress address;

        /// <summary>
        /// Initializes a new instance of the <see cref="RestContext"/> class.
        /// </summary>
        /// <param name="baseAddress">Base address (URL).</param>
        /// <param name="apiVersion">REST API version to use.</param>
        public RestContext(string baseAddress, RestApiVersion apiVersion = RestApiVersion.V1)
            : this(baseAddress, new UnirestHttpFacade(), new JsonObjectSerializer(), apiVersion)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RestContext"/> class.
        /// </summary>
        /// <param name="baseAddress">Base address (URL).</param>
        /// <param name="httpFacade">User defined instance of <see cref="IHttpFacade"/>.</param>
        /// <param name="serializer">User defined instance of <see cref="IObjectSerializer"/>.</param>
        /// <param name="apiVersion">REST API version to use.</param>
        public RestContext(string baseAddress, IHttpFacade httpFacade, IObjectSerializer serializer, RestApiVersion apiVersion = RestApiVersion.V1)
        {
            HttpUtils.CheckUrlString(baseAddress);

            if (httpFacade == null)
            {
                throw new ArgumentNullException("httpFacade");
            }

            if (serializer == null)
            {
                throw new ArgumentNullException("serializer");
            }

            address = new HttpAddress(baseAddress, apiVersion, new List<string>(), new Dictionary<string, object>());

            HttpFacade = httpFacade;
            ContentSerializer = serializer;

            SetBaseHeaders();

            serviceFactories = new Dictionary<string, Func<string, IServiceApi>>();
            RegisterService<IUserSessionApi>(name => new UserSessionApi(address, HttpFacade, ContentSerializer, BaseHeaders));
            RegisterService<IFilesApi>(name => new FilesApi(address, HttpFacade, ContentSerializer, BaseHeaders, name));
        }

        /// <inheritdoc />
        public IHttpFacade HttpFacade { get; private set; }

        /// <inheritdoc />
        public IObjectSerializer ContentSerializer { get; private set; }

        /// <inheritdoc />
        public HttpHeaders BaseHeaders { get; private set; }

        /// <inheritdoc />
        public TServiceApi GetServiceApi<TServiceApi>(string serviceName)
            where TServiceApi : IServiceApi
        {
            string serviceApiType = typeof (TServiceApi).FullName;
            Func<string, IServiceApi> factory;
            if (!serviceFactories.TryGetValue(serviceApiType, out factory))
            {
                throw new KeyNotFoundException(string.Format("Service {0} is unknown.", serviceApiType));
            }

            return (TServiceApi)factory(serviceName);
        }

        private void RegisterService<TServiceApi>(Func<string, TServiceApi> factory)
            where TServiceApi : class, IServiceApi
        {
            string serviceApiType = typeof(TServiceApi).FullName;
            serviceFactories.Add(serviceApiType, factory);
        }

        private void SetBaseHeaders()
        {
            BaseHeaders = new HttpHeaders()
                .Include(HttpHeaders.DreamFactoryApplicationHeader, "admin")
                .Include(HttpHeaders.ContentTypeHeader, ContentSerializer.ContentType)
                .Include(HttpHeaders.AcceptHeader, ContentSerializer.ContentType);
        }
    }
}
