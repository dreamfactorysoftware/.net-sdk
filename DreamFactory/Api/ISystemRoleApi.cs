namespace DreamFactory.Api
{
    using DreamFactory.Model.Database;
    using DreamFactory.Model.System.Role;
    using global::System.Collections.Generic;
    using global::System.Threading.Tasks;

    /// <summary>
    /// Represents /system/role API.
    /// </summary>
    public interface ISystemRoleApi
    {
        /// <summary>
        /// Retrieve one or more roles.
        /// </summary>
        /// <param name="query">Query parameters.</param>
        /// <returns>List of roles.</returns>
        Task<IEnumerable<RoleResponse>> GetRolesAsync(SqlQuery query);

        /// <summary>
        /// Create one or more roles.
        /// </summary>
        /// <param name="query">Query parameters.</param>
        /// <param name="roles">Roles to create.</param>
        /// <returns>List of created roles.</returns>
        Task<IEnumerable<RoleResponse>> CreateRolesAsync(SqlQuery query, params RoleRequest[] roles);

        /// <summary>
        /// Update one or more roles.
        /// </summary>
        /// <param name="query">Query parameters.</param>
        /// <param name="roles">Roles to update.</param>
        /// <returns>List of updated roles.</returns>
        Task<IEnumerable<RoleResponse>> UpdateRolesAsync(SqlQuery query, params RoleRequest[] roles);

        /// <summary>
        /// Delete one or more roles.
        /// </summary>
        /// <param name="query">Query parameters.</param>
        /// <param name="ids">Role IDs to delete.</param>
        /// <returns>By default, only the id property of the record deleted is returned on success. Use 'fields' and 'related' to return more properties of the deleted records.</returns>
        Task<IEnumerable<RoleResponse>> DeleteRolesAsync(SqlQuery query, params int[] ids);
    }
}
