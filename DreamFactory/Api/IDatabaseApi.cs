namespace DreamFactory.Api
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DreamFactory.Model.Database;

    /// <summary>
    /// Represents /db API.
    /// </summary>
    public interface IDatabaseApi
    {
        /// <summary>
        /// List all role accessible components.
        /// </summary>
        /// <returns>List of accessible resource names for the user's role.</returns>
        Task<IEnumerable<TableInfo>> GetAccessComponentsAsync();

        /// <summary>
        /// List the table names in this storage.
        /// </summary>
        /// <param name="includeSchemas">Also return the names of the tables where the schema is retrievable.</param>
        /// <param name="refresh">Refresh any cached copy of the resource list.</param>
        /// <returns>Table names.</returns>
        Task<IEnumerable<TableInfo>> GetTableNamesAsync(bool includeSchemas = false, bool refresh = false);

        /// <summary>
        /// Creates a new table schema.
        /// </summary>
        /// <param name="tableSchema">Table schema.</param>
        Task<bool> CreateTableAsync(TableSchema tableSchema);

        /// <summary>
        /// Updates the existing table schema.
        /// </summary>
        /// <param name="tableSchema">Table schema.</param>
        Task<bool> UpdateTableAsync(TableSchema tableSchema);

        /// <summary>
        /// Deletes the specified table (aka drop).
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <returns>Flag indicating deletion status.</returns>
        Task<bool> DeleteTableAsync(string tableName);

        /// <summary>
        /// Retrieve table definition for the given table.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="refresh">Refresh any cached copy of the schema.</param>
        /// <returns>Table schema model.</returns>
        Task<TableSchema> DescribeTableAsync(string tableName, bool refresh = false);

        /// <summary>
        /// Retrieve table definition for the given table.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="refresh">Refresh any cached copy of the schema.</param>
        /// <returns>Table schema model.</returns>
        Task<FieldSchema> DescribeFieldAsync(string tableName, string fieldName, bool refresh = false);

        /// <summary>
        /// Create records in the specified table.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="records">Records to add.</param>
        /// <param name="query">SQL query to return created records.</param>
        /// <typeparam name="TRecord">Type of the records.</typeparam>
        /// <returns>Sequence of created records and metadata if specified in query.</returns>
        Task<ResourceWrapper<TRecord>> CreateRecordsAsync<TRecord>(string tableName, IEnumerable<TRecord> records, SqlQuery query);

        /// <summary>
        /// Update records in the specified table.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="records">Records to update.</param>
        /// <param name="query">SQL query to return created records.</param>
        /// <typeparam name="TRecord">Type of the records.</typeparam>
        /// <returns>Sequence of updated records and metadata if specified in query.</returns>
        Task<ResourceWrapper<TRecord>> UpdateRecordsAsync<TRecord>(string tableName, IEnumerable<TRecord> records, SqlQuery query);

        /// <summary>
        /// Get table records by filter.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="query">See <see cref="SqlQuery"/> class.</param>
        /// <typeparam name="TRecord">Type of the records.</typeparam>
        /// <returns>Sequence of queried records and metadata if specified in query.</returns>
        Task<ResourceWrapper<TRecord>> GetRecordsAsync<TRecord>(string tableName, SqlQuery query);

        /// <summary>
        /// Delete one or more records.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="records">Records to delete.</param>
        /// <param name="query">SQL query to return created records.</param>
        /// <typeparam name="TRecord">Type of the records.</typeparam>
        /// <returns>Sequence of deleted records and metadata if specified in query.</returns>
        Task<ResourceWrapper<TRecord>> DeleteRecordsAsync<TRecord>(string tableName, IEnumerable<TRecord> records, SqlQuery query);

        /// <summary>
        /// List callable stored procedures.
        /// </summary>
        /// <param name="refresh">Refresh any cached copy of the resource list.</param>
        /// <returns>Names of the available stored procedures on this database.</returns>
        Task<IEnumerable<string>> GetStoredProcNamesAsync(bool refresh = false);

        /// <summary>
        /// Call a stored procedure, ignoring its output.
        /// </summary>
        /// <param name="procedureName">Name of the stored procedure to call.</param>
        /// <param name="parameters">Optional stored procedure parameters.</param>
        Task CallStoredProcAsync(string procedureName, params StoredProcParam[] parameters);

        /// <summary>
        /// Call a stored procedure with response of type <typeparamref name="TStoredProcResponse"/>.
        /// </summary>
        /// <param name="procedureName">Name of the stored procedure to call.</param>
        /// <param name="parameters">Optional stored procedure parameters.</param>
        /// <typeparam name="TStoredProcResponse">Type of the response.</typeparam>
        /// <returns>Stored procedure response data.</returns>
        Task<TStoredProcResponse> CallStoredProcAsync<TStoredProcResponse>(string procedureName, params StoredProcParam[] parameters)
            where TStoredProcResponse : class, new();

        /// <summary>
        /// Call a stored procedure with response of type <typeparamref name="TStoredProcResponse"/>.
        /// </summary>
        /// <param name="procedureName">Name of the stored procedure to call.</param>
        /// <param name="wrapper">Name of a field in TStoredProcResponse receiving returned dataset.</param>
        /// <param name="parameters">Optional stored procedure parameters.</param>
        /// <typeparam name="TStoredProcResponse">Type of the response.</typeparam>
        /// <returns>Stored procedure response data.</returns>
        Task<TStoredProcResponse> CallStoredProcAsync<TStoredProcResponse>(string procedureName, string wrapper, params StoredProcParam[] parameters)
            where TStoredProcResponse : class, new();

        /// <summary>
        /// List callable stored functions.
        /// </summary>
        /// <param name="refresh">Refresh any cached copy of the resource list.</param>
        /// <returns>Names of the available stored functions on this database.</returns>
        Task<IEnumerable<string>> GetStoredFuncNamesAsync(bool refresh = false);

        /// <summary>
        /// Call a stored function with response of type <typeparamref name="TStoredFuncResponse"/>.
        /// </summary>
        /// <param name="functionName">Name of the stored function to call.</param>
        /// <param name="parameters">Optional stored function parameters.</param>
        /// <typeparam name="TStoredFuncResponse">Type of the response.</typeparam>
        /// <returns>Stored procedure response data.</returns>
        Task<TStoredFuncResponse> CallStoredFuncAsync<TStoredFuncResponse>(string functionName, params StoredProcParam[] parameters)
            where TStoredFuncResponse : class, new();

        /// <summary>
        /// Call a stored function with response of type <typeparamref name="TStoredFuncResponse"/>.
        /// </summary>
        /// <param name="functionName">Name of the stored function to call.</param>
        /// <param name="wrapper">Name of a field in TStoredFuncResponse receiving returned dataset.</param>
        /// <param name="parameters">Optional stored function parameters.</param>
        /// <typeparam name="TStoredFuncResponse">Type of the response.</typeparam>
        /// <returns>Stored function response data.</returns>
        Task<TStoredFuncResponse> CallStoredFuncAsync<TStoredFuncResponse>(string functionName, string wrapper, params StoredProcParam[] parameters)
            where TStoredFuncResponse : class, new();
    }
}
