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
        private readonly string serviceName;

        public DatabaseApi(IHttpAddress baseAddress, IHttpFacade httpFacade, IContentSerializer contentSerializer, IHttpHeaders baseHeaders, string serviceName)
        {
            this.baseAddress = baseAddress;
            this.httpFacade = httpFacade;
            this.contentSerializer = contentSerializer;
            this.baseHeaders = baseHeaders;
            this.serviceName = serviceName;
        }

        public async Task<IEnumerable<TableInfo>> GetAccessComponentsAsync()
        {
            IHttpAddress address = baseAddress.WithResources(serviceName);
            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            var resource = new { resource = new List<TableInfo>() };
            return contentSerializer.Deserialize(response.Body, resource).resource;
        }

        public async Task<IEnumerable<string>> GetTableNames(bool includeSchemas, bool refresh = false)
        {
            IHttpAddress address = baseAddress.WithResources(serviceName).WithParameter("names_only", true);
            
            if (includeSchemas)
            {
                address = address.WithParameter("include_schemas", true);
            }

            if (refresh)
            {
                address = address.WithParameter("refresh", true);
            }

            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            var resource = new { resource = new List<string>() };
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

            IHttpAddress address = baseAddress.WithResources(serviceName, "_schema", tableName);

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

            IHttpAddress address = baseAddress.WithResources(serviceName, "_schema", tableName);

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

            IHttpAddress address = baseAddress.WithResources(serviceName, "_schema", tableName, fieldName);

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

            IHttpAddress address = baseAddress.WithResources(serviceName, "_schema");

            var tableSchemas = new { table = new List<TableSchema> { tableSchema } };
            string body = contentSerializer.Serialize(tableSchemas);
            IHttpRequest request = new HttpRequest(httpMethod, address.Build(), baseHeaders, body);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);
        }
    }
}
