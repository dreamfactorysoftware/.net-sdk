namespace DreamFactory.Api
{
    using DreamFactory.Model.Database;
    using DreamFactory.Model.System.Lookup;
    using global::System.Collections.Generic;
    using global::System.Threading.Tasks;

    /// <summary>
    /// Represents /system/lookup API.
    /// </summary>
    public interface ISystemLookupApi
    {
        /// <summary>
        /// Retrieve one or more lookup record.
        /// </summary>
        /// <param name="query">Query parameters.</param>
        /// <returns>List of lookup records.</returns>
        Task<IEnumerable<LookupResponse>> GetLookupsAsync(SqlQuery query);

        /// <summary>
        /// Create one or more lookup record.
        /// </summary>
        /// <param name="query">Query parameters.</param>
        /// <param name="records">Lookup records to create.</param>
        /// <returns>List of lookup records.</returns>
        Task<IEnumerable<LookupResponse>> CreateLookupsAsync(SqlQuery query, params LookupRequest[] records);

        /// <summary>
        /// Update one or more lookup record.
        /// </summary>
        /// <param name="query">Query parameters.</param>
        /// <param name="records">Lookup records to update.</param>
        /// <returns>List of lookup records.</returns>
        Task<IEnumerable<LookupResponse>> UpdateLookupsAsync(SqlQuery query, params LookupRequest[] records);

        /// <summary>
        /// Delete one or more lookup record.
        /// </summary>
        /// <param name="query">Query parameters.</param>
        /// <param name="ids">Lookup records IDs to delete.</param>
        /// <returns>By default, only the id property of the record deleted is returned on success. Use 'fields' and 'related' to return more properties of the deleted records.</returns>
        Task<IEnumerable<LookupResponse>> DeleteLookupsAsync(SqlQuery query, params int[] ids);
    }
}
