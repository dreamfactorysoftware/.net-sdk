namespace DreamFactory.Api
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DreamFactory.Model;
    using DreamFactory.Model.System.Custom;

    /// <summary>
    /// Custom Settings API.
    /// </summary>
    public interface ICustomSettingsApi
    {
        /// <summary>
        /// Retrieve all custom user|system settings.
        /// </summary>
        /// <returns>Sequence of settings (names).</returns>
        Task<IEnumerable<CustomResponse>> GetCustomSettingsAsync();

        /// <summary>
        /// Set or update one custom user|system setting.
        /// </summary>
        /// <param name="custom">Instance of the CustomRequest type.</param>
        /// <returns cref="CustomResponse">Names of resources created.</returns>
        Task<IEnumerable<CustomResponse>> SetCustomSettingAsync(List<CustomRequest> custom);

        /// <summary>
        /// Retrieve one custom user|system setting.
        /// </summary>
        /// <param name="settingName">Name of the setting to retrieve.</param>
        /// <returns>CustomSetting value.</returns>
        Task<string> GetCustomSettingAsync(string settingName);

        /// <summary>
        /// Delete one custom user|system setting.
        /// </summary>
        /// <param name="settingName">Name of the setting to delete.</param>
        /// <returns>True when API call was successful, false or error otherwise.</returns>
        Task<CustomResponse> DeleteCustomSettingAsync(string settingName); 
    }
}
