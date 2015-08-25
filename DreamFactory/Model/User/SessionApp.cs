namespace DreamFactory.Model.User
{
    /// <summary>
    /// SessionApp.
    /// </summary>
    public class SessionApp
    {
        /// <summary>
        /// Id of the application.
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Displayed name of the application.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of the application.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Does this application exist on a separate server.
        /// </summary>
        public bool? IsUrlExternal { get; set; }

        /// <summary>
        /// URL at which this app can be accessed.
        /// </summary>
        public string LaunchUrl { get; set; }

        /// <summary>
        /// True if the application requires fullscreen to run.
        /// </summary>
        public bool? RequiresFullscreen { get; set; }

        /// <summary>
        /// True allows the fullscreen toggle widget to be displayed.
        /// </summary>
        public bool? AllowFullscreenToggle { get; set; }

        /// <summary>
        /// Where the fullscreen toggle widget is to be displayed, defaults to top.
        /// </summary>
        public string ToggleLocation { get; set; }

        /// <summary>
        /// True if this app is set to launch by default at sign in.
        /// </summary>
        public bool? IsDefault { get; set; }
    }
}
