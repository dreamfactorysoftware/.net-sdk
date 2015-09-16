namespace DreamFactory.Api.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DreamFactory.Http;
    using DreamFactory.Model;
    using DreamFactory.Model.Database;
    using DreamFactory.Serialization;

    internal partial class DatabaseApi : BaseApi, IDatabaseApi
    {
        public DatabaseApi(IHttpAddress baseAddress, 
            IHttpFacade httpFacade, 
            IContentSerializer contentSerializer, 
            HttpHeaders baseHeaders, 
            string serviceName)
            : base(baseAddress, httpFacade, contentSerializer, baseHeaders, serviceName)
        {
        }

        public async Task<IEnumerable<TableInfo>> GetAccessComponentsAsync()
        {
            ResourceWrapper<TableInfo> response = await base.RequestSingleAsync<ResourceWrapper<TableInfo>>(
                method: HttpMethod.Get, 
                resourceParts: null, 
                query: new SqlQuery { Fields = null, CustomParameters = new Dictionary<string, object> { { "as_list", true } } }
                );

            return response.Records;
        }

        public async Task<IEnumerable<TableInfo>> GetTableNamesAsync(bool includeSchemas, bool refresh = false)
        {
            ResourceWrapper<TableInfo> response = await base.RequestSingleAsync<ResourceWrapper<TableInfo>>(
                method: HttpMethod.Get, 
                resource: "_table", 
                query: new SqlQuery { Fields = null, CustomParameters = new Dictionary<string, object> { { "refresh", true } } }
                );

            return response.Records;
        }

        public Task<bool> CreateTableAsync(TableSchema tableSchema)
        {
            return CreateOrUpdateTableAsync(HttpMethod.Post, tableSchema);
        }

        public Task<bool> UpdateTableAsync(TableSchema tableSchema)
        {
            return CreateOrUpdateTableAsync(HttpMethod.Put, tableSchema);
        }

        public async Task<bool> DeleteTableAsync(string tableName)
        {
            if (tableName == null)
            {
                throw new ArgumentNullException("tableName");
            }

            SuccessResponse response = await base.RequestSingleAsync<SuccessResponse>(
                method: HttpMethod.Delete,
                resource: "_schema",
                resourceIdentifier: tableName,
                query: null
                );

            return response.Success ?? false;
        }

        public async Task<TableSchema> DescribeTableAsync(string tableName, bool refresh)
        {
            if (tableName == null)
            {
                throw new ArgumentNullException("tableName");
            }

            return await base.RequestSingleAsync<TableSchema>(
                method: HttpMethod.Get,
                resource: "_schema",
                resourceIdentifier: tableName,
                query: new SqlQuery { Fields = null, CustomParameters = new Dictionary<string, object> { { "refresh", refresh } } }
                );
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

            return await base.RequestSingleAsync<FieldSchema>(
                method: HttpMethod.Get,
                resourceParts: new [] { "_schema", tableName, fieldName },
                query: new SqlQuery { Fields = null, CustomParameters = new Dictionary<string, object> { { "refresh", refresh } } }
                );
        }

        private async Task<bool> CreateOrUpdateTableAsync(HttpMethod httpMethod, TableSchema tableSchema)
        {
            if (tableSchema == null)
            {
                throw new ArgumentNullException("tableSchema");
            }

            SuccessResponse result = await base.RequestSingleWithPayloadAsync<ResourceWrapper<TableSchema>, SuccessResponse>(
                method: httpMethod,
                resource: "_schema",
                query: null,
                record: new ResourceWrapper<TableSchema> { Records = new List<TableSchema>(new [] { tableSchema }) }
                );

            return result.Success ?? false;
        }
    }
}
