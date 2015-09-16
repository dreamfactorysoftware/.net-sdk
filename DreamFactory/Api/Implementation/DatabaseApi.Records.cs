namespace DreamFactory.Api.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DreamFactory.Http;
    using DreamFactory.Model;
    using DreamFactory.Model.Database;

    internal partial class DatabaseApi
    {
        public async Task<DatabaseResourceWrapper<TRecord>> CreateRecordsAsync<TRecord>(string tableName, IEnumerable<TRecord> records, SqlQuery query)
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

            return await base.RequestWithPayloadAsync<RequestResourceWrapper<TRecord>, DatabaseResourceWrapper<TRecord>>(
                method: HttpMethod.Post,
                resource: "_table",
                resourceIdentifier: tableName,
                query: query,
                payload: new RequestResourceWrapper<TRecord> { Records = new List<TRecord>(records) }
                );
        }

        public async Task<DatabaseResourceWrapper<TRecord>> UpdateRecordsAsync<TRecord>(string tableName, IEnumerable<TRecord> records, SqlQuery query)
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

            return await base.RequestWithPayloadAsync<RequestResourceWrapper<TRecord>, DatabaseResourceWrapper<TRecord>>(
                method: HttpMethod.Patch,
                resource: "_table",
                resourceIdentifier: tableName,
                query: query,
                payload: new RequestResourceWrapper<TRecord> { Records = new List<TRecord>(records) }
                );
        }

        public async Task<DatabaseResourceWrapper<TRecord>> GetRecordsAsync<TRecord>(string tableName, SqlQuery query)
        {
            if (tableName == null)
            {
                throw new ArgumentNullException("tableName");
            }

            if (query == null)
            {
                throw new ArgumentNullException("query");
            }

            return await base.RequestAsync<DatabaseResourceWrapper<TRecord>>(
                method: HttpMethod.Get,
                resource: "_table",
                resourceIdentifier: tableName,
                query: query
                );
        }

        public async Task<DatabaseResourceWrapper<TRecord>> DeleteRecordsAsync<TRecord>(string tableName, IEnumerable<TRecord> records, SqlQuery query)
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

            return await base.RequestWithPayloadAsync<RequestResourceWrapper<TRecord>, DatabaseResourceWrapper<TRecord>>(
                method: HttpMethod.Delete,
                resource: "_table",
                resourceIdentifier: tableName,
                query: query,
                payload: new RequestResourceWrapper<TRecord> { Records = new List<TRecord>(records)}
                );
        }
    }
}
