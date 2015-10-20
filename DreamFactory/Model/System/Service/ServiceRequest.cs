namespace DreamFactory.Model.System.Service
{
    using global::System;
    using Newtonsoft.Json;

    /// <summary>
    /// ServiceResponse.
    /// </summary>
    public class ServiceRequest : IRecord
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
        /// Label of this service.
        /// </summary>
        [JsonProperty(PropertyName = "label")]
        public string Label { get; set; }

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
    }
}