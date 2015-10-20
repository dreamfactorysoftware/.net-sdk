namespace DreamFactory.Model.Database
{
    using Newtonsoft.Json;

    /// <summary>
    /// Query metadata class.
    /// </summary>
    public class QueryMetadata
    {
        /// <summary>
        /// Queried table schema.
        /// </summary>
        [JsonProperty(PropertyName = "schema")]
        public TableSchema Schema { get; set; }

        /// <summary>
        /// Records total count.
        /// </summary>
        [JsonProperty(PropertyName = "count")]
        public int? Count { get; set; }
    }
}
