// ReSharper disable InconsistentNaming
namespace DreamFactory.Model.System.Service
{
    using DreamFactory.Model.System.App;
    using DreamFactory.Model.System.Role;
    using global::System;
    using global::System.Collections.Generic;

    /// <summary>
    /// ServiceResponse.
    /// </summary>
    public class ServiceResponse
    {
        /// <summary>
        /// Identifier of this service.
        /// </summary>
        public int? id { get; set; }

        /// <summary>
        /// Displayable name of this service.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Name of the service to use in API transactions.
        /// </summary>
        public string api_name { get; set; }

        /// <summary>
        /// Description of this service.
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// True if this service is active for use.
        /// </summary>
        public bool? is_active { get; set; }

        /// <summary>
        /// One of the supported service types.
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// One of the supported enumerated service types.
        /// </summary>
        public int? type_id { get; set; }

        /// <summary>
        /// They supported storage service type.
        /// </summary>
        public string storage_type { get; set; }

        /// <summary>
        /// One of the supported enumerated storage service types.
        /// </summary>
        public int? storage_type_id { get; set; }

        /// <summary>
        /// Any credentials data required by the service.
        /// </summary>
        public Dictionary<string, object> credentials { get; set; }

        /// <summary>
        /// The format of the returned data of the service.
        /// </summary>
        public string native_format { get; set; }

        /// <summary>
        /// The base URL for remote web services.
        /// </summary>
        public string base_url { get; set; }

        /// <summary>
        /// Additional URL parameters required by the service.
        /// </summary>
        public List<KeyValuePair<string, object>> parameters { get; set; }

        /// <summary>
        /// Additional headers required by the service.
        /// </summary>
        public List<string> headers { get; set; }

        /// <summary>
        /// Related apps by app to service assignment.
        /// </summary>
        public List<RelatedApp> apps { get; set; }

        /// <summary>
        /// Related roles by service to role assignment.
        /// </summary>
        public List<RelatedRole> roles { get; set; }

        /// <summary>
        /// Date this service was created.
        /// </summary>
        public DateTime? created_date { get; set; }

        /// <summary>
        /// User Id of who created this service.
        /// </summary>
        public int? created_by_id { get; set; }

        /// <summary>
        /// Date this service was last modified.
        /// </summary>
        public DateTime? last_modified_date { get; set; }

        /// <summary>
        /// User Id of who last modified this service. 
        /// </summary>
        public int? last_modified_by_id { get; set; }
    }
}