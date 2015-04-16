namespace DreamFactory.Api
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DreamFactory.Model.User;

    /// <summary>
    /// Represents /user API.
    /// </summary>
    public interface IUserApi
    {
        /// <summary>
        /// Register a new user in the system.
        /// </summary>
        /// <param name="register">User information to register.</param>
        /// <param name="login">Login and create a session upon successful registration.</param>
        /// <returns>True when API call was successful, false or error otherwise.</returns>
        Task<bool> RegisterAsync(Register register, bool login = false);

        /// <summary>
        /// Login and create a new user session.
        /// </summary>
        /// <remarks>
        /// Successful login operation will set ApplicationName and SessionToken headers.
        /// </remarks>
        /// <param name="applicationName">Application name.</param>
        /// <param name="email">Email.</param>
        /// <param name="password">Password.</param>
        /// <param name="duration">Session duration.</param>
        /// <returns>Session object instance.</returns>
        Task<Session> LoginAsync(string applicationName, string email, string password, int duration = 0);

        /// <summary>
        /// Retrieve the current user session information.
        /// </summary>
        /// <returns>Session object instance.</returns>
        Task<Session> GetSessionAsync();

        /// <summary>
        /// Logout and destroy the current user session.
        /// </summary>
        /// <returns>True when API call was successful, false or error otherwise.</returns>
        Task<bool> LogoutAsync();

        /// <summary>
        /// Update the current user's profile information.
        /// </summary>
        /// <param name="profileRequest">ProfileRequest data.</param>
        /// <returns>True when API call was successful, false or error otherwise.</returns>
        Task<bool> UpdateProfileAsync(ProfileRequest profileRequest);

        /// <summary>
        /// Retrieve the current user's profile information.
        /// </summary>
        /// <returns>ProfileResponse data.</returns>
        Task<ProfileResponse> GetProfileAsync();

        /// <summary>
        /// Change the current user's password.
        /// </summary>
        /// <param name="oldPassword">Old password.</param>
        /// <param name="newPassword">New password.</param>
        /// <returns>True when API call was successful, false or error otherwise.</returns>
        Task<bool> ChangePasswordAsync(string oldPassword, string newPassword);

        /// <summary>
        /// Request the current user's password reset.
        /// </summary>
        /// <param name="email">User's email to be used with code to validate email confirmation.</param>
        /// <returns>PasswordResponse data.</returns>
        Task<PasswordResponse> RequestPasswordResetAsync(string email);

        /// <summary>
        /// Complete the current user's password reset with either security code or answer.
        /// </summary>
        /// <param name="email">User's email to be used with code to validate email confirmation.</param>
        /// <param name="newPassword">New password.</param>
        /// <param name="code">Confirmation code received in email.</param>
        /// <param name="answer">Answer to user's security question.</param>
        /// <returns>True when API call was successful, false or error otherwise.</returns>
        Task<bool> CompletePasswordResetAsync(string email, string newPassword, string code = null, string answer = null);

        /// <summary>
        /// Retrieve the current user's device information.
        /// </summary>
        /// <returns>Sequence of DeviceResponse data.</returns>
        Task<IEnumerable<DeviceResponse>> GetDevicesAsync();

        /// <summary>
        /// Create a record of the current user's device information.
        /// </summary>
        /// <param name="deviceRequest">DeviceRequest data.</param>
        /// <returns>True when API call was successful, false or error otherwise.</returns>
        Task<bool> SetDeviceAsync(DeviceRequest deviceRequest);

        /// <summary>
        /// Retrieve all custom user settings.
        /// </summary>
        /// <returns>Sequence of settings (names).</returns>
        Task<IEnumerable<string>> GetCustomSettingsAsync();

        /// <summary>
        /// Set or update one custom user setting.
        /// </summary>
        /// <param name="settingName">Name of the setting to retrieve.</param>
        /// <param name="entity">Instance of the TEntity type.</param>
        /// <typeparam name="TEntity">User defined type for the setting.</typeparam>
        /// <returns>True when API call was successful, false or error otherwise.</returns>
        Task<bool> SetCustomSettingAsync<TEntity>(string settingName, TEntity entity) where TEntity : class, new();

        /// <summary>
        /// Retrieve one custom user setting.
        /// </summary>
        /// <param name="settingName">Name of the setting to retrieve.</param>
        /// <typeparam name="TEntity">User defined type for the setting.</typeparam>
        /// <returns>CustomSetting data.</returns>
        Task<TEntity> GetCustomSettingAsync<TEntity>(string settingName) where TEntity: class, new();

        /// <summary>
        /// Delete one custom user setting.
        /// </summary>
        /// <param name="settingName">Name of the setting to delete.</param>
        /// <returns>True when API call was successful, false or error otherwise.</returns>
        Task<bool> DeleteCustomSettingAsync(string settingName);
    }
}
