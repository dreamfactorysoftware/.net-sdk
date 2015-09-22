namespace DreamFactory.Api
{
    using DreamFactory.Model.Database;
    using DreamFactory.Model.System.Cors;
    using global::System.Collections.Generic;
    using global::System.Threading.Tasks;

    /// <summary>
    /// Represents /system/cors API.
    /// </summary>
    public interface ISystemCorsApi
    {
        /// <summary>
        /// Retrieve one or more CORS record.
        /// </summary>
        /// <param name="query">Query parameters.</param>
        /// <returns>List of CORS records.</returns>
        Task<IEnumerable<CorsResponse>> GetCorsAsync(SqlQuery query);

        /// <summary>
        /// Create one or more CORS record.
        /// </summary>
        /// <param name="query">Query parameters.</param>
        /// <param name="records">CORS records to create.</param>
        /// <returns>List of CORS records.</returns>
        Task<IEnumerable<CorsResponse>> CreateCorsAsync(SqlQuery query, params CorsRequest[] records);

        /// <summary>
        /// Update one or more CORS record.
        /// </summary>
        /// <param name="query">Query parameters.</param>
        /// <param name="records">CORS records to update.</param>
        /// <returns>List of CORS records.</returns>
        Task<IEnumerable<CorsResponse>> UpdateCorsAsync(SqlQuery query, params CorsRequest[] records);

        /// <summary>
        /// Delete one or more CORS record.
        /// </summary>
        /// <param name="query">Query parameters.</param>
        /// <param name="ids">CORS records IDs to delete.</param>
        /// <returns>By default, only the id property of the record deleted is returned on success. Use 'fields' and 'related' to return more properties of the deleted records.</returns>
        Task<IEnumerable<CorsResponse>> DeleteCorsAsync(SqlQuery query, params int[] ids);
    }
}
