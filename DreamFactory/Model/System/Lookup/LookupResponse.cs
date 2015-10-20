namespace DreamFactory.Model.System.Lookup
{
    using DreamFactory.Model.System.Script;
    using DreamFactory.Model.System.User;
    using global::System;
    using Newtonsoft.Json;

    /// <summary>
    /// LookupResponse.
    /// </summary>
    public class LookupResponse
    {
        /// <summary>
        /// Id for this lookup
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>
        /// Name for this lookup.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Value of this lookup.
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }

        /// <summary>
        /// Indicator whether this lookup is private.
        /// </summary>
        [JsonProperty(PropertyName = "private")]
        public bool? Private { get; set; }

        /// <summary>
        /// Description for this lookup.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Date this lookup was created.
        /// </summary>
        [JsonProperty(PropertyName = "created_date")]
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Date this lookup was last modified.
        /// </summary>
        [JsonProperty(PropertyName = "last_modified_date")]
        public DateTime? LastModifiedDate { get; set; }

        /// <summary>
        /// Id of the user that created this lookup.
        /// </summary>
        [JsonProperty(PropertyName = "created_by_id")]
        public int? CreatedById { get; set; }

        /// <summary>
        /// Id of the user that last modified this lookup.
        /// </summary>
        [JsonProperty(PropertyName = "last_modified_by_id")]
        public int? LastModifiedById { get; set; }

        /// <summary>
        /// User that created this lookup.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.Lookup.UserCreated)]
        public RelatedUser UserCreated { get; set; }

        /// <summary>
        /// User that last modified this lookup.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.Lookup.UserLastModified)]
        public RelatedUser UserLastModified { get; set; }
    }
}
