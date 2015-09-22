namespace DreamFactory.Model.System.App
{
    using global::System;

    /// <summary>
    /// RelatedApp.
    /// </summary>
    public class RelatedApp
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
