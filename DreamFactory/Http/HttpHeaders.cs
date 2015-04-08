namespace DreamFactory.Http
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents a collection of HTTP headers.
    /// </summary>
    public class HttpHeaders
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

        /// <summary>
        /// Returns new collection with a new header included.
        /// </summary>
        /// <param name="key">Header's name.</param>
        /// <param name="value">Header's value.</param>
        /// <returns>A new collection with a new header included.</returns>
        public HttpHeaders Include(string key, object value)
        {
            Dictionary<string, object> newHeaders = new Dictionary<string, object>(headers);
            newHeaders[key] = value;
            return new HttpHeaders(newHeaders);
        }

        /// <summary>
        /// Returns new collection with a header excluded.
        /// </summary>
        /// <param name="key">Header's name.</param>
        /// <returns>A new collection with a header excluded.</returns>
        public HttpHeaders Exclude(string key)
        {
            Dictionary<string, object> newHeaders = new Dictionary<string, object>(headers);
            newHeaders.Remove(key);
            return new HttpHeaders(newHeaders);
        }

        /// <summary>
        /// Overrides a header in the current instance.
        /// </summary>
        /// <param name="key">Header's name.</param>
        /// <param name="value">Header's value.</param>
        public void Override(string key, object value = null)
        {
            if (value == null)
            {
                headers.Remove(key);
            }
            else
            {
                headers[key] = value;
            }
        }

        /// <summary>
        /// Returns a copy of the headers collection.
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, object> Build()
        {
            return new Dictionary<string, object>(headers);
        }
    }
}
