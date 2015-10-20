namespace DreamFactory.Model.System.App
{
    using global::System;
    using Newtonsoft.Json;

    /// <summary>
    /// RelatedApp.
    /// </summary>
    public class RelatedApp
    {
        /// <summary>
        /// Identifier of this application.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>
        /// Displayable name of this application.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Name of the application to use in API transactions.
        /// </summary>
        [JsonProperty(PropertyName = "api_name")]
        public string ApiName { get; set; }

        /// <summary>
        /// Description of this application.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Is this system application active for use.
        /// </summary>
        [JsonProperty(PropertyName = "is_active")]
        public bool? IsActive { get; set; }

        /// <summary>
        /// URL for accessing this application.
        /// </summary>
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        /// <summary>
        /// True when this application is hosted elsewhere, but available in Launchpad.
        /// </summary>
        [JsonProperty(PropertyName = "is_url_external")]
        public bool? IsUrlExternal { get; set; }

        /// <summary>
        /// If hosted and imported, the url of zip or package file where the code originated.
        /// </summary>
        [JsonProperty(PropertyName = "import_url")]
        public string ImportUrl { get; set; }

        /// <summary>
        /// If hosted, the storage service identifier.
        /// </summary>
        [JsonProperty(PropertyName = "storage_service_id")]
        public string StorageServiceId { get; set; }

        /// <summary>
        /// If hosted, the container of the storage service.
        /// </summary>
        [JsonProperty(PropertyName = "storage_container")]
        public string StorageContainer { get; set; }

        /// <summary>
        /// True when this app needs to hide launchpad.
        /// </summary>
        [JsonProperty(PropertyName = "requires_fullscreen")]
        public bool? RequiresFullscreen { get; set; }

        /// <summary>
        /// True to allow launchpad access via toggle.
        /// </summary>
        [JsonProperty(PropertyName = "allow_fullscreen_toggle")]
        public bool? AllowFullscreenToggle { get; set; }

        /// <summary>
        /// Screen location for toggle placement.
        /// </summary>
        [JsonProperty(PropertyName = "toggle_location")]
        public string ToggleLocation { get; set; }

        /// <summary>
        /// True when the app relies on a browser plugin.
        /// </summary>
        [JsonProperty(PropertyName = "requires_plugin")]
        public bool? RequiresPlugin { get; set; }

        /// <summary>
        /// Date this application was created.
        /// </summary>
        [JsonProperty(PropertyName = "created_date")]
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// User Id of who created this application.
        /// </summary>
        [JsonProperty(PropertyName = "created_by_id")]
        public int? CreatedById { get; set; }

        /// <summary>
        /// Date this application was last modified.
        /// </summary>
        [JsonProperty(PropertyName = "last_modified_date")]
        public DateTime? LastModifiedDate { get; set; }

        /// <summary>
        /// User Id of who last modified this application.
        /// </summary>
        [JsonProperty(PropertyName = "last_modified_by_id")]
        public int? LastModifiedById { get; set; }
    }
}
