// ReSharper disable InconsistentNaming
namespace DreamFactory.Model.System
{
    using global::System;
    using global::System.Collections.Generic;

    /// <summary>
    /// RelatedAppGroup.
    /// </summary>
    public class RelatedAppGroup
    {
        /// <summary>
        /// Identifier of this application group.
        /// </summary>
        public int? id { get; set; }

        /// <summary>
        /// Displayable name of this application group.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Description of this application group.
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// Date this group was created.
        /// </summary>
        public DateTime? created_date { get; set; }

        /// <summary>
        /// User Id of who created this group.
        /// </summary>
        public int? created_by_id { get; set; }

        /// <summary>
        /// Date this group was last modified.
        /// </summary>
        public DateTime? last_modified_date { get; set; }

        /// <summary>
        /// User Id of who last modified this group.
        /// </summary>
        public int? last_modified_by_id { get; set; }
    }

    /// <summary>
    /// RelatedAppGroups.
    /// </summary>
    public class RelatedAppGroups
    {
        /// <summary>
        /// Array of system user records.
        /// </summary>
        public List<RelatedAppGroup> record { get; set; }
    }
}
