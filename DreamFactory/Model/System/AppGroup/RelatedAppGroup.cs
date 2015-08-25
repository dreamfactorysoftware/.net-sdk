namespace DreamFactory.Model.System.AppGroup
{
    using global::System;

    /// <summary>
    /// RelatedAppGroup.
    /// </summary>
    public class RelatedAppGroup
    {
        /// <summary>
        /// Identifier of this application group.
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Displayable name of this application group.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of this application group.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Date this group was created.
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// User Id of who created this group.
        /// </summary>
        public int? CreatedById { get; set; }

        /// <summary>
        /// Date this group was last modified.
        /// </summary>
        public DateTime? LastModifiedDate { get; set; }

        /// <summary>
        /// User Id of who last modified this group.
        /// </summary>
        public int? LastModifiedById { get; set; }
    }
}
