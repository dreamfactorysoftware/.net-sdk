// ReSharper disable InconsistentNaming
namespace DreamFactory.Model
{
    /// <summary>
    /// SessionApp.
    /// </summary>
    public class SessionApp
    {
        /// <summary>
        /// Id of the application.
        /// </summary>
        public int? id { get; set; }

        /// <summary>
        /// Displayed name of the application.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Description of the application.
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// Does this application exist on a separate server.
        /// </summary>
        public bool? is_url_external { get; set; }

        /// <summary>
        /// URL at which this app can be accessed.
        /// </summary>
        public string launch_url { get; set; }

        /// <summary>
        /// True if the application requires fullscreen to run.
        /// </summary>
        public bool? requires_fullscreen { get; set; }

        /// <summary>
        /// True allows the fullscreen toggle widget to be displayed.
        /// </summary>
        public bool? allow_fullscreen_toggle { get; set; }

        /// <summary>
        /// Where the fullscreen toggle widget is to be displayed, defaults to top.
        /// </summary>
        public string toggle_location { get; set; }

        /// <summary>
        /// True if this app is set to launch by default at sign in.
        /// </summary>
        public bool? is_default { get; set; }
    }
}
