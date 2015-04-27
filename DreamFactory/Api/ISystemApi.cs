namespace DreamFactory.Api
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DreamFactory.Model.System;

    /// <summary>
    /// Represents /system API.
    /// </summary>
    public interface ISystemApi
    {
        /// <summary>
        /// Retrieve one or more applications.
        /// </summary>
        /// <returns>List of applications.</returns>
        Task<IEnumerable<AppResponse>> GetAppsAsync();

        /// <summary>
        /// Create one or more applications.
        /// </summary>
        /// <param name="apps">Applications to create.</param>
        /// <returns>List of created applications.</returns>
        Task<IEnumerable<AppResponse>> CreateAppsAsync(params AppRequest[] apps);

        /// <summary>
        /// Update one or more applications.
        /// </summary>
        /// <param name="apps">Applications to update.</param>
        Task UpdateAppsAsync(params AppRequest[] apps);

        /// <summary>
        /// Delete one or more applications.
        /// </summary>
        /// <param name="deleteStorage">If the app is hosted in a storage service, the storage will be deleted as well.</param>
        /// <param name="ids">Application IDs to delete.</param>
        Task DeleteAppsAsync(bool deleteStorage = false, params int[] ids);
    }
}
