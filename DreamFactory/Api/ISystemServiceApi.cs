namespace DreamFactory.Api
{
    using DreamFactory.Model.Database;
    using DreamFactory.Model.System.Service;
    using global::System.Collections.Generic;
    using global::System.Threading.Tasks;

    /// <summary>
    /// Represents /system/service API.
    /// </summary>
    public interface ISystemServiceApi
    {

        /// <summary>
        /// Retrieve one or more services.
        /// </summary>
        /// <param name="query">Query parameters.</param>
        /// <returns>List of services.</returns>
        Task<IEnumerable<ServiceResponse>> GetServicesAsync(SqlQuery query);

        /// <summary>
        /// Create one or more services.
        /// </summary>
        /// <param name="query">Query parameters.</param>
        /// <param name="services">Services to create.</param>
        /// <returns>List of created services.</returns>
        Task<IEnumerable<ServiceResponse>> CreateServicesAsync(SqlQuery query, params ServiceRequest[] services);

        /// <summary>
        /// Update one or more services.
        /// </summary>
        /// <param name="query">Query parameters.</param>
        /// <param name="services">Services to update.</param>
        /// <returns>List of updated services.</returns>
        Task<IEnumerable<ServiceResponse>> UpdateServicesAsync(SqlQuery query, params ServiceRequest[] services);

        /// <summary>
        /// Delete one or more services.
        /// </summary>
        /// <param name="query">Query parameters.</param>
        /// <param name="ids">Service IDs to delete.</param>
        /// <returns>By default, only the id property of the record deleted is returned on success. Use 'fields' and 'related' to return more properties of the deleted records.</returns>
        Task<IEnumerable<ServiceResponse>> DeleteServicesAsync(SqlQuery query, params int[] ids);
    }
}
