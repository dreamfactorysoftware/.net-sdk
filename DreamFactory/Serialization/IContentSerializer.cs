namespace DreamFactory.Serialization
{
    /// <summary>
    /// Represents content serializer.
    /// </summary>
    public interface IContentSerializer
    {
        /// <summary>
        /// Gets content type string, e.g. application/json.
        /// </summary>
        string ContentType { get; }

        /// <summary>
        /// Serializes given object instance to string.
        /// </summary>
        /// <param name="instance">Object instance.</param>
        /// <returns></returns>
        string Serialize<TObject>(TObject instance) where TObject : class;

        /// <summary>
        /// Deserializes object from content string.
        /// </summary>
        /// <param name="content">Content string.</param>
        /// <returns>Created object instance.</returns>
        TObject Deserialize<TObject>(string content) where TObject : class;
    }
}
