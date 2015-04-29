// ReSharper disable InconsistentNaming
namespace DreamFactory.Model.System
{
    /// <summary>
    /// RoleResponse.
    /// </summary>
    public class RoleRequest
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
        public RelatedUsers users { get; set; }

        /// <summary>
        /// Related apps by role assignment.
        /// </summary>
        public RelatedApps apps { get; set; }

        /// <summary>
        /// Related services by role assignment.
        /// </summary>
        public RelatedServices services { get; set; }
    }
}
