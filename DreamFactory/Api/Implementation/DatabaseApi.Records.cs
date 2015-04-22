namespace DreamFactory.Api.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using DreamFactory.Http;

    internal partial class DatabaseApi
    {
        public async Task CreateRecordsAsync<TRecord>(string tableName, IEnumerable<TRecord> records)
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
            IHttpRequest request = new HttpRequest(HttpMethod.Post, address.Build(), baseHeaders, data);

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
            recordSet = contentSerializer.Deserialize(response.Body, recordSet);
            if (recordSet == null)
            {
                throw new DreamFactoryException("Failed to deserialize records, please check the type is matching table schema: " + typeof(TRecord).FullName);
            }

            return recordSet.record;
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
