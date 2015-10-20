namespace DreamFactory.Model.System.Cors
{
    using DreamFactory.Model.System.User;
    using Newtonsoft.Json;
    using global::System;

    /// <summary>
    /// CORS response.
    /// </summary>
    public class CorsResponse
    {
        /// <summary>
        /// Identifier of the record.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>
        /// Path of the CORS.
        /// </summary>
        [JsonProperty(PropertyName = "path")]
        public string Path { get; set; }

        /// <summary>
        /// Origin of the CORS.
        /// </summary>
        [JsonProperty(PropertyName = "origin")]
        public string Origin { get; set; }

        /// <summary>
        /// Header of the CORS.
        /// </summary>
        [JsonProperty(PropertyName = "header")]
        public string Header { get; set; }

        /// <summary>
        /// HTTP methods allowed.
        /// </summary>
        [JsonProperty(PropertyName = "method")]
        public int? Method { get; set; }

        /// <summary>
        /// Max age.
        /// </summary>
        [JsonProperty(PropertyName = "max_age")]
        public int? MaxAge { get; set; }

        /// <summary>
        /// Indicates whether it is enabled.
        /// </summary>
        [JsonProperty(PropertyName = "enabled")]
        public bool Enabled { get; set; }

        /// <summary>
        /// Date this CORS record was created.
        /// </summary>
        [JsonProperty(PropertyName = "created_date")]
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// User Id of who created this CORS record.
        /// </summary>
        [JsonProperty(PropertyName = "created_by_id")]
        public int? CreatedById { get; set; }

        /// <summary>
        /// Date this CORS record was last modified.
        /// </summary>
        [JsonProperty(PropertyName = "last_modified_date")]
        public DateTime? LastModifiedDate { get; set; }

        /// <summary>
        /// User Id of who last modified this CORS record.
        /// </summary>
        [JsonProperty(PropertyName = "last_modified_by_id")]
        public int? LastModifiedById { get; set; }

        /// <summary>
        /// User that created this role.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.Cors.UserCreated)]
        public RelatedUser UserCreated { get; set; }

        /// <summary>
        /// User that last modified this role.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.Cors.UserLastModified)]
        public RelatedUser UserLastModified { get; set; }
    }
}
