namespace DreamFactory.Rest
{
    using System.Threading.Tasks;
    using DreamFactory.Http;
    using DreamFactory.Model;
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
        /// Gets <see cref="IContentSerializer"/> instance.
        /// </summary>
        IContentSerializer ContentSerializer { get; }

        /// <summary>
        /// Gets base headers collection.
        /// </summary>
        IHttpHeaders BaseHeaders { get; }

        /// <summary>
        /// Gets <see cref="IServiceFactory"/> instance.
        /// </summary>
        IServiceFactory Factory { get; }

        /// <summary>
        /// Gets services exposed from the current DSP.
        /// </summary>
        /// <returns>List of service descriptors.</returns>
        Task<Services> GetServicesAsync();

        /// <summary>
        /// Gets resources available for the service.
        /// </summary>
        /// <returns>List of resources.</returns>
        Task<Resources> GetResourcesAsync(string serviceName);

    }
}
