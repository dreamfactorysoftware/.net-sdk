namespace DreamFactory.Api.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DreamFactory.Http;
    using DreamFactory.Model.Database;

    internal partial class DatabaseApi
    {
        public async Task<ResourceWrapper<TRecord>> CreateRecordsAsync<TRecord>(string tableName, IEnumerable<TRecord> records, SqlQuery query)
        {
            if (tableName == null)
            {
                throw new ArgumentNullException("tableName");
            }

            if (records == null)
            {
                throw new ArgumentNullException("records");
            }

            if (query == null)
            {
                throw new ArgumentNullException("query");
            }

            return await base.RequestSingleWithPayloadAsync<ResourceWrapper<TRecord>, ResourceWrapper<TRecord>>(
                method: HttpMethod.Post,
                resource: "_table",
                resourceIdentifier: tableName,
                query: query,
                record: new ResourceWrapper<TRecord> { Records = new List<TRecord>(records) }
                );
        }

        public async Task<ResourceWrapper<TRecord>> UpdateRecordsAsync<TRecord>(string tableName, IEnumerable<TRecord> records, SqlQuery query)
        {
            if (tableName == null)
            {
                throw new ArgumentNullException("tableName");
            }

            if (records == null)
            {
                throw new ArgumentNullException("records");
            }

            if (query == null)
            {
                throw new ArgumentNullException("query");
            }

            return await base.RequestSingleWithPayloadAsync<ResourceWrapper<TRecord>, ResourceWrapper<TRecord>>(
                method: HttpMethod.Patch,
                resource: "_table",
                resourceIdentifier: tableName,
                query: query,
                record: new ResourceWrapper<TRecord> { Records = new List<TRecord>(records) }
                );
        }

        public async Task<ResourceWrapper<TRecord>> GetRecordsAsync<TRecord>(string tableName, SqlQuery query)
        {
            if (tableName == null)
            {
                throw new ArgumentNullException("tableName");
            }

            if (query == null)
            {
                throw new ArgumentNullException("query");
            }

            return await base.RequestSingleAsync<ResourceWrapper<TRecord>>(
                method: HttpMethod.Get,
                resource: "_table",
                resourceIdentifier: tableName,
                query: query
                );
        }

        public async Task<ResourceWrapper<TRecord>> DeleteRecordsAsync<TRecord>(string tableName, IEnumerable<TRecord> records, SqlQuery query)
        {
            if (tableName == null)
            {
                throw new ArgumentNullException("tableName");
            }

            if (records == null)
            {
                throw new ArgumentNullException("records");
            }

            if (query == null)
            {
                throw new ArgumentNullException("query");
            }

            return await base.RequestSingleWithPayloadAsync<ResourceWrapper<TRecord>, ResourceWrapper<TRecord>>(
                method: HttpMethod.Delete,
                resource: "_table",
                resourceIdentifier: tableName,
                query: query,
                record: new ResourceWrapper<TRecord> { Records = new List<TRecord>(records)}
                );
        }
    }
}
