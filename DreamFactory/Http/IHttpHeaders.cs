namespace DreamFactory.Http
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents immutable collection of HTTP headers.
    /// </summary>
    public interface IHttpHeaders
    {
        /// <summary>
        /// Returns new collection with a new header included.
        /// </summary>
        /// <param name="key">Header's name.</param>
        /// <param name="value">Header's value.</param>
        /// <returns>A new collection with a new header included.</returns>
        HttpHeaders Include(string key, object value);

        /// <summary>
        /// Returns new collection with a header excluded.
        /// </summary>
        /// <param name="key">Header's name.</param>
        /// <returns>A new collection with a header excluded.</returns>
        HttpHeaders Exclude(string key);

        /// <summary>
        /// Returns a copy of the headers collection.
        /// </summary>
        /// <returns>A copy of the headers collection.</returns>
        Dictionary<string, object> Build();
    }
}
