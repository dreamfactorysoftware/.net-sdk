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

        /// <summary>
        /// Download the application as a DreamFactory package file.
        /// </summary>
        /// <param name="applicationId">Application ID.</param>
        /// <param name="includeFiles">Include hosted files in the package.</param>
        /// <param name="includeServices">Include associated services configuration in the package.</param>
        /// <param name="includeSchema">Include associated database schema in the package.</param>
        /// <returns>DreamFactory package contents.</returns>
        Task<byte[]> DownloadApplicationPackageAsync(int applicationId, bool includeFiles = true, bool includeServices = true, bool includeSchema = true);

        /// <summary>
        /// Download the DreamFactory Javascript SDK amended for the app.
        /// </summary>
        /// <param name="applicationId">Application ID.</param>
        /// <returns>SDK contents.</returns>
        Task<byte[]> DownloadApplicationSdkAsync(int applicationId);
    }
}
