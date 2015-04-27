// ReSharper disable InconsistentNaming
namespace DreamFactory.Model.System
{
    using global::System.Collections.Generic;

    /// <summary>
    /// AppResponse.
    /// </summary>
    public class AppRequest
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
        /// Related roles by Role.default_app_id.
        /// </summary>
        public List<RelatedRoles> roles_default_app { get; set; }

        /// <summary>
        /// Related users by User.default_app_id.
        /// </summary>
        public List<RelatedUsers> users_default_app { get; set; }

        /// <summary>
        /// Related groups by app to group assignment.
        /// </summary>
        public List<RelatedAppGroups> app_groups { get; set; }

        /// <summary>
        /// Related roles by app to role assignment.
        /// </summary>
        public List<RelatedRoles> roles { get; set; }

        /// <summary>
        /// Related services by app to service assignment.
        /// </summary>
        public List<RelatedServices> services { get; set; }
    }
}
