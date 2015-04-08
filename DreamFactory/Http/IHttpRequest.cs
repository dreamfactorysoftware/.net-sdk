namespace DreamFactory.Http
{
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
        /// Gets body content.
        /// </summary>
        string Body { get; }

        /// <summary>
        /// Sets tunneling mode.
        /// </summary>
        /// <param name="method">HTTP method for tunneling.</param>
        void SetTunneling(HttpMethod method);
    }
}
