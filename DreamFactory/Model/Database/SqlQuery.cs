namespace DreamFactory.Model.Database
{
    using global::System.Collections.Generic;

    /// <summary>
    /// SQL query parameters.
    /// </summary>
    public class SqlQuery
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SqlQuery"/> class.
        /// </summary>
        /// <remarks>
        /// By default ctor sets fields=* unless stated otherwise in parameters.
        /// </remarks>
        public SqlQuery()
        {
            Fields = "*";
            CustomParameters = new Dictionary<string, object>();
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
        /// Include the total number of filter results in returned metadata.
        /// </summary>
        public bool? IncludeCount { get; set; }

        /// <summary>
        /// Include the schema of the table queried in returned metadata.
        /// </summary>
        public bool? IncludeSchema { get; set; }

        /// <summary>
        /// Collection of key/value pairs representing custom parameters that will be added to query string.
        /// </summary>
        /// <remarks>Adding parameters in this collection does not override any other parameters that were added in query string with the same key.</remarks>
        public Dictionary<string, object> CustomParameters { get; set; }
    }
}