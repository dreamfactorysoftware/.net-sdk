namespace DreamFactory.Api
{
    using DreamFactory.Model.Database;
    using DreamFactory.Model.System.App;
    using global::System.Collections.Generic;
    using global::System.Threading.Tasks;

    /// <summary>
    /// Represents /system/app API.
    /// </summary>
    public interface ISystemAppApi
    {
        /// <summary>
        /// Retrieve one or more applications.
        /// </summary>
        /// <param name="query">Query parameters.</param>
        /// <returns>List of applications.</returns>
        Task<IEnumerable<AppResponse>> GetAppsAsync(SqlQuery query);

        /// <summary>
        /// Create one or more applications.
        /// </summary>
        /// <param name="query">Query parameters.</param>
        /// <param name="apps">Applications to create.</param>
        /// <returns>List of created applications.</returns>
        Task<IEnumerable<AppResponse>> CreateAppsAsync(SqlQuery query, params AppRequest[] apps);

        /// <summary>
        /// Update one or more applications.
        /// </summary>
        /// <param name="query">Query parameters.</param>
        /// <param name="apps">Applications to update.</param>
        /// <returns>List of updated applications.</returns>
        Task<IEnumerable<AppResponse>> UpdateAppsAsync(SqlQuery query, params AppRequest[] apps);

        /// <summary>
        /// Delete one or more applications.
        /// </summary>
        /// <param name="query">Query parameters.</param>
        /// <param name="ids">Application IDs to delete.</param>
        /// <returns>By default, only the id property of the record deleted is returned on success. Use 'fields' and 'related' to return more properties of the deleted records.</returns>
        Task<IEnumerable<AppResponse>> DeleteAppsAsync(SqlQuery query, params int[] ids);
    }
}
