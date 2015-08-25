namespace DreamFactory.Model.Database
{
    /// <summary>
    /// SQL query parameters.
    /// </summary>
    public class SqlQuery
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SqlQuery"/> class.
        /// </summary>
        /// <remarks>
        /// Default ctor sets fields=*.
        /// </remarks>
        public SqlQuery()
        {
            Fields = "*";
        }

        /// <summary>
        /// Comma-delimited list of the identifiers of the records to retrieve.
        /// </summary>
        public string Ids { get; set; }

        /// <summary>
        /// SQL WHERE clause filter to limit the records retrieved.
        /// </summary>
        public string Filter { get; set; }

        /// <summary>
        /// Maximum number of records to return.
        /// </summary>
        public int? Limit { get; set; }

        /// <summary>
        /// Offset the filter results to a particular record index (may require order> parameter in some scenarios).
        /// </summary>
        public int? Offset { get; set; }

        /// <summary>
        /// SQL ORDER_BY clause containing field and direction for filter results.
        /// </summary>
        public string Order { get; set; }

        /// <summary>
        /// Comma-delimited list of field names to retrieve for each record, '*' to return all fields.
        /// </summary>
        public string Fields { get; set; }

        /// <summary>
        /// Comma-delimited list of relationship names to retrieve for each record, or '*' to retrieve all.
        /// </summary>
        public string Related { get; set; }

        /// <summary>
        /// In batch scenarios, where supported, continue processing even after one record fails.
        /// Default behavior is to halt and return results up to the first point of failure.
        /// </summary>
        public bool? Continue { get; set; }

        /// <summary>
        /// In batch scenarios, where supported, rollback all changes if any record of the batch fails.
        /// Default behavior is to halt and return results up to the first point of failure, leaving any changes.
        /// </summary>
        public bool? Rollback { get; set; }
    }
}