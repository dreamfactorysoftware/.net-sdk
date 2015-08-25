namespace DreamFactory.Model.System.Role
{
    using DreamFactory.Model.System.App;
    using DreamFactory.Model.System.Service;
    using DreamFactory.Model.System.User;
    using global::System.Collections.Generic;

    /// <summary>
    /// RoleResponse.
    /// </summary>
    public class RoleRequest
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
        /// Related app by default_app_id.
        /// </summary>
        public RelatedApp DefaultApp { get; set; }

        /// <summary>
        /// Related users by User.role_id.
        /// </summary>
        public List<RelatedUser> Users { get; set; }

        /// <summary>
        /// Related apps by role assignment.
        /// </summary>
        public List<RelatedApp> Apps { get; set; }

        /// <summary>
        /// Related services by role assignment.
        /// </summary>
        public List<RelatedService> Services { get; set; }
    }
}
