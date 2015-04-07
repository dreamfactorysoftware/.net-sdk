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
        /// Factory method for creating serviceName API.
        /// </summary>
        /// <param name="serviceName">Service name, or null for fixed services (e.g. /user).</param>
        /// <typeparam name="TServiceApi">Service API type.</typeparam>
        /// <returns></returns>
        TServiceApi GetServiceApi<TServiceApi>(string serviceName = null)
            where TServiceApi : IServiceApi;

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

        /// <summary>
        /// Creates collection of application-name and session-token headers.
        /// </summary>
        /// <returns>New headers collection.</returns>
        HttpHeaders CreateHeaders();
    }
}
