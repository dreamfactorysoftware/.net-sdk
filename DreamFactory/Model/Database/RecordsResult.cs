namespace DreamFactory.Model.Database
{
    using global::System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Records query result containing metadata.
    /// </summary>
    public class RecordsResult<T>
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
