namespace DreamFactory.Api
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Custom Settings API.
    /// </summary>
    public interface ICustomSettingsApi
    {
        /// <summary>
        /// Retrieve all custom user|system settings.
        /// </summary>
        /// <returns>Sequence of settings (names).</returns>
        Task<IEnumerable<string>> GetCustomSettingsAsync();

        /// <summary>
        /// Set or update one custom user|system setting.
        /// </summary>
        /// <param name="settingName">Name of the setting to retrieve.</param>
        /// <param name="entity">Instance of the TEntity type.</param>
        /// <typeparam name="TEntity">User defined type for the setting.</typeparam>
        /// <returns>True when API call was successful, false or error otherwise.</returns>
        Task<bool> SetCustomSettingAsync<TEntity>(string settingName, TEntity entity) where TEntity : class, new();

        /// <summary>
        /// Retrieve one custom user|system setting.
        /// </summary>
        /// <param name="settingName">Name of the setting to retrieve.</param>
        /// <typeparam name="TEntity">User defined type for the setting.</typeparam>
        /// <returns>CustomSetting data.</returns>
        Task<TEntity> GetCustomSettingAsync<TEntity>(string settingName) where TEntity : class, new();

        /// <summary>
        /// Delete one custom user|system setting.
        /// </summary>
        /// <param name="settingName">Name of the setting to delete.</param>
        /// <returns>True when API call was successful, false or error otherwise.</returns>
        Task<bool> DeleteCustomSettingAsync(string settingName); 
    }
}
