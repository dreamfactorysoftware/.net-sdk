namespace DreamFactory.Model.System.Role
{
    using global::System;

    /// <summary>
    /// RelatedRole.
    /// </summary>
    public class RelatedRole
    {
        /// <summary>
        /// Identifier of this role.
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Displayable name of this role.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of this role.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Is this role active for use.
        /// </summary>
        public bool? IsActive { get; set; }

        /// <summary>
        /// Default launched app for this role.
        /// </summary>
        public int? DefaultAppId { get; set; }

        /// <summary>
        /// Date this role was created.
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// User Id of who created this role.
        /// </summary>
        public int? CreatedById { get; set; }

        /// <summary>
        /// Date this role was last modified.
        /// </summary>
        public DateTime? LastModifiedDate { get; set; }

        /// <summary>
        /// User Id of who last modified this role.
        /// </summary>
        public int? LastModifiedById { get; set; }
    }
}
