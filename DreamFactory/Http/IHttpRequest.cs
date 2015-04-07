namespace DreamFactory.Http
{
    using DreamFactory.Serialization;

    /// <summary>
    /// Represents HTTP request.
    /// </summary>
    public interface IHttpRequest
    {
        /// <summary>
        /// Gets HTTP method.
        /// </summary>
        HttpMethod Method { get; }

        /// <summary>
        /// Gets Url.
        /// </summary>
        string Url { get; }

        /// <summary>
        /// Gets request headers.
        /// </summary>
        HttpHeaders Headers { get; }

        /// <summary>
        /// Gets body object.
        /// </summary>
        object Body { get; }

        /// <summary>
        /// Gets object serializer.
        /// </summary>
        IObjectSerializer Serializer { get; }

        /// <summary>
        /// Sets tunneling mode.
        /// </summary>
        /// <param name="method">HTTP method for tunneling.</param>
        void SetTunneling(HttpMethod method);
    }
}
