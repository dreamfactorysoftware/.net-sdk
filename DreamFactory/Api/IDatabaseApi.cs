namespace DreamFactory.Api
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DreamFactory.Model;

    /// <summary>
    /// Represents /db API.
    /// </summary>
    public interface IDatabaseApi
    {
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
