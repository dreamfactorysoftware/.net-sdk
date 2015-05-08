// ReSharper disable InconsistentNaming
namespace DreamFactory.Model.System.Role
{
    using DreamFactory.Model.System.App;
    using DreamFactory.Model.System.Service;
    using DreamFactory.Model.System.User;
    using global::System;
    using global::System.Collections.Generic;

    /// <summary>
    /// RoleResponse.
    /// </summary>
    public class RoleResponse
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
        /// Related app by default_app_id.
        /// </summary>
        public RelatedApp default_app { get; set; }

        /// <summary>
        /// Related users by User.role_id.
        /// </summary>
        public List<RelatedUser> users { get; set; }

        /// <summary>
        /// Related apps by role assignment.
        /// </summary>
        public List<RelatedApp> apps { get; set; }

        /// <summary>
        /// Related services by role assignment.
        /// </summary>
        public List<RelatedService> services { get; set; }

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
}
