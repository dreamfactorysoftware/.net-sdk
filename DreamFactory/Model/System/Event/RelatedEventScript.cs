namespace DreamFactory.Model.System.Event
{
    using global::System;

    /// <summary>
    /// RelatedEventScript.
    /// </summary>
    public class RelatedEventScript
    {
        /// <summary>
        /// Name of this event script.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Type of this event script.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Indicator whether this event script is active.
        /// </summary>
        public bool? IsActive { get; set; }

        /// <summary>
        /// Indicator whether this event script affects process.
        /// </summary>
        public bool? AffectsProcess { get; set; }

        /// <summary>
        /// Content of this event script.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Config for this event script.
        /// </summary>
        public string Config { get; set; }

        /// <summary>
        /// Id of the user that created this event script.
        /// </summary>
        public int? CreatedById { get; set; }

        /// <summary>
        /// Id of the user that last modified this event script.
        /// </summary>
        public int? ModifiedById { get; set; }

        /// <summary>
        /// Date this event script was created.
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Date this event script was last modified.
        /// </summary>
        public DateTime? LastModifiedDate { get; set; }
    }
}
