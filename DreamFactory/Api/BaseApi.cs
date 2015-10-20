namespace DreamFactory.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using DreamFactory.Http;
    using DreamFactory.Model;
    using DreamFactory.Model.Database;
    using DreamFactory.Serialization;

    internal abstract class BaseApi
    {
        protected IHttpFacade HttpFacade { get; }
        protected IContentSerializer ContentSerializer { get; }
        protected IHttpAddress BaseAddress { get; }
        protected HttpHeaders BaseHeaders { get; }

        protected BaseApi(IHttpAddress baseAddress, IHttpFacade httpFacade, IContentSerializer contentSerializer, HttpHeaders baseHeaders, string apiName)
        {
            this.BaseAddress = baseAddress.WithResource(apiName);
            this.HttpFacade = httpFacade;
            this.ContentSerializer = contentSerializer;
            this.BaseHeaders = baseHeaders;
        }


        #region request

        /// <summary>
        /// Execute a request specified with a resource.
        /// </summary>
        /// <typeparam name="TResponse">Type of the response.</typeparam>
        /// <param name="method">HttpMethod to be used in request.</param>
        /// <param name="resource">Resource.</param>
        /// <param name="query">Query parameters.</param>
        /// <returns>An object of type TResponse.</returns>
        /// <exception cref="ArgumentNullException">Thrown when any of the required arguments are null.</exception>
        internal Task<TResponse> RequestAsync<TResponse>(HttpMethod method, string resource, SqlQuery query)
            where TResponse : class, new()
        {
            if (resource == null)
            {
                throw new ArgumentNullException("resource");
            }

            return RequestAsync<TResponse>(method, new[] { resource }, query);
        }

        /// <summary>
        /// Execute a request specified with resource and query parameters.
        /// </summary>
        /// <typeparam name="TResponse">Type of response.</typeparam>
        /// <param name="method">HttpMethod to be used in request.</param>
        /// <param name="resource">Resource.</param>
        /// <param name="resourceIdentifier">Resource identifier.</param>
        /// <param name="query">Query parameters.</param>
        /// <returns>An object of type TResponse.</returns>
        /// <exception cref="ArgumentNullException">Thrown when any of the required arguments are null.</exception>
        internal Task<TResponse> RequestAsync<TResponse>(HttpMethod method, string resource, string resourceIdentifier, SqlQuery query)
            where TResponse : class, new()
        {
            if (resource == null)
            {
                throw new ArgumentNullException("resource");
            }

            if (resourceIdentifier == null)
            {
                throw new ArgumentNullException("resourceIdentifier");
            }

            return RequestAsync<TResponse>(method, new[] { resource, resourceIdentifier }, query);
        }

        /// <summary>
        /// Execute a request specified with resource parts and query parameters.
        /// </summary>
        /// <typeparam name="TResponse">Type of response.</typeparam>
        /// <param name="method">HttpMethod to be used in request.</param>
        /// <param name="resourceParts">Array of resource parts. Usually consists of resource and resource identifier.</param>
        /// <param name="query">Query parameters.</param>
        /// <returns>An object of type TResponse.</returns>
        internal Task<TResponse> RequestAsync<TResponse>(HttpMethod method, string[] resourceParts, SqlQuery query)
            where TResponse : class, new()
        {
            return GetDeserializedResponse<TResponse>(
                method: method,
                resourceParts: resourceParts,
                query: query
                );
        }

        #endregion

        #region request without deserialization

        /// <summary>
        /// Execute a request and return response body.
        /// </summary>
        /// <param name="method">HttpMethod to be used in request.</param>
        /// <param name="resource">Resource.</param>
        /// <param name="resourceIdentifier">Resource identifier.</param>
        /// <param name="query">Query parameters.</param>
        /// <returns>Response body.</returns>
        /// <exception cref="ArgumentNullException">Thrown when any of the required arguments are null.</exception>
        internal Task<string> RequestBodyAsync(HttpMethod method, string resource, string resourceIdentifier, SqlQuery query)
        {
            if (resource == null)
            {
                throw new ArgumentNullException("resource");
            }

            if (resourceIdentifier == null)
            {
                throw new ArgumentNullException("resourceIdentifier");
            }

            return RequestBodyAsync(
                method: method,
                resourceParts: new[] { resource, resourceIdentifier },
                query: query
                );
        }

        /// <summary>
        /// Execute a request and return response body.
        /// </summary>
        /// <param name="method">HttpMethod to be used in request.</param>
        /// <param name="resourceParts">Array of resource parts of the record. Usually consists of resource and resource identifier.</param>
        /// <param name="query">Query parameters.</param>
        /// <returns>Response body.</returns>
        /// <exception cref="ArgumentNullException">Thrown when any of the required arguments are null.</exception>
        internal Task<string> RequestBodyAsync(HttpMethod method, string[] resourceParts, SqlQuery query)
        {
            if (resourceParts == null)
            {
                throw new ArgumentNullException("resourceParts");
            }

            return GetResponseBody(
                method: method,
                resourceParts: resourceParts,
                query: query
                );
        }

        #endregion

        #region request with payload

        /// <summary>
        /// Execute a request with specified resource and payload.
        /// </summary>
        /// <typeparam name="TRequest">Type of the request payload</typeparam>
        /// <typeparam name="TResponse">Type of response.</typeparam>
        /// <param name="method">HttpMethod to be used in request.</param>
        /// <param name="resource">Resource.</param>
        /// <param name="query">Query parameters.</param>
        /// <param name="payload">Request payload.</param>
        /// <returns>An object of type TResponse.</returns>
        /// <exception cref="ArgumentNullException">Thrown when any of the required arguments are null.</exception>
        internal Task<TResponse> RequestWithPayloadAsync<TRequest, TResponse>(HttpMethod method, string resource, SqlQuery query, TRequest payload)
            where TRequest : class, new()
            where TResponse : class, new()
        {
            if (resource == null)
            {
                throw new ArgumentNullException("resource");
            }

            if (payload == null)
            {
                throw new ArgumentNullException("payload");
            }

            return RequestWithPayloadAsync<TRequest, TResponse>(method, new[] { resource }, query, payload);
        }

        /// <summary>
        /// Execute a request with specified resource, resource identifier and payload.
        /// </summary>
        /// <typeparam name="TRequest">Type of the request payload</typeparam>
        /// <typeparam name="TResponse">Type of response.</typeparam>
        /// <param name="method">HttpMethod to be used in request.</param>
        /// <param name="resource">Resource.</param>
        /// <param name="resourceIdentifier">Resource identifier.</param>
        /// <param name="query">Query parameters.</param>
        /// <param name="payload">Request payload.</param>
        /// <returns>An object of type TResponse.</returns>
        /// <exception cref="ArgumentNullException">Thrown when any of the required arguments are null.</exception>
        internal Task<TResponse> RequestWithPayloadAsync<TRequest, TResponse>(HttpMethod method, string resource, string resourceIdentifier, SqlQuery query, TRequest payload)
            where TRequest : class, new()
            where TResponse : class, new()
        {
            if (resource == null)
            {
                throw new ArgumentNullException("resource");
            }

            if (resourceIdentifier == null)
            {
                throw new ArgumentNullException("resourceIdentifier");
            }

            if (payload == null)
            {
                throw new ArgumentNullException("payload");
            }

            return RequestWithPayloadAsync<TRequest, TResponse>(method, new[] { resource, resourceIdentifier }, query, payload);
        }

        /// <summary>
        /// Execute a request with specified resource parts and payload.
        /// </summary>
        /// <typeparam name="TRequest">Type of the request payload</typeparam>
        /// <typeparam name="TResponse">Type of response.</typeparam>
        /// <param name="method">HttpMethod to be used in request.</param>
        /// <param name="resourceParts">Array of resource parts of the record. Usually consists of resource and resource identifier.</param>
        /// <param name="query">Query parameters.</param>
        /// <param name="payload">Request payload.</param>
        /// <returns>An object of type TResponse.</returns>
        /// <exception cref="ArgumentNullException">Thrown when any of the required arguments are null.</exception>
        internal Task<TResponse> RequestWithPayloadAsync<TRequest, TResponse>(HttpMethod method, string[] resourceParts, SqlQuery query, TRequest payload)
            where TRequest : class, new()
            where TResponse : class, new()
        {
            if (payload == null)
            {
                throw new ArgumentNullException("payload");
            }

            string body = ContentSerializer.Serialize(payload);
            return GetDeserializedResponse<TResponse>(
                method: method,
                body: body,
                resourceParts: resourceParts,
                query: query
                );
        }

        /// <summary>
        /// Execute a request with specified resource and payload that is a collection.
        /// </summary>
        /// <typeparam name="TRequest">Type of the request payload</typeparam>
        /// <typeparam name="TResponse">Type of the objects included in response.</typeparam>
        /// <param name="method">HttpMethod to be used in request.</param>
        /// <param name="resource">Resource.</param>
        /// <param name="query">Query parameters.</param>
        /// <param name="payload">Collection of records that should sent as payload.</param>
        /// <returns>A collection of TResponse objects.</returns>
        /// <exception cref="ArgumentNullException">Thrown when any of the required arguments are null.</exception>
        /// <exception cref="ArgumentException">Thrown when records collection is null or its length is less than 1.</exception>
        internal async Task<IEnumerable<TResponse>> RequestWithPayloadAsync<TRequest, TResponse>(HttpMethod method, string resource, SqlQuery query, params TRequest[] payload)
            where TRequest : IRecord
        {
            if (resource == null)
            {
                throw new ArgumentNullException("resource");
            }

            if (payload == null || payload.Length < 1)
            {
                throw new ArgumentException("At least one parameter must be specified", "payload");
            }

            DatabaseResourceWrapper<TResponse> response = await RequestWithPayloadAsync<RequestResourceWrapper<TRequest>, DatabaseResourceWrapper<TResponse>>(
                method: method,
                resource: resource,
                query: query,
                payload: new RequestResourceWrapper<TRequest> { Records = new List<TRequest>(payload), Ids = payload.Select(x => x.Id).ToArray() }
                );

            return response.Records;
        }

        #endregion

        #region request delete

        /// <summary>
        /// Execute a delete request on specified IDs of a given resource.
        /// </summary>
        /// <typeparam name="TResponse">Type of the objects included in response.</typeparam>
        /// <param name="resource">Resource of the ids that will be deleted.</param>
        /// <param name="query">Query parameters.</param>
        /// <param name="force">Indicator whether all records should be deleted.</param>
        /// <param name="ids">IDs that should be deleted.</param>
        /// <returns>A collection of TResponse objects.</returns>
        /// <exception cref="ArgumentException">Thrown when ids argument is null or the length of an array is less than 1.</exception>
        /// <exception cref="ArgumentNullException">Thrown when any of the required arguments are null.</exception>
        internal async Task<IEnumerable<TResponse>> RequestDeleteAsync<TResponse>(string resource, SqlQuery query, bool force, params int[] ids)
            where TResponse : class, new()
        {
            if (resource == null)
            {
                throw new ArgumentNullException("resource");
            }

            if (ids == null || ids.Length < 1)
            {
                throw new ArgumentException("At least one identifier must be specified", "ids");
            }

            query.CustomParameters.Add("force", force);
            query.CustomParameters.Add("ids", string.Join(",", ids));

            DatabaseResourceWrapper<TResponse> response = await GetDeserializedResponse<DatabaseResourceWrapper<TResponse>>(
            method: HttpMethod.Delete,
            resourceParts: new[] { resource },
            query: query
            );

            return response.Records;
        }

        #endregion

        #region private methods

        private Task<string> GetResponseBody(
            HttpMethod method,
            string body = null,
            string[] resourceParts = null,
            SqlQuery query = null
            )
        {
            IHttpRequest request = BuildRequest(method, body, resourceParts, query);
            return ExecuteRequest(request);
        }

        private Task<TResponse> GetDeserializedResponse<TResponse>(
            HttpMethod method,
            string body = null,
            string[] resourceParts = null,
            SqlQuery query = null
            )
            where TResponse : class, new()
        {
            IHttpRequest request = BuildRequest(method, body, resourceParts, query);
            return ExecuteRequest<TResponse>(request);
        }

        #endregion

        /// <summary>
        /// Builds IHttpRequest from given arguments.
        /// </summary>
        /// <param name="method">HttpMethod used in request.</param>
        /// <param name="body">Body used in request.</param>
        /// <param name="resourceParts">Array of resource parts. Usually consists of resource and resource identifier.</param>
        /// <param name="query">Query parameters.</param>
        internal IHttpRequest BuildRequest(HttpMethod method, string body, string[] resourceParts, SqlQuery query)
        {
            IHttpAddress address = BuildAddress(resourceParts, query);

            IHttpRequest request;
            if (body == null)
            {
                request = new HttpRequest(method, address.Build(), BaseHeaders);
            }
            else
            {
                request = new HttpRequest(method, address.Build(), BaseHeaders, body);
            }
            return request;
        }

        /// <summary>
        /// Builds IHttpAddress from given resourceParts and query.
        /// </summary>
        /// <param name="resourceParts">Array of resource parts. Usually consists of resource and resource identifier.</param>
        /// <param name="query">Query parameters.</param>
        internal IHttpAddress BuildAddress(string[] resourceParts, SqlQuery query)
        {
            IHttpAddress address = BaseAddress;
            if (resourceParts != null)
            {
                address = address.WithResource(resourceParts);
            }

            if (query != null)
            {
                address = address.WithSqlQuery(query);
            }
            return address;
        }

        /// <summary>
        /// Executes given IHttpRequest and returns deserialized response body.
        /// </summary>
        /// <typeparam name="TResponse">Type response body will be deserialized to.</typeparam>
        /// <param name="request">Request to be executed.</param>
        /// <returns>Response body deserialized to type TResponse.</returns>
        /// <exception cref="DreamFactoryException">Thrown when there was an error executing request.</exception>
        internal async Task<TResponse> ExecuteRequest<TResponse>(IHttpRequest request)
            where TResponse : class, new()
        {
            string body = await ExecuteRequest(request);
            return ContentSerializer.Deserialize<TResponse>(body);
        }

        /// <summary>
        /// Executes given IHttpRequest and returns response body.
        /// </summary>
        /// <param name="request">Request to be executed.</param>
        /// <returns>Response body.</returns>
        /// <exception cref="DreamFactoryException">Thrown when there was an error executing request.</exception>
        internal async Task<string> ExecuteRequest(IHttpRequest request)
        {
            IHttpResponse response = await HttpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, ContentSerializer);
            return response.Body;
        }
    }
}
