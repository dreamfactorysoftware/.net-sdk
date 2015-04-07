namespace DreamFactory.Api
{
    using System.Threading.Tasks;
    using DreamFactory.Model;

    /// <summary>
    /// Represents /user/session API.
    /// </summary>
    public interface IUserSessionApi : IServiceApi
    {
        /// <summary>
        /// Login request.
        /// </summary>
        /// <remarks>
        /// Successful login operation will set ApplicationName and SessionToken headers.
        /// </remarks>
        /// <param name="applicationName">Application name.</param>
        /// <param name="login">Login data.</param>
        /// <returns>Session object instance.</returns>
        Task<Session> LoginAsync(string applicationName, Login login);

        /// <summary>
        /// Logout request.
        /// </summary>
        /// <returns>Logout object instance.</returns>
        Task<Logout> LogoutAsync();
    }
}
