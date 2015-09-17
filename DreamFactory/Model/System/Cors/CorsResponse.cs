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
        public int? Id { get; set; }

        /// <summary>
        /// Path of the CORS.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Origin of the CORS.
        /// </summary>
        public string Origin { get; set; }

        /// <summary>
        /// Header of the CORS.
        /// </summary>
        public string Header { get; set; }

        /// <summary>
        /// HTTP methods allowed.
        /// </summary>
        public int? Method { get; set; }

        /// <summary>
        /// Max age.
        /// </summary>
        public int? MaxAge { get; set; }

        /// <summary>
        /// Indicates whether it is enabled.
        /// </summary>
        public bool Enabled { get; set; }


        /// <summary>
        /// Date this CORS record was created.
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// User Id of who created this CORS record.
        /// </summary>
        public int? CreatedById { get; set; }

        /// <summary>
        /// Date this CORS record was last modified.
        /// </summary>
        public DateTime? LastModifiedDate { get; set; }

        /// <summary>
        /// User Id of who last modified this CORS record.
        /// </summary>
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
