namespace DreamFactory.Model.Database
{
    using global::System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Wrapper for resources in either request or response.
    /// </summary>
    /// <remarks>Meta property is populated only in response if request query contained IncludeSchema or IncludeCount parameter.</remarks>
    public class ResourceWrapper<T>
    {
        /// <summary>
        /// Query result set.
        /// </summary>
        [JsonProperty(PropertyName = "resource")]
        public List<T> Records { get; set; }

        /// <summary>
        /// Metadata for queries resources.
        /// </summary>
        public QueryMetadata Meta { get; set; }
    }
}
