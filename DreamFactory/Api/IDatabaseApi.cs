namespace DreamFactory.Api
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents /db API.
    /// </summary>
    public interface IDatabaseApi : IServiceApi
    {
        /// <summary>
        /// Gets table records and creates TRecord instances.
        /// </summary>
        /// <param name="tableName">Table name.</param>
        /// <returns>Sequence of TRecord instances created from the response.</returns>
        Task<IEnumerable<TRecord>> GetRecordsAsync<TRecord>(string tableName);
    }
}
