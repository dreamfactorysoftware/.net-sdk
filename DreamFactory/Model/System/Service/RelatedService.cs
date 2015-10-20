namespace DreamFactory.Model.System.Service
{
    using global::System;
    using global::System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// RelatedService.
    /// </summary>
    public class RelatedService
    {
        /// <summary>
        /// Identifier of this service.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>
        /// Displayable name of this service.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Name of the service to use in API transactions.
        /// </summary>
        [JsonProperty(PropertyName = "api_name")]
        public string ApiName { get; set; }

        /// <summary>
        /// Description of this service.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// True if this service is active for use.
        /// </summary>
        [JsonProperty(PropertyName = "is_active")]
        public bool? IsActive { get; set; }

        /// <summary>
        /// One of the supported service types.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// One of the supported enumerated service types.
        /// </summary>
        [JsonProperty(PropertyName = "type_id")]
        public int? TypeId { get; set; }

        /// <summary>
        /// They supported storage service type.
        /// </summary>
        [JsonProperty(PropertyName = "storage_type")]
        public string StorageType { get; set; }

        /// <summary>
        /// One of the supported enumerated storage service types.
        /// </summary>
        [JsonProperty(PropertyName = "storage_type_id")]
        public int? StorageTypeId { get; set; }

        /// <summary>
        /// Any credentials data required by the service.
        /// </summary>
        [JsonProperty(PropertyName = "credentials")]
        public Dictionary<string, string> Credentials { get; set; }

        /// <summary>
        /// The format of the returned data of the service.
        /// </summary>
        [JsonProperty(PropertyName = "native_format")]
        public string NativeFormat { get; set; }

        /// <summary>
        /// The base URL for remote web services.
        /// </summary>
        [JsonProperty(PropertyName = "base_url")]
        public string BaseUrl { get; set; }

        /// <summary>
        /// Additional URL parameters required by the service.
        /// </summary>
        [JsonProperty(PropertyName = "parameters")]
        public List<KeyValuePair<string, string>> Parameters { get; set; }

        /// <summary>
        /// Additional headers required by the service.
        /// </summary>
        [JsonProperty(PropertyName = "headers")]
        public List<string> Headers { get; set; }

        /// <summary>
        /// Date this service was created.
        /// </summary>
        [JsonProperty(PropertyName = "created_date")]
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// User Id of who created this service.
        /// </summary>
        [JsonProperty(PropertyName = "created_by_id")]
        public int? CreatedById { get; set; }

        /// <summary>
        /// Date this service was last modified.
        /// </summary>
        [JsonProperty(PropertyName = "last_modified_date")]
        public DateTime? LastModifiedDate { get; set; }

        /// <summary>
        /// User Id of who last modified this service. 
        /// </summary>
        [JsonProperty(PropertyName = "last_modified_by_id")]
        public int? LastModifiedById { get; set; }
    }
}