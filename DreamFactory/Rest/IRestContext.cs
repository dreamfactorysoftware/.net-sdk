namespace DreamFactory.Rest
{
    using DreamFactory.Api;
    using DreamFactory.Http;
    using DreamFactory.Serialization;

    /// <summary>
    /// Represents DreamFactory REST API entry point.
    /// </summary>
    public interface IRestContext
    {
        /// <summary>
        /// Gets <see cref="IHttpFacade"/> instance.
        /// </summary>
        IHttpFacade HttpFacade { get; }

        /// <summary>
        /// Gets <see cref="IObjectSerializer"/> instance.
        /// </summary>
        IObjectSerializer ContentSerializer { get; }

        /// <summary>
        /// Gets base headers collection.
        /// </summary>
        HttpHeaders BaseHeaders { get; }

        /// <summary>
        /// Factory method for creating serviceName API.
        /// </summary>
        /// <param name="serviceName">Service name, or null for fixed services (e.g. /user).</param>
        /// <typeparam name="TServiceApi">Service API type.</typeparam>
        /// <returns></returns>
        TServiceApi GetServiceApi<TServiceApi>(string serviceName = null) where TServiceApi : IServiceApi;
    }
}
