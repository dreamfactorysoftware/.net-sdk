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

        internal async Task<TResponse> QueryRecordAsync<TResponse>(string resource, string resourceIdentifier, SqlQuery query)
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

            return await QueryRecordAsync<TResponse>(new[] { resource, resourceIdentifier }, query);
        }

        internal async Task<TResponse> QueryRecordAsync<TResponse>(string[] resourceParts, SqlQuery query)
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

        internal async Task<IEnumerable<TResponse>> QueryRecordsAsync<TResponse>(string resource, SqlQuery query)
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

        internal async Task<IEnumerable<TResponse>> QueryRecordsWithParametersAsync<TResponse>(string resource, params KeyValuePair<string, object>[] parameters)
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

        internal async Task<IEnumerable<TResponse>> CreateOrUpdateRecordsAsync<TRequest, TResponse>(HttpMethod method, string resource, SqlQuery query, params TRequest[] records)
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

        internal async Task<TResponse> CreateOrUpdateRecordAsync<TRequest, TResponse>(string resource, string resourceIdentifier, HttpMethod method, SqlQuery query, TRequest record)
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

            return await CreateOrUpdateRecordAsync<TRequest, TResponse>(new[] { resource, resourceIdentifier }, method, query, record);
        }

        internal async Task<TResponse> CreateOrUpdateRecordAsync<TRequest, TResponse>(string[] resourceParts, HttpMethod method, SqlQuery query, TRequest record)
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

        internal async Task<IEnumerable<TResponse>> DeleteRecordsAsync<TResponse>(string resource, SqlQuery query, bool force, params int[] ids)
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
                new KeyValuePair<string, object>("force", true),
                new KeyValuePair<string, object>("ids", string.Join(",", ids))
            }
            );

            return response.Records;
        }

        internal async Task<TResponse> DeleteRecordAsync<TResponse>(string resource, string resourceIdentifier, SqlQuery query)
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

            return await DeleteRecordAsync<TResponse>(new string[] { resource, resourceIdentifier }, query);
        }

        internal async Task<TResponse> DeleteRecordAsync<TResponse>(string[] resourceParts, SqlQuery query)
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
