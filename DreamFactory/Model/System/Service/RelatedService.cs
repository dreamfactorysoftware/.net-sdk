// ReSharper disable InconsistentNaming
namespace DreamFactory.Model.System.Service
{
    using global::System;
    using global::System.Collections.Generic;

    /// <summary>
    /// RelatedService.
    /// </summary>
    public class RelatedService
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
        public string credentials { get; set; }

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
        public string parameters { get; set; }

        /// <summary>
        /// Additional headers required by the service.
        /// </summary>
        public string headers { get; set; }

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

    /// <summary>
    /// RelatedServices.
    /// </summary>
    public class RelatedServices
    {
        /// <summary>
        /// Array of system user records.
        /// </summary>
        public List<RelatedService> record { get; set; }
    }
}