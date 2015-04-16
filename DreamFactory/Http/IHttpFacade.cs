namespace DreamFactory.Http
{
    using System.Threading.Tasks;

    /// <summary>
    /// Represents stateless HTTP facade.
    /// </summary>
    public interface IHttpFacade
    {
        /// <summary>
        /// Sends HTTP request to receive body as string.
        /// </summary>
        /// <param name="request"><see cref="IHttpRequest"/> instance.</param>
        /// <returns><see cref="IHttpResponse"/> instance.</returns>
        Task<IHttpResponse> RequestAsync(IHttpRequest request);
    }
}
