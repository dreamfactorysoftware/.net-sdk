namespace DreamFactory.Http
{
    using DreamFactory.Rest;

    /// <summary>
    /// Represents HTTP address builder.
    /// </summary>
    public interface IHttpAddress
    {
        /// <summary>
        /// Sets base address (protocol and host).
        /// </summary>
        /// <param name="value">Base address value.</param>
        /// <returns>New instance of the builder.</returns>
        IHttpAddress WithBaseAddress(string value);

        /// <summary>
        /// Sets REST API version.
        /// </summary>
        /// <param name="value">REST API version.</param>
        /// <returns>New instance of the builder.</returns>
        IHttpAddress WithVersion(RestApiVersion value);

        /// <summary>
        /// Add resources (e.g. "rest, user, session").
        /// </summary>
        /// <param name="values">Resource names to add.</param>
        /// <returns>New instance of the builder.</returns>
        IHttpAddress WithResource(params string[] values);

        /// <summary>
        /// Adds a query parameter.
        /// </summary>
        /// <param name="name">Query parameter name.</param>
        /// <param name="value">Query parameter value.</param>
        /// <returns>New instance of the builder.</returns>
        IHttpAddress WithParameter(string name, object value);

        /// <summary>
        /// Builds the final address.
        /// </summary>
        /// <returns>Final HTTP address.</returns>
        string Build();
    }
}