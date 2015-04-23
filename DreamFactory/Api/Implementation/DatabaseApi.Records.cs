namespace DreamFactory.Api.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using DreamFactory.Http;
    using DreamFactory.Model.Database;

    internal partial class DatabaseApi
    {
        public async Task<IEnumerable<TRecord>> CreateRecordsAsync<TRecord>(string tableName, IEnumerable<TRecord> records)
        {
            if (tableName == null)
            {
                throw new ArgumentNullException("tableName");
            }

            if (records == null)
            {
                throw new ArgumentNullException("records");
            }

            IHttpAddress address = baseAddress.WithResources(serviceName, tableName).WithParameter("fields", "*");

            var recordsRequest = new { record = records.ToList() };
            string data = contentSerializer.Serialize(recordsRequest);
            IHttpRequest request = new HttpRequest(HttpMethod.Post, address.Build(), baseHeaders, data);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            return contentSerializer.Deserialize(response.Body, recordsRequest).record;
        }

        public async Task UpdateRecordsAsync<TRecord>(string tableName, IEnumerable<TRecord> records)
        {
            if (tableName == null)
            {
                throw new ArgumentNullException("tableName");
            }

            if (records == null)
            {
                throw new ArgumentNullException("records");
            }

            IHttpAddress address = baseAddress.WithResources(serviceName, tableName);

            var recordsRequest = new { record = records.ToList() };
            string data = contentSerializer.Serialize(recordsRequest);
            IHttpRequest request = new HttpRequest(HttpMethod.Patch, address.Build(), baseHeaders, data);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);
        }

        public async Task<IEnumerable<TRecord>> GetRecordsAsync<TRecord>(string tableName)
        {
            if (tableName == null)
            {
                throw new ArgumentNullException("tableName");
            }

            IHttpAddress address = baseAddress.WithResources(serviceName, tableName);

            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            var recordSet = new { record = new List<TRecord>() };
            return contentSerializer.Deserialize(response.Body, recordSet).record;
        }

        public async Task<IEnumerable<TRecord>> GetRecordsAsync<TRecord, TKeyField>(string tableName, params TKeyField[] keys)
        {
            if (tableName == null)
            {
                throw new ArgumentNullException("tableName");
            }

            string keysList = string.Join(",", keys);
            IHttpAddress address = baseAddress.WithResources(serviceName, tableName)
                                              .WithParameter("ids", keysList)
                                              .WithParameter("fields", "*");

            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            var recordSet = new { record = new List<TRecord>() };
            return contentSerializer.Deserialize(response.Body, recordSet).record;
        }

        public async Task<IEnumerable<TRecord>> GetRecordsAsync<TRecord>(string tableName, SqlQuery query)
        {
            if (tableName == null)
            {
                throw new ArgumentNullException("tableName");
            }

            if (query == null)
            {
                throw new ArgumentNullException("query");
            }

            IHttpAddress address = baseAddress.WithResources(serviceName, tableName).WithParameter("filter", query.filter);

            if (query.limit.HasValue)
            {
                address = address.WithParameter("limit", query.limit.Value);
            }

            if (query.offset.HasValue)
            {
                address = address.WithParameter("offset", query.offset.Value);
            }

            if (!string.IsNullOrEmpty(query.order))
            {
                address = address.WithParameter("order", query.order);
            }

            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            var recordSet = new { record = new List<TRecord>() };
            return contentSerializer.Deserialize(response.Body, recordSet).record;
        }

        public async Task DeleteRecordsAsync<TRecord>(string tableName, IEnumerable<TRecord> records)
        {
            if (tableName == null)
            {
                throw new ArgumentNullException("tableName");
            }

            if (records == null)
            {
                throw new ArgumentNullException("records");
            }

            IHttpAddress address = baseAddress.WithResources(serviceName, tableName);

            var recordsRequest = new { record = records.ToList() };
            string data = contentSerializer.Serialize(recordsRequest);
            IHttpRequest request = new HttpRequest(HttpMethod.Delete, address.Build(), baseHeaders, data);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);
        }
    }
}
