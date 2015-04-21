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
        Task<IEnumerable<string>> GetTableNames(bool includeSchemas, bool refresh = false);

        /// <summary>
        /// Creates a new table using TRecord schema.
        /// </summary>
        /// <param name="tableSchema">Table schema.</param>
        /// <returns>Flag indicating creation status.</returns>
        Task CreateTableAsync(TableSchema tableSchema);

        /// <summary>
        /// Deletes the specified table (aka drop).
        /// </summary>
        /// <param name="tableName">Table's name.</param>
        /// <returns>Flag indicating deletion status.</returns>
        Task<bool> DeleteTableAsync(string tableName);

        /// <summary>
        /// Gets table schema.
        /// </summary>
        /// <param name="tableName">Table's name.</param>
        /// <returns>Table schema model.</returns>
        Task<TableSchema> DescribeTableAsync(string tableName);

        /// <summary>
        /// Creates records in the specified table.
        /// </summary>
        /// <param name="tableName">Table's name.</param>
        /// <param name="records">Sequence of record instances.</param>
        /// <typeparam name="TRecord">Record's type.</typeparam>
        Task CreateRecordsAsync<TRecord>(string tableName, IEnumerable<TRecord> records);

        /// <summary>
        /// Gets table records and creates TRecord instances.
        /// </summary>
        /// <param name="tableName">Table name.</param>
        /// <returns>Sequence of TRecord instances created from the response.</returns>
        Task<IEnumerable<TRecord>> GetRecordsAsync<TRecord>(string tableName);
    }
}
