namespace DreamFactory.Api
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DreamFactory.Model;
    using DreamFactory.Model.Database;
    using DreamFactory.Model.System.Custom;

    /// <summary>
    /// Custom Settings API.
    /// </summary>
    public interface ICustomSettingsApi
    {
        /// <summary>
        /// Retrieve all custom user|system settings.
        /// </summary>
        /// <param name="query">SQL query to return created records.</param>
        /// <returns>Sequence of custom settings.</returns>
        Task<ResourceWrapper<CustomResponse>> GetCustomSettingsAsync(SqlQuery query = null);

        /// <summary>
        /// Set custom user|system settings.
        /// </summary>
        /// <param name="customs">Collection of CustomRequest type.</param>
        /// <param name="query">SQL query to return created records.</param>
        /// <returns>Custom records created.</returns>
        Task<ResourceWrapper<CustomResponse>> SetCustomSettingsAsync(List<CustomRequest> customs, SqlQuery query = null);

        /// <summary>
        /// Update custom user|system settings.
        /// </summary>
        /// <param name="customs">Collection of CustomRequest type.</param>
        /// <param name="query">SQL query to return updated records.</param>
        /// <returns>Custom records updated.</returns>
        Task<ResourceWrapper<CustomResponse>> UpdateCustomSettingsAsync(List<CustomRequest> customs, SqlQuery query = null);

        /// <summary>
        /// Retrieve one custom user|system setting.
        /// </summary>
        /// <param name="settingName">Name of the setting to retrieve.</param>
        /// <returns cref="CustomResponse">Custom setting record.</returns>
        Task<CustomResponse> GetCustomSettingAsync(string settingName);

        /// <summary>
        /// Set or update one custom user|system setting.
        /// </summary>
        /// <param name="settingName">Name of the setting to retrieve.</param>
        /// <param name="custom">Instance of the CustomRequest type.</param>
        /// <param name="query">SQL query to return updated records.</param>
        /// <returns cref="CustomResponse">Custom setting record updated.</returns>
        Task<CustomResponse> UpdateCustomSettingAsync(string settingName, CustomRequest custom, SqlQuery query = null);

        /// <summary>
        /// Delete one custom user|system setting.
        /// </summary>
        /// <param name="settingName">Name of the setting to delete.</param>
        /// <param name="query">SQL query to return deleted records.</param>
        /// <returns cref="CustomResponse">Custom setting record deleted.</returns>
        Task<CustomResponse> DeleteCustomSettingAsync(string settingName, SqlQuery query = null);
    }
}
