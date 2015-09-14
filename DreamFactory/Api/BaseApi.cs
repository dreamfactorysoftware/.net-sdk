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
        protected IHttpAddress BaseAddress { get; }
        protected IHttpFacade HttpFacade { get; }
        protected IContentSerializer ContentSerializer { get; }
        protected HttpHeaders BaseHeaders { get; }

        protected BaseApi(IHttpAddress baseAddress, IHttpFacade httpFacade, IContentSerializer contentSerializer, HttpHeaders baseHeaders, string apiName)
        {
            this.BaseAddress = baseAddress.WithResource(apiName);
            this.HttpFacade = httpFacade;
            this.ContentSerializer = contentSerializer;
            this.BaseHeaders = baseHeaders;
        }

        internal async Task<TResponseRecord> QueryRecordAsync<TResponseRecord>(string resource, string resourceIdentifier, SqlQuery query)
            where TResponseRecord : class, new()
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

            IHttpAddress address = BaseAddress.WithResource(resource, resourceIdentifier);
            address = address.WithSqlQuery(query);

            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), BaseHeaders);
            IHttpResponse response = await HttpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, ContentSerializer);

            return ContentSerializer.Deserialize<TResponseRecord>(response.Body);
        }

        internal async Task<IEnumerable<TResponseRecord>> QueryRecordsAsync<TResponseRecord>(string resource, SqlQuery query)
        {
            if (resource == null)
            {
                throw new ArgumentNullException("resource");
            }

            if (query == null)
            {
                throw new ArgumentNullException("query");
            }

            IHttpAddress address = BaseAddress.WithResource(resource);
            address = address.WithSqlQuery(query);

            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), BaseHeaders);
            IHttpResponse response = await HttpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, ContentSerializer);

            var result = new { resource = new List<TResponseRecord>() };
            return ContentSerializer.Deserialize(response.Body, result).resource;
        }

        internal async Task<IEnumerable<TResponseRecord>> QueryRecordsWithParametersAsync<TResponseRecord>(string resource, params KeyValuePair<string, object>[] parameters)
        {
            if (resource == null)
            {
                throw new ArgumentNullException("resource");
            }

            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }

            IHttpAddress address = BaseAddress.WithResource(resource);

            foreach (var keyValuePair in parameters)
            {
                address = address.WithParameter(keyValuePair.Key, keyValuePair.Value);
            }

            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), BaseHeaders);
            IHttpResponse response = await HttpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, ContentSerializer);

            var result = new { resource = new List<TResponseRecord>() };
            return ContentSerializer.Deserialize(response.Body, result).resource;
        }

        internal async Task<IEnumerable<TResponseRecord>> CreateOrUpdateRecordsAsync<TRequestRecord, TResponseRecord>(HttpMethod method, string resource, SqlQuery query, params TRequestRecord[] records)
            where TRequestRecord : IRecord
            where TResponseRecord : class, new()
        {
            if (query == null)
            {
                throw new ArgumentNullException("query");
            }

            if (records == null || records.Length < 1)
            {
                throw new ArgumentException("At least one parameter must be specified", "records");
            }

            IHttpAddress address = BaseAddress.WithResource(resource);
            address = address.WithSqlQuery(query);

            string body = ContentSerializer.Serialize(new { resource = new List<TRequestRecord>(records), ids = records.Select(x => x.Id) });
            IHttpRequest request = new HttpRequest(method, address.Build(), BaseHeaders, body);

            IHttpResponse response = await HttpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, ContentSerializer);

            var responses = new { resource = new List<TResponseRecord>() };
            return ContentSerializer.Deserialize(response.Body, responses).resource;
        }

        internal async Task<TResponseRecord> CreateOrUpdateRecordAsync<TRequestRecord, TResponseRecord>(string resource, string identifier, TRequestRecord record, HttpMethod method, SqlQuery query)
            where TRequestRecord : class, new()
            where TResponseRecord : class, new()
        {
            if (resource == null)
            {
                throw new ArgumentNullException("resource");
            }

            if (identifier == null)
            {
                throw new ArgumentNullException("identifier");
            }

            if (record == null)
            {
                throw new ArgumentNullException("record");
            }

            if (query == null)
            {
                throw new ArgumentNullException("query");
            }

            IHttpAddress address = BaseAddress.WithResource(resource, identifier);
            address = address.WithSqlQuery(query);

            string body = ContentSerializer.Serialize(record);
            IHttpRequest request = new HttpRequest(method, address.Build(), BaseHeaders, body);

            IHttpResponse response = await HttpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, ContentSerializer);

            return ContentSerializer.Deserialize<TResponseRecord>(response.Body);
        }

        internal async Task<IEnumerable<TResponseRecord>> DeleteRecordsAsync<TResponseRecord>(string resource, SqlQuery query, bool force, params int[] ids)
            where TResponseRecord : class, new()
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


            IHttpAddress address = BaseAddress.WithResource(resource);
            address = address.WithSqlQuery(query);

            if (force)
            {
                address = address.WithParameter("force", true);
            }
            else
            {
                address = address.WithParameter("ids", string.Join(",", ids));
            }

            IHttpRequest request = new HttpRequest(HttpMethod.Delete, address.Build(), BaseHeaders);

            IHttpResponse response = await HttpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, ContentSerializer);

            var responses = new { resource = new List<TResponseRecord>() };
            return ContentSerializer.Deserialize(response.Body, responses).resource;
        }

        internal async Task<TResponseRecord> DeleteRecordAsync<TResponseRecord>(string resource, string identifier, SqlQuery query)
            where TResponseRecord : class, new()
        {
            if (resource == null)
            {
                throw new ArgumentNullException("resource");
            }

            if (identifier == null)
            {
                throw new ArgumentNullException("identifier");
            }

            if (query == null)
            {
                throw new ArgumentNullException("query");
            }

            IHttpAddress address = BaseAddress.WithResource(resource, identifier);
            address = address.WithSqlQuery(query);

            IHttpRequest request = new HttpRequest(HttpMethod.Delete, address.Build(), BaseHeaders);

            IHttpResponse response = await HttpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, ContentSerializer);

            return ContentSerializer.Deserialize<TResponseRecord>(response.Body);
        }
    }
}
