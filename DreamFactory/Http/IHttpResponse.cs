namespace DreamFactory.Http
{
    /// <summary>
    /// Represents HTTP response.
    /// </summary>
    public interface IHttpResponse
    {
        /// <summary>
        /// Gets the corresponding request instance.
        /// </summary>
        IHttpRequest Request { get; }

        /// <summary>
        /// Gets HTTP status code.
        /// </summary>
        int Code { get; }

        /// <summary>
        /// Gets HTTP response body.
        /// </summary>
        string Body { get; }
    }
}
