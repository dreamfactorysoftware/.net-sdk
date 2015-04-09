namespace DreamFactory.Http
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents HTTP headers collection.
    /// </summary>
    public class HttpHeaders : IHttpHeaders
    {
        private readonly Dictionary<string, object> headers;

        /// <summary>
        /// X-Dreamfactory-Application-Name header.
        /// </summary>
        public const string DreamFactoryApplicationHeader = "X-Dreamfactory-Application-Name";

        /// <summary>
        /// X-DreamFactory-Session-Token header.
        /// </summary>
        public const string DreamFactorySessionTokenHeader = "X-DreamFactory-Session-Token";

        /// <summary>
        /// Content-Type header.
        /// </summary>
        public const string ContentTypeHeader = "Content-Type";

        /// <summary>
        /// Accept header.
        /// </summary>
        public const string AcceptHeader = "Accept";

        /// <summary>
        /// X-HTTP-Method header.
        /// </summary>
        internal const string TunnelingHeader = "X-HTTP-Method";

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpHeaders"/> class.
        /// </summary>
        public HttpHeaders()
        {
            headers = new Dictionary<string, object>();
        }

        private HttpHeaders(Dictionary<string, object> others)
        {
            headers = others;
        }

        /// <inheritdoc />
        public HttpHeaders Include(string key, object value)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }

            Dictionary<string, object> newHeaders = new Dictionary<string, object>(headers);
            newHeaders[key] = value;
            return new HttpHeaders(newHeaders);
        }

        /// <inheritdoc />
        public HttpHeaders Exclude(string key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }

            Dictionary<string, object> newHeaders = new Dictionary<string, object>(headers);
            newHeaders.Remove(key);
            return new HttpHeaders(newHeaders);
        }

        /// <inheritdoc />
        public Dictionary<string, object> Build()
        {
            return new Dictionary<string, object>(headers);
        }

        /// <summary>
        /// Adds a header or update existing.
        /// </summary>
        /// <param name="key">Header's name.</param>
        /// <param name="value">Header's value.</param>
        public void AddOrUpdate(string key, object value)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }

            headers[key] = value;
        }

        /// <summary>
        /// Deletes a header.
        /// </summary>
        /// <param name="key">Header's name.</param>
        public void Delete(string key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }

            headers.Remove(key);
        }
    }
}
