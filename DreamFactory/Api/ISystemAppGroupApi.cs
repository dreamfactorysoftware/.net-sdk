namespace DreamFactory.Api
{
    using DreamFactory.Model.Database;
    using DreamFactory.Model.System.AppGroup;
    using global::System.Collections.Generic;
    using global::System.Threading.Tasks;

    /// <summary>
    /// Represents /system/appgroup API.
    /// </summary>
    public interface ISystemAppGroupApi
    {
        /// <summary>
        /// Retrieve one or more application groups.
        /// </summary>
        /// <param name="query">Query parameters.</param>
        /// <returns>List of application groups.</returns>
        Task<IEnumerable<AppGroupResponse>> GetAppGroupsAsync(SqlQuery query);

        /// <summary>
        /// Create one or more application groups.
        /// </summary>
        /// <param name="query">Query parameters.</param>
        /// <param name="appGroups">Application groups to create.</param>
        /// <returns>List of created application groups.</returns>
        Task<IEnumerable<AppGroupResponse>> CreateAppGroupsAsync(SqlQuery query, params AppGroupRequest[] appGroups);

        /// <summary>
        /// Update one or more application groups.
        /// </summary>
        /// <param name="query">Query parameters.</param>
        /// <param name="appGroups">Application groups to update.</param>
        /// <returns>List of updated application groups.</returns>
        Task<IEnumerable<AppGroupResponse>> UpdateAppGroupsAsync(SqlQuery query, params AppGroupRequest[] appGroups);

        /// <summary>
        /// Delete one or more application groups.
        /// </summary>
        /// <param name="query">Query parameters.</param>
        /// <param name="ids">Application Group IDs to delete.</param>
        /// <returns>By default, only the id property of the record deleted is returned on success. Use 'fields' and 'related' to return more properties of the deleted records.</returns>
        Task<IEnumerable<AppGroupResponse>> DeleteAppGroupsAsync(SqlQuery query, params int[] ids);
    }
}
