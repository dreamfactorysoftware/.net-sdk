namespace DreamFactory.Api
{
    using DreamFactory.Model.User;
    using global::System.Threading.Tasks;

    /// <summary>
    /// Represents /system/admin API.
    /// </summary>
    public interface ISystemAdminApi
    {
        /// <summary>
        /// Login and create a new admin session.
        /// </summary>
        /// <remarks>
        /// Successful login operation will set ApplicationName and SessionToken headers.
        /// This call works only with v2 of the api.
        /// </remarks>
        /// <param name="email">Email.</param>
        /// <param name="password">Password.</param>
        /// <param name="duration">Session duration.</param>
        /// <returns>Session object instance.</returns>
        Task<Session> LoginAdminAsync(string email, string password, int duration = 0);

        /// <summary>
        /// Logout and destroy the current admin session.
        /// </summary>
        /// <returns>
        /// True if the operation was successful and false if it wasn't.
        /// </returns>
        Task<bool> LogoutAdminAsync();

        /// <summary>
        /// Retrieve the current admin session information.
        /// </summary>
        /// <returns>Session object instance.</returns>
        Task<Session> GetAdminSessionAsync();

        /// <summary>
        /// Change the admin's password.
        /// </summary>
        /// <param name="oldPassword">Old password.</param>
        /// <param name="newPassword">New password.</param>
        /// <returns>True when API call was successful, false or error otherwise.</returns>
        Task<bool> ChangeAdminPasswordAsync(string oldPassword, string newPassword);
    }
}
