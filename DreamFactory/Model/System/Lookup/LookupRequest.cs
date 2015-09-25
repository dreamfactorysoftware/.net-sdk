namespace DreamFactory.Model.System.Lookup
{
    /// <summary>
    /// LookupRequest.
    /// </summary>
    public class LookupRequest : IRecord
    {
        /// <summary>
        /// Identifier of this lookup.
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Name for this lookup.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Value of this lookup.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Indicator whether this lookup is private.
        /// </summary>
        public bool? Private { get; set; }

        /// <summary>
        /// Description for this lookup.
        /// </summary>
        public string Description { get; set; }
    }
}
