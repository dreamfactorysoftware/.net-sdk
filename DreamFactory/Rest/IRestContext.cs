namespace DreamFactory.Rest
{
    using System.Collections.Generic;
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
        /// Sets application name header.
        /// </summary>
        /// <param name="applicationName">New application name.</param>
        void SetApplicationName(string applicationName);

        /// <summary>
        /// Gets services exposed from the current DSP.
        /// </summary>
        /// <returns>Sequence of service descriptors.</returns>
        Task<IEnumerable<Service>> GetServicesAsync();

        /// <summary>
        /// Gets resources available for the service.
        /// </summary>
        /// <returns>Sequence of resource descriptors.</returns>
        Task<IEnumerable<Resource>> GetResourcesAsync(string serviceName);

    }
}
