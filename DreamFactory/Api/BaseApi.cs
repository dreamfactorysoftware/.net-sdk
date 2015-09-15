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
        private IHttpAddress BaseAddress { get; }
        private IHttpFacade HttpFacade { get; }
        private IContentSerializer ContentSerializer { get; }
        protected HttpHeaders BaseHeaders { get; }

        protected BaseApi(IHttpAddress baseAddress, IHttpFacade httpFacade, IContentSerializer contentSerializer, HttpHeaders baseHeaders, string apiName)
        {
            this.BaseAddress = baseAddress.WithResource(apiName);
            this.HttpFacade = httpFacade;
            this.ContentSerializer = contentSerializer;
            this.BaseHeaders = baseHeaders;
        }

        #region query

        /// <summary>
        /// Execute a get request for single record specified with resource and query parameters.
        /// </summary>
        /// <typeparam name="TResponse">Type of the record included in response.</typeparam>
        /// <param name="resource">Resource of the record that will be fetched.</param>
        /// <param name="resourceIdentifier">Resource identifier of the record that will be fetched.</param>
        /// <param name="query">Query parameters for the returned object.</param>
        /// <returns>A single object of type TResponse.</returns>
        /// <exception cref="ArgumentNullException">Thrown when any of the required arguments are null.</exception>
        internal async Task<TResponse> SingleAsync<TResponse>(string resource, string resourceIdentifier, SqlQuery query)
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

            if (query == null)
            {
                throw new ArgumentNullException("query");
            }

            return await SingleAsync<TResponse>(new[] { resource, resourceIdentifier }, query);
        }

        /// <summary>
        /// Execute a get request for single record specified with resource parts and query parameters.
        /// </summary>
        /// <typeparam name="TResponse">Type of the record included in response.</typeparam>
        /// <param name="resourceParts">Resource parts of the record that will be fetched.</param>
        /// <param name="query">Query parameters for the returned object.</param>
        /// <returns>A single object of type TResponse.</returns>
        /// <exception cref="ArgumentException">Thrown when resource parts argument is null or its length is less than 1.</exception>
        /// <exception cref="ArgumentNullException">Thrown when any of the required arguments are null.</exception>
        internal async Task<TResponse> SingleAsync<TResponse>(string[] resourceParts, SqlQuery query)
            where TResponse : class, new()
        {
            if (resourceParts == null || resourceParts.Length < 1)
            {
                throw new ArgumentException("At least one resource part must be specified", "resourceParts");
            }

            if (query == null)
            {
                throw new ArgumentNullException("query");
            }

            return await GetDeserializedResponse<TResponse>(
                method: HttpMethod.Get,
                resourceParts: resourceParts,
                query: query
                );
        }

        /// <summary>
        /// Execute a get request for multiple records specified with resource and query parameters.
        /// </summary>
        /// <typeparam name="TResponse">Type of the records included in response.</typeparam>
        /// <param name="resource">Resource of the records that will be fetched.</param>
        /// <param name="query">Query parameters for the returned object.</param>
        /// <returns>A collection of TResponse objects.</returns>
        /// <exception cref="ArgumentNullException">Thrown when any of the required arguments are null.</exception>
        internal async Task<IEnumerable<TResponse>> QueryAsync<TResponse>(string resource, SqlQuery query)
        {
            if (resource == null)
            {
                throw new ArgumentNullException("resource");
            }

            if (query == null)
            {
                throw new ArgumentNullException("query");
            }

            RecordsResult<TResponse> response = await GetDeserializedResponse<RecordsResult<TResponse>>(
                method: HttpMethod.Get,
                resourceParts: new[] { resource },
                query: query
                );

            return response.Records;
        }

        /// <summary>
        /// Execute a get request for multiple records specified with resource and collection of key/value pairs as parameters.
        /// </summary>
        /// <typeparam name="TResponse">Type of the records included in response.</typeparam>
        /// <param name="resource">Resource of the records that will be fetched.</param>
        /// <param name="parameters">Collection of key/value pairs that will be included in request query string.</param>
        /// <returns>A collection of TResponse objects.</returns>
        /// <exception cref="ArgumentNullException">Thrown when any of the required arguments are null.</exception>
        internal async Task<IEnumerable<TResponse>> QueryAsync<TResponse>(string resource, params KeyValuePair<string, object>[] parameters)
        {
            if (resource == null)
            {
                throw new ArgumentNullException("resource");
            }

            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }

            RecordsResult<TResponse> response = await GetDeserializedResponse<RecordsResult<TResponse>>(
                method: HttpMethod.Get,
                resourceParts: new[] { resource },
                customParameters: parameters
                );

            return response.Records;
        }

        #endregion

        #region create and update

        /// <summary>
        /// Execute a create or update request with specified records as payload.
        /// </summary>
        /// <typeparam name="TRequest">Type of the records.</typeparam>
        /// <typeparam name="TResponse">Type of the records included in response.</typeparam>
        /// <param name="method">HttpMethod to be used in request.</param>
        /// <param name="resource">Resource of the records that will be created or updated.</param>
        /// <param name="query">Query parameters for the returned object.</param>
        /// <param name="records">Records that should sent as payload.</param>
        /// <returns>A collection of TResponse objects.</returns>
        /// <exception cref="ArgumentException">Thrown when records argument is null or the length of an array is less than 1.</exception>
        /// <exception cref="ArgumentNullException">Thrown when any of the required arguments are null.</exception>
        internal async Task<IEnumerable<TResponse>> CreateOrUpdateAsync<TRequest, TResponse>(HttpMethod method, string resource, SqlQuery query, params TRequest[] records)
            where TRequest : IRecord
            where TResponse : class, new()
        {
            if (query == null)
            {
                throw new ArgumentNullException("query");
            }

            if (records == null || records.Length < 1)
            {
                throw new ArgumentException("At least one parameter must be specified", "records");
            }

            string body = ContentSerializer.Serialize(new { resource = new List<TRequest>(records), ids = records.Select(x => x.Id) });
            RecordsResult<TResponse> response = await GetDeserializedResponse<RecordsResult<TResponse>>(
                method: method,
                body: body,
                resourceParts: new[] { resource },
                query: query
                );

            return response.Records;
        }

        /// <summary>
        /// Execute a create or update request with specified record as payload.
        /// </summary>
        /// <typeparam name="TRequest">Type of the record.</typeparam>
        /// <typeparam name="TResponse">Type of the record included in response.</typeparam>
        /// <param name="method">HttpMethod to be used in request.</param>
        /// <param name="resource">Resource of the record that will be created or updated.</param>
        /// <param name="resourceIdentifier">Resource identifier of the record that will be created or updated.</param>
        /// <param name="query">Query parameters for the returned object.</param>
        /// <param name="record">Record that should sent as payload.</param>
        /// <returns>A single object of type TResponse.</returns>
        /// <exception cref="ArgumentNullException">Thrown when any of the required arguments are null.</exception>
        internal async Task<TResponse> CreateOrUpdateAsync<TRequest, TResponse>(HttpMethod method, string resource, string resourceIdentifier, SqlQuery query, TRequest record)
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

            if (record == null)
            {
                throw new ArgumentNullException("record");
            }

            if (query == null)
            {
                throw new ArgumentNullException("query");
            }

            return await CreateOrUpdateAsync<TRequest, TResponse>(method, new[] { resource, resourceIdentifier }, query, record);
        }

        /// <summary>
        /// Execute a create or update request with specified record as payload.
        /// </summary>
        /// <typeparam name="TRequest">Type of the record.</typeparam>
        /// <typeparam name="TResponse">Type of the record included in response.</typeparam>
        /// <param name="method">HttpMethod to be used in request.</param>
        /// <param name="resourceParts">Array of resource parts of the record to be created or updated. Usually consists of resource and resource identifier.</param>
        /// <param name="query">Query parameters for the returned object.</param>
        /// <param name="record">Record that should sent as payload.</param>
        /// <returns>A single object of type TResponse.</returns>
        /// <exception cref="ArgumentException">Thrown when resourceParts argument is null or the length of an array is less than 1.</exception>
        /// <exception cref="ArgumentNullException">Thrown when any of the required arguments are null.</exception>
        internal async Task<TResponse> CreateOrUpdateAsync<TRequest, TResponse>(HttpMethod method, string[] resourceParts, SqlQuery query, TRequest record)
            where TRequest : class, new()
            where TResponse : class, new()
        {
            if (resourceParts == null || resourceParts.Length < 1)
            {
                throw new ArgumentException("At least one resource part must be specified", "resourceParts");
            }

            if (record == null)
            {
                throw new ArgumentNullException("record");
            }

            if (query == null)
            {
                throw new ArgumentNullException("query");
            }


            string body = ContentSerializer.Serialize(record);
            return await GetDeserializedResponse<TResponse>(
                method: method,
                body: body,
                resourceParts: resourceParts,
                query: query
                );
        }

        #endregion

        #region delete

        /// <summary>
        /// Execute a delete request on specified IDs of a given resource.
        /// </summary>
        /// <typeparam name="TResponse">Type of the records included in response.</typeparam>
        /// <param name="resource">Resource of the ids that will be deleted.</param>
        /// <param name="query">Query parameters for the returned object.</param>
        /// <param name="force">Indicator whether all records should be deleted.</param>
        /// <param name="ids">IDs that should be deleted.</param>
        /// <returns>A collection of TResponse objects.</returns>
        /// <exception cref="ArgumentException">Thrown when ids argument is null or the length of an array is less than 1.</exception>
        /// <exception cref="ArgumentNullException">Thrown when any of the required arguments are null.</exception>
        internal async Task<IEnumerable<TResponse>> DeleteAsync<TResponse>(string resource, SqlQuery query, bool force, params int[] ids)
            where TResponse : class, new()
        {
            if (resource == null)
            {
                throw new ArgumentNullException("resource");
            }

            if (query == null)
            {
                throw new ArgumentNullException("query");
            }

            if (ids == null || ids.Length < 1)
            {
                throw new ArgumentException("At least one application ID must be specified", "ids");
            }

            RecordsResult<TResponse> response = await GetDeserializedResponse<RecordsResult<TResponse>>(
            method: HttpMethod.Delete,
            resourceParts: new[] { resource },
            query: query,
            customParameters: new[]
            {
                new KeyValuePair<string, object>("force", force),
                new KeyValuePair<string, object>("ids", string.Join(",", ids))
            }
            );

            return response.Records;
        }

        /// <summary>
        /// Execute a delete request on a single record specified by resource and resource identifier.
        /// </summary>
        /// <typeparam name="TResponse">Type of the records included in response.</typeparam>
        /// <param name="resource">Resource of the record to be deleted.</param>
        /// <param name="resourceIdentifier">Resource identifier of the record to be deleted.</param>
        /// <param name="query">Query parameters for the returned object.</param>
        /// <returns>A single object of type TResponse.</returns>
        /// <exception cref="ArgumentNullException">Thrown when any of the required arguments are null.</exception>
        internal async Task<TResponse> DeleteAsync<TResponse>(string resource, string resourceIdentifier, SqlQuery query)
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

            if (query == null)
            {
                throw new ArgumentNullException("query");
            }

            return await DeleteAsync<TResponse>(new string[] { resource, resourceIdentifier }, query);
        }

        /// <summary>
        /// Execute a delete request on a single record specified by resource parts.
        /// </summary>
        /// <typeparam name="TResponse">Type of the records included in response.</typeparam>
        /// <param name="resourceParts">Array of resource parts of the record to be deleted. Usually consists of resource and resource identifier.</param>
        /// <param name="query">Query parameters for the returned object.</param>
        /// <returns>A single object of type TResponse.</returns>
        /// <exception cref="ArgumentException">Thrown when resourceParts argument is null or the length of an array is less than 1.</exception>
        /// <exception cref="ArgumentNullException">Thrown when any of the required arguments are null.</exception>
        internal async Task<TResponse> DeleteAsync<TResponse>(string[] resourceParts, SqlQuery query)
            where TResponse : class, new()
        {
            if (resourceParts == null || resourceParts.Length < 1)
            {
                throw new ArgumentException("At least one resource part must be specified", "resourceParts");
            }

            if (query == null)
            {
                throw new ArgumentNullException("query");
            }

            return await GetDeserializedResponse<TResponse>(
            method: HttpMethod.Delete,
            resourceParts: resourceParts,
            query: query
            );
        }

        #endregion

        private async Task<TResponse> GetDeserializedResponse<TResponse>(
            HttpMethod method,
            string body = null,
            string[] resourceParts = null,
            KeyValuePair<string, object>[] customParameters = null,
            SqlQuery query = null
            )
            where TResponse : class, new()
        {
            IHttpAddress address = BuildAddress(resourceParts, customParameters, query);

            IHttpRequest request;
            if (body == null)
            {
                request = new HttpRequest(method, address.Build(), BaseHeaders);
            }
            else
            {
                request = new HttpRequest(method, address.Build(), BaseHeaders, body);
            }

            return await ExecuteRequest<TResponse>(request);
        }

        private IHttpAddress BuildAddress(string[] resourceParts, KeyValuePair<string, object>[] customParameters, SqlQuery query)
        {
            IHttpAddress address = BaseAddress;
            if (resourceParts != null)
            {
                address = address.WithResource(resourceParts);
            }

            if (customParameters != null)
            {
                foreach (var keyValuePair in customParameters)
                {
                    address = address.WithParameter(keyValuePair.Key, keyValuePair.Value);
                }
            }

            if (query != null)
            {
                address = address.WithSqlQuery(query);
            }
            return address;
        }

        private async Task<TResponse> ExecuteRequest<TResponse>(IHttpRequest request)
            where TResponse : class, new()
        {
            IHttpResponse response = await HttpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, ContentSerializer);
            return DeserializeResponse<TResponse>(response);
        }

        private TResponse DeserializeResponse<TResponse>(IHttpResponse response) where TResponse : class, new()
        {
            return ContentSerializer.Deserialize<TResponse>(response.Body);
        }
    }
}
