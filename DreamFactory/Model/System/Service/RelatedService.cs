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
        public int? Id { get; set; }

        /// <summary>
        /// Displayable name of this service.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Name of the service to use in API transactions.
        /// </summary>
        public string ApiName { get; set; }

        /// <summary>
        /// Description of this service.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// True if this service is active for use.
        /// </summary>
        public bool? IsActive { get; set; }

        /// <summary>
        /// One of the supported service types.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// One of the supported enumerated service types.
        /// </summary>
        public int? TypeId { get; set; }

        /// <summary>
        /// They supported storage service type.
        /// </summary>
        public string StorageType { get; set; }

        /// <summary>
        /// One of the supported enumerated storage service types.
        /// </summary>
        public int? StorageTypeId { get; set; }

        /// <summary>
        /// Any credentials data required by the service.
        /// </summary>
        public Dictionary<string, string> Credentials { get; set; }

        /// <summary>
        /// The format of the returned data of the service.
        /// </summary>
        public string NativeFormat { get; set; }

        /// <summary>
        /// The base URL for remote web services.
        /// </summary>
        public string BaseUrl { get; set; }

        /// <summary>
        /// Additional URL parameters required by the service.
        /// </summary>
        public List<KeyValuePair<string, string>> Parameters { get; set; }

        /// <summary>
        /// Additional headers required by the service.
        /// </summary>
        public List<string> Headers { get; set; }

        /// <summary>
        /// Date this service was created.
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// User Id of who created this service.
        /// </summary>
        public int? CreatedById { get; set; }

        /// <summary>
        /// Date this service was last modified.
        /// </summary>
        public DateTime? LastModifiedDate { get; set; }

        /// <summary>
        /// User Id of who last modified this service. 
        /// </summary>
        public int? LastModifiedById { get; set; }
    }
}