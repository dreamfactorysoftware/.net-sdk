namespace DreamFactory.Model.System.App
{
    using DreamFactory.Model.System.AppGroup;
    using DreamFactory.Model.System.Role;
    using DreamFactory.Model.System.Service;
    using DreamFactory.Model.System.User;
    using global::System.Collections.Generic;

    /// <summary>
    /// AppRequest.
    /// </summary>
    public class AppRequest : IRecord
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
        /// RoleId of the default role assigned to this application.
        /// </summary>
        public int? RoleId { get; set; }
    }
}
