namespace DreamFactory.Http
{
    using System;
    using System.IO;

    /// <summary>
    /// Represents HTTP request.
    /// </summary>
    public interface IHttpRequest : IDisposable
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
        /// Gets body stream.
        /// </summary>
        Stream Body { get; }

        /// <summary>
        /// Sets tunneling mode.
        /// </summary>
        /// <param name="method">HTTP method for tunneling.</param>
        void SetTunneling(HttpMethod method);
    }
}
