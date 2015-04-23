namespace DreamFactory.Model.Database
{
    using System;

    /// <summary>
    /// SQL query parameters used by IDatabaseApi.GetRecordsAsync().
    /// </summary>
    public class SqlQuery
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SqlQuery"/> class.
        /// </summary>
        /// <param name="filter">SQL WHERE clause filter to limit the records retrieved.</param>
        /// <param name="order">SQL ORDER_BY clause containing field and direction for filter results.</param>
        /// <param name="limit">Maximum number of records to return.</param>
        /// <param name="offset">Offset the filter results to a particular record index (may require order> parameter in some scenarios).</param>
        public SqlQuery(string filter, string order = "", int? limit = null, int? offset = null)
        {
            if (filter == null)
            {
                throw new ArgumentNullException("filter");
            }

            this.filter = filter;
            this.offset = offset;
            this.limit = limit;
            this.order = order;
        }

        /// <summary>
        /// SQL WHERE clause filter to limit the records retrieved.
        /// </summary>
        public string filter { get; set; }

        /// <summary>
        /// Maximum number of records to return.
        /// </summary>
        public int? limit { get; set; }

        /// <summary>
        /// Offset the filter results to a particular record index (may require order> parameter in some scenarios).
        /// </summary>
        public int? offset { get; set; }

        /// <summary>
        /// SQL ORDER_BY clause containing field and direction for filter results.
        /// </summary>
        public string order { get; set; }
    }
}