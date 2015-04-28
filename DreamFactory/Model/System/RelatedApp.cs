// ReSharper disable InconsistentNaming
namespace DreamFactory.Model.System
{
    using global::System;
    using global::System.Collections.Generic;

    /// <summary>
    /// RelatedApp.
    /// </summary>
    public class RelatedApp
    {
        /// <summary>
        /// Identifier of this application.
        /// </summary>
        public int? id { get; set; }

        /// <summary>
        /// Displayable name of this application.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Name of the application to use in API transactions.
        /// </summary>
        public string api_name { get; set; }

        /// <summary>
        /// Description of this application.
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// Is this system application active for use.
        /// </summary>
        public bool? is_active { get; set; }

        /// <summary>
        /// URL for accessing this application.
        /// </summary>
        public string url { get; set; }

        /// <summary>
        /// True when this application is hosted elsewhere, but available in Launchpad.
        /// </summary>
        public bool? is_url_external { get; set; }

        /// <summary>
        /// If hosted and imported, the url of zip or package file where the code originated.
        /// </summary>
        public string import_url { get; set; }

        /// <summary>
        /// If hosted, the storage service identifier.
        /// </summary>
        public string storage_service_id { get; set; }

        /// <summary>
        /// If hosted, the container of the storage service.
        /// </summary>
        public string storage_container { get; set; }

        /// <summary>
        /// True when this app needs to hide launchpad.
        /// </summary>
        public bool? requires_fullscreen { get; set; }

        /// <summary>
        /// True to allow launchpad access via toggle.
        /// </summary>
        public bool? allow_fullscreen_toggle { get; set; }

        /// <summary>
        /// Screen location for toggle placement.
        /// </summary>
        public string toggle_location { get; set; }

        /// <summary>
        /// True when the app relies on a browser plugin.
        /// </summary>
        public bool? requires_plugin { get; set; }

        /// <summary>
        /// Date this application was created.
        /// </summary>
        public DateTime? created_date { get; set; }

        /// <summary>
        /// User Id of who created this application.
        /// </summary>
        public int? created_by_id { get; set; }

        /// <summary>
        /// Date this application was last modified.
        /// </summary>
        public DateTime? last_modified_date { get; set; }

        /// <summary>
        /// User Id of who last modified this application.
        /// </summary>
        public int? last_modified_by_id { get; set; }
    }

    /// <summary>
    /// RelatedApps.
    /// </summary>
    public class RelatedApps
    {
        /// <summary>
        /// Array of records.
        /// </summary>
        public List<RelatedApp> record { get; set; }
    }
}
