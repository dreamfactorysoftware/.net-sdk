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
        public DatabaseApi(
            IHttpAddress baseAddress, 
            IHttpFacade httpFacade, 
            IContentSerializer contentSerializer, 
            HttpHeaders baseHeaders, 
            string serviceName)
            : base(baseAddress, httpFacade, contentSerializer, baseHeaders, serviceName)
        {
        }

        public async Task<IEnumerable<TableInfo>> GetAccessComponentsAsync()
        {
            SqlQuery query = new SqlQuery { Fields = null };
            query.CustomParameters.Add("as_list", true);

            ResourceWrapper<TableInfo> response = await base.RequestAsync<ResourceWrapper<TableInfo>>(
                method: HttpMethod.Get, 
                resourceParts: null, 
                query: query
                );

            return response.Records;
        }

        public async Task<IEnumerable<TableInfo>> GetTableNamesAsync(bool includeSchemas, bool refresh = false)
        {
            SqlQuery query = new SqlQuery { Fields = null };
            query.CustomParameters.Add("refresh", refresh);

            ResourceWrapper<TableInfo> response = await base.RequestAsync<ResourceWrapper<TableInfo>>(
                method: HttpMethod.Get, 
                resource: "_table", 
                query: query
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

            SuccessResponse response = await base.RequestAsync<SuccessResponse>(
                method: HttpMethod.Delete,
                resource: "_schema",
                resourceIdentifier: tableName,
                query: null
                );

            return response.Success ?? false;
        }

        public Task<TableSchema> DescribeTableAsync(string tableName, bool refresh)
        {
            if (tableName == null)
            {
                throw new ArgumentNullException("tableName");
            }

            SqlQuery query = new SqlQuery { Fields = null };
            query.CustomParameters.Add("refresh", refresh);

            return base.RequestAsync<TableSchema>(
                method: HttpMethod.Get,
                resource: "_schema",
                resourceIdentifier: tableName,
                query: query
                );
        }

        public Task<FieldSchema> DescribeFieldAsync(string tableName, string fieldName, bool refresh)
        {
            if (tableName == null)
            {
                throw new ArgumentNullException("tableName");
            }

            if (fieldName == null)
            {
                throw new ArgumentNullException("fieldName");
            }

            SqlQuery query = new SqlQuery { Fields = null };
            query.CustomParameters.Add("refresh", refresh);

            return base.RequestAsync<FieldSchema>(
                method: HttpMethod.Get,
                resourceParts: new [] { "_schema", tableName, fieldName },
                query: query
                );
        }

        private async Task<bool> CreateOrUpdateTableAsync(HttpMethod httpMethod, TableSchema tableSchema)
        {
            if (tableSchema == null)
            {
                throw new ArgumentNullException("tableSchema");
            }

            SuccessResponse result = await base.RequestWithPayloadAsync<RequestResourceWrapper<TableSchema>, SuccessResponse>(
                method: httpMethod,
                resource: "_schema",
                query: null,
                payload: new RequestResourceWrapper<TableSchema> { Records = new List<TableSchema>(new [] { tableSchema }) }
                );

            return result.Success ?? false;
        }
    }
}
