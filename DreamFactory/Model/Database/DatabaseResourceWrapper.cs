namespace DreamFactory.Model.Database
{
    /// <summary>
    /// Wrapper for database response resources.
    /// </summary>
    /// <typeparam name="T">Type of the records.</typeparam>
    public class DatabaseResourceWrapper<T> : ResourceWrapper<T>
    {
        /// <summary>
        /// Metadata for requested resources.
        /// </summary>
        /// <remarks>Property is populated only if request query contained IncludeSchema or IncludeCount parameter.</remarks>
        public QueryMetadata Meta { get; set; }
    }
}
