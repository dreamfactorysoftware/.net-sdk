namespace DreamFactory.Http
{
    using System;
    using System.IO;

    /// <summary>
    /// Represents HTTP response.
    /// </summary>
    public interface IHttpResponse : IDisposable
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
        /// Gets HTTP response body as Stream.
        /// </summary>
        Stream Body { get; }

        /// <summary>
        /// Reads body content using Request.Serializer.
        /// </summary>
        /// <typeparam name="TObject">Object's type.</typeparam>
        /// <returns>Object instance deserialized from body.</returns>
        TObject ReadBody<TObject>() where TObject : class;

        /// <summary>
        /// Reads body content as string.
        /// </summary>
        /// <returns>Body content.</returns>
        string ReadBody();
    }
}
