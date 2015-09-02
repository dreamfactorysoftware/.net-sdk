namespace DreamFactory.Model.System.Role
{
    using DreamFactory.Model.System.App;
    using DreamFactory.Model.System.Service;
    using DreamFactory.Model.System.User;
    using global::System.Collections.Generic;

    /// <summary>
    /// RoleResponse.
    /// </summary>
    public class RoleRequest : IRecord
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
    }
}
