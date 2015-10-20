namespace DreamFactory.Model.User
{
    using Newtonsoft.Json;

    /// <summary>
    /// SessionApp.
    /// </summary>
    public class SessionApp
    {
        /// <summary>
        /// Id of the application.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>
        /// Displayed name of the application.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Description of the application.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Does this application exist on a separate server.
        /// </summary>
        [JsonProperty(PropertyName = "is_url_external")]
        public bool? IsUrlExternal { get; set; }

        /// <summary>
        /// URL at which this app can be accessed.
        /// </summary>
        [JsonProperty(PropertyName = "launch_url")]
        public string LaunchUrl { get; set; }

        /// <summary>
        /// True if the application requires full screen to run.
        /// </summary>
        [JsonProperty(PropertyName = "requires_fullscreen")]
        public bool? RequiresFullscreen { get; set; }

        /// <summary>
        /// True allows the full screen toggle widget to be displayed.
        /// </summary>
        [JsonProperty(PropertyName = "allow_fullscreen_toggle")]
        public bool? AllowFullscreenToggle { get; set; }

        /// <summary>
        /// Where the full screen toggle widget is to be displayed, defaults to top.
        /// </summary>
        [JsonProperty(PropertyName = "toggle_location")]
        public string ToggleLocation { get; set; }

        /// <summary>
        /// True if this app is set to launch by default at sign in.
        /// </summary>
        [JsonProperty(PropertyName = "is_default")]
        public bool? IsDefault { get; set; }
    }
}
