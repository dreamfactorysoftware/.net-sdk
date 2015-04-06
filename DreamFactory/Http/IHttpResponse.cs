namespace DreamFactory.Http
{
    using System;
    using System.IO;
    using DreamFactory.Model;

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
        /// Gets HTTP response body stream.
        /// </summary>
        Stream Body { get; }

        /// <summary>
        /// Reads body content as JSON data.
        /// </summary>
        /// <typeparam name="TModel">Model DTO type.</typeparam>
        /// <returns>Model DTO instance read from body.</returns>
        TModel ReadAsJson<TModel>() where TModel : class, IModel;

        /// <summary>
        /// Reads body content as string.
        /// </summary>
        /// <returns>String read from body..</returns>
        string ReadAsString();
    }
}
