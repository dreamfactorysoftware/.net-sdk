namespace DreamFactory.Rest
{
    using DreamFactory.Api;
    using DreamFactory.Http;

    /// <summary>
    /// Represents DreamFactory REST API entry point.
    /// </summary>
    public interface IRestContext
    {
        /// <summary>
        /// Gets base address (URL).
        /// </summary>
        string BaseAddress { get; }

        /// <summary>
        /// Gets REST API version.
        /// </summary>
        RestApiVersion ApiVersion { get; }

        /// <summary>
        /// Gets <see cref="IHttpFacade"/> instance.
        /// </summary>
        IHttpFacade HttpFacade { get; }

        /// <summary>
        /// Gets User API accessor.
        /// </summary>
        IUserApi User { get; }

        /// <summary>
        /// Gets System API accessor.
        /// </summary>
        ISystemApi System { get; }

        /// <summary>
        /// Gets Email API accessor.
        /// </summary>
        IEmailApi Email { get; }

        /// <summary>
        /// Gets Database API accessor.
        /// </summary>
        /// <param name="serviceName">Database service name.</param>
        /// <returns>Database API accessor specific to the selected service.</returns>
        IDatabaseApi GetDatabaseApi(string serviceName);

        /// <summary>
        /// Gets Files API accessor.
        /// </summary>
        /// <param name="serviceName">Files service name.</param>
        /// <returns>Files API accessor specific to the selected service.</returns>
        IFilesApi GetFilesApi(string serviceName);

        /// <summary>
        /// Sets application name.
        /// </summary>
        /// <param name="applicationName">Application name.</param>
        void SetApplicationName(string applicationName);

        /// <summary>
        /// Sets session token.
        /// </summary>
        /// <param name="sessionToken">Session token.</param>
        void SetSessionToken(string sessionToken);
    }
}
