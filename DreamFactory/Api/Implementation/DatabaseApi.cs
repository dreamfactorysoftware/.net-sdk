namespace DreamFactory.Api.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DreamFactory.Http;
    using DreamFactory.Model.Database;
    using DreamFactory.Serialization;

    internal partial class DatabaseApi : IDatabaseApi
    {
        private readonly IHttpAddress baseAddress;
        private readonly IHttpFacade httpFacade;
        private readonly IContentSerializer contentSerializer;
        private readonly IHttpHeaders baseHeaders;

        public DatabaseApi(IHttpAddress baseAddress, IHttpFacade httpFacade, IContentSerializer contentSerializer, IHttpHeaders baseHeaders, string serviceName)
        {
            this.baseAddress = baseAddress.WithResource(serviceName);
            this.httpFacade = httpFacade;
            this.contentSerializer = contentSerializer;
            this.baseHeaders = baseHeaders;
        }

        public async Task<IEnumerable<TableInfo>> GetAccessComponentsAsync()
        {
            IHttpRequest request = new HttpRequest(HttpMethod.Get, baseAddress.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            var resource = new { resource = new List<TableInfo>() };
            return contentSerializer.Deserialize(response.Body, resource).resource;
        }

        public async Task<IEnumerable<TableInfo>> GetTableNamesAsync(bool includeSchemas, bool refresh = false)
        {
            IHttpAddress address = baseAddress.WithResource("_table");
                
            if (refresh)
            {
                address = address.WithParameter("refresh", true);
            }

            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            var resource = new { resource = new List<TableInfo>() };
            return contentSerializer.Deserialize(response.Body, resource).resource;
        }

        public Task CreateTableAsync(TableSchema tableSchema)
        {
            return CreateOrUpdateTableAsync(HttpMethod.Post, tableSchema);
        }

        public Task UpdateTableAsync(TableSchema tableSchema)
        {
            return CreateOrUpdateTableAsync(HttpMethod.Put, tableSchema);
        }

        public async Task<bool> DeleteTableAsync(string tableName)
        {
            if (tableName == null)
            {
                throw new ArgumentNullException("tableName");
            }

            IHttpAddress address = baseAddress.WithResource( "_schema", tableName);
            IHttpRequest request = new HttpRequest(HttpMethod.Delete, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            var success = new { success = false };
            success = contentSerializer.Deserialize(response.Body, success);

            return success.success;
        }

        public async Task<TableSchema> DescribeTableAsync(string tableName, bool refresh)
        {
            if (tableName == null)
            {
                throw new ArgumentNullException("tableName");
            }

            IHttpAddress address = baseAddress.WithResource( "_schema", tableName);

            if (refresh)
            {
                address = address.WithParameter("refresh", true);
            }

            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            return contentSerializer.Deserialize<TableSchema>(response.Body);
        }

        public async Task<FieldSchema> DescribeFieldAsync(string tableName, string fieldName, bool refresh)
        {
            if (tableName == null)
            {
                throw new ArgumentNullException("tableName");
            }

            if (fieldName == null)
            {
                throw new ArgumentNullException("fieldName");
            }

            IHttpAddress address = baseAddress.WithResource( "_schema", tableName, fieldName);

            if (refresh)
            {
                address = address.WithParameter("refresh", true);
            }

            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            return contentSerializer.Deserialize<FieldSchema>(response.Body);
        }

        private async Task CreateOrUpdateTableAsync(HttpMethod httpMethod, TableSchema tableSchema)
        {
            if (tableSchema == null)
            {
                throw new ArgumentNullException("tableSchema");
            }

            IHttpAddress address = baseAddress.WithResource("_schema");

            var tableSchemas = new { resource = new List<TableSchema> { tableSchema } };
            string body = contentSerializer.Serialize(tableSchemas);
            IHttpRequest request = new HttpRequest(httpMethod, address.Build(), baseHeaders, body);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);
        }
    }
}
