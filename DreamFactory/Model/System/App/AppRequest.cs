namespace DreamFactory.Model.System.App
{
    using Newtonsoft.Json;

    /// <summary>
    /// AppRequest.
    /// </summary>
    public class AppRequest : IRecord
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
        /// RoleId of the default role assigned to this application.
        /// </summary>
        [JsonProperty(PropertyName = "role_id")]
        public int? RoleId { get; set; }
    }
}
