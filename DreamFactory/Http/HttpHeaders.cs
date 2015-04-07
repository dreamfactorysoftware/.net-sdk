namespace DreamFactory.Http
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents immutable collection of HTTP headers.
    /// </summary>
    public class HttpHeaders
    {
        private readonly HttpHeaders previousInstance;

        private readonly string headerKey;

        private readonly object headerValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpHeaders"/> class.
        /// </summary>
        /// <param name="key">Header's key.</param>
        /// <param name="value">Header's value.</param>
        public HttpHeaders(string key, object value)
            : this(null, key, value)
        {
        }

        private HttpHeaders(HttpHeaders previous, string key, object value)
        {
            previousInstance = previous;
            headerKey = key;
            headerValue = value;
        }

        /// <summary>
        /// Creates new <see cref="HttpHeaders"/> instance with new key-value pair.
        /// </summary>
        /// <param name="key">Header's key.</param>
        /// <param name="value">Header's value.</param>
        /// <returns>New instance with given key-value pair added.</returns>
        public HttpHeaders WithHeader(string key, object value)
        {
            return new HttpHeaders(this, key, value);
        }

        /// <summary>
        /// Appends another headers collection.
        /// </summary>
        /// <param name="others">Another headers collection.</param>
        /// <returns>New instance with other collection added.</returns>
        public HttpHeaders WithHeaders(HttpHeaders others)
        {
            HttpHeaders next = this;

            foreach (KeyValuePair<string, object> pair in others.GetHeaders())
            {
                next = next.WithHeader(pair.Key, pair.Value);
            }

            return next;
        }

        /// <summary>
        /// Gets all headers.
        /// </summary>
        /// <returns>Sequence of key-value pairs.</returns>
        public IEnumerable<KeyValuePair<string, object>> GetHeaders()
        {
            yield return new KeyValuePair<string, object>(headerKey, headerValue);

            if (previousInstance == null)
            {
                yield break;
            }

            foreach (KeyValuePair<string, object> header in previousInstance.GetHeaders())
            {
                yield return header;
            }
        }
    }
}
