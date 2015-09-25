namespace DreamFactory.Model.Database
{
    /// <summary>
    /// Query metadata class.
    /// </summary>
    public class QueryMetadata
    {
        /// <summary>
        /// Queried table schema.
        /// </summary>
        public TableSchema Schema { get; set; }

        /// <summary>
        /// Records total count.
        /// </summary>
        public int? Count { get; set; }
    }
}
