// ReSharper disable InconsistentNaming
namespace DreamFactory.Model.System
{
    using global::System;
    using global::System.Collections.Generic;

    /// <summary>
    /// RelatedRole.
    /// </summary>
    public class RelatedRole
    {
        /// <summary>
        /// Identifier of this role.
        /// </summary>
        public int? id { get; set; }

        /// <summary>
        /// Displayable name of this role.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Description of this role.
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// Is this role active for use.
        /// </summary>
        public bool? is_active { get; set; }

        /// <summary>
        /// Default launched app for this role.
        /// </summary>
        public int? default_app_id { get; set; }

        /// <summary>
        /// Date this role was created.
        /// </summary>
        public DateTime? created_date { get; set; }

        /// <summary>
        /// User Id of who created this role.
        /// </summary>
        public int? created_by_id { get; set; }

        /// <summary>
        /// Date this role was last modified.
        /// </summary>
        public DateTime? last_modified_date { get; set; }

        /// <summary>
        /// User Id of who last modified this role.
        /// </summary>
        public int? last_modified_by_id { get; set; }
    }

    /// <summary>
    /// RelatedRoles.
    /// </summary>
    public class RelatedRoles
    {
        /// <summary>
        /// Array of system user records.
        /// </summary>
        public List<RelatedRole> record { get; set; }
    }
}
