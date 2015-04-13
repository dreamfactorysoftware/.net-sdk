namespace DreamFactory.Api
{
    using System.Threading.Tasks;
    using DreamFactory.Model;

    /// <summary>
    /// Represents /user API.
    /// </summary>
    public interface IUserApi
    {
        /// <summary>
        /// Register().
        /// </summary>
        /// <param name="register">User information to register.</param>
        /// <param name="login">Login and create a session upon successful registration.</param>
        /// <returns></returns>
        Task<bool> RegisterAsync(Register register, bool login = false);

        /// <summary>
        /// login().
        /// </summary>
        /// <remarks>
        /// Successful login operation will set ApplicationName and SessionToken headers.
        /// </remarks>
        /// <param name="applicationName">Application name.</param>
        /// <param name="login">Login data.</param>
        /// <returns>Session object instance.</returns>
        Task<Session> LoginAsync(string applicationName, Login login);

        /// <summary>
        /// getSession().
        /// </summary>
        /// <returns>Session object instance.</returns>
        Task<Session> GetSessionAsync();

        /// <summary>
        /// logout().
        /// </summary>
        /// <returns>True if logout succeeded.</returns>
        Task<bool> LogoutAsync();

        /// <summary>
        /// updateProfile().
        /// </summary>
        /// <param name="profileRequest">ProfileRequest data.</param>
        /// <returns>True when API call was successful, false or error otherwise.</returns>
        Task<bool> UpdateProfileAsync(ProfileRequest profileRequest);

        /// <summary>
        /// getProfile().
        /// </summary>
        /// <returns>ProfileResponse data.</returns>
        Task<ProfileResponse> GetProfileAsync();

        /// <summary>
        /// changePassword().
        /// </summary>
        /// <param name="oldPassword">Old password.</param>
        /// <param name="newPassword">New password.</param>
        /// <returns>True when API call was successful, false or error otherwise.</returns>
        Task<bool> ChangePasswordAsync(string oldPassword, string newPassword);

        /// <summary>
        /// changePassword() requesting password reset.
        /// </summary>
        /// <param name="email">User's email to be used with code to validate email confirmation.</param>
        /// <returns>PasswordResponse data.</returns>
        Task<PasswordResponse> RequestPasswordResetAsync(string email);

        /// <summary>
        /// changePassword() completing password reset with either <paramref name="code"/> or <paramref name="answer"/>.
        /// </summary>
        /// <param name="email">User's email to be used with code to validate email confirmation.</param>
        /// <param name="newPassword">New password.</param>
        /// <param name="code">Confirmation code received in email.</param>
        /// <param name="answer">Answer to user's security question.</param>
        /// <returns>True when API call was successful, false or error otherwise.</returns>
        Task<bool> CompletePasswordResetAsync(string email, string newPassword, string code = null, string answer = null);
    }
}
