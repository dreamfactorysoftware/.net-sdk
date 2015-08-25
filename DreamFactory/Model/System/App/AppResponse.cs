namespace DreamFactory.Model.System.App
{
    using DreamFactory.Model.System.AppGroup;
    using DreamFactory.Model.System.Role;
    using DreamFactory.Model.System.Service;
    using DreamFactory.Model.System.User;
    using global::System;
    using global::System.Collections.Generic;

    /// <summary>
    /// AppResponse.
    /// </summary>
    public class AppResponse
    {
        /// <summary>
        /// Identifier of this application.
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Displayable name of this application.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Name of the application to use in API transactions.
        /// </summary>
        public string ApiName { get; set; }

        /// <summary>
        /// Description of this application.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Is this system application active for use.
        /// </summary>
        public bool? IsActive { get; set; }

        /// <summary>
        /// URL for accessing this application.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// True when this application is hosted elsewhere, but available in Launchpad.
        /// </summary>
        public bool? IsUrlExternal { get; set; }

        /// <summary>
        /// If hosted and imported, the url of zip or package file where the code originated.
        /// </summary>
        public string ImportUrl { get; set; }

        /// <summary>
        /// If hosted, the storage service identifier.
        /// </summary>
        public string StorageServiceId { get; set; }

        /// <summary>
        /// If hosted, the container of the storage service.
        /// </summary>
        public string StorageContainer { get; set; }

        /// <summary>
        /// True when this app needs to hide launchpad.
        /// </summary>
        public bool? RequiresFullscreen { get; set; }

        /// <summary>
        /// True to allow launchpad access via toggle.
        /// </summary>
        public bool? AllowFullscreenToggle { get; set; }

        /// <summary>
        /// Screen location for toggle placement.
        /// </summary>
        public string ToggleLocation { get; set; }

        /// <summary>
        /// True when the app relies on a browser plugin.
        /// </summary>
        public bool? RequiresPlugin { get; set; }

        /// <summary>
        /// Related roles by Role.default_app_id.
        /// </summary>
        public List<RelatedRole> RolesDefaultApp { get; set; }

        /// <summary>
        /// Related users by User.default_app_id.
        /// </summary>
        public List<RelatedUser> UsersDefaultApp { get; set; }

        /// <summary>
        /// Related groups by app to group assignment.
        /// </summary>
        public List<RelatedAppGroup> AppGroups { get; set; }

        /// <summary>
        /// Related roles by app to role assignment.
        /// </summary>
        public List<RelatedRole> Roles { get; set; }

        /// <summary>
        /// Related services by app to service assignment.
        /// </summary>
        public List<RelatedService> Services { get; set; }
        
        /// <summary>
        /// Date this application was created.
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// User Id of who created this application.
        /// </summary>
        public int? CreatedById { get; set; }

        /// <summary>
        /// Date this application was last modified.
        /// </summary>
        public DateTime? LastModifiedDate { get; set; }

        /// <summary>
        /// User Id of who last modified this application.
        /// </summary>
        public int? LastModifiedById { get; set; }
    }
}
