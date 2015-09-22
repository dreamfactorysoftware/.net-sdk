namespace DreamFactory.Model.System.Lookup
{
    using global::System;

    /// <summary>
    /// RelatedLookup.
    /// </summary>
    public class RelatedLookup
    {
        /// <summary>
        /// Id of this lookup.
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Name of this lookup.
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
        /// Description of this lookup.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Id of the user that created this lookup.
        /// </summary>
        public int? CreatedById { get; set; }

        /// <summary>
        /// Id of the user that last modified this lookup.
        /// </summary>
        public int? ModifiedById { get; set; }

        /// <summary>
        /// Date this lookup was created.
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Date this lookup was last modified.
        /// </summary>
        public DateTime? LastModifiedDate { get; set; }
    }
}
