namespace DreamFactory.Model.System.Lookup
{
    using global::System;
    using Newtonsoft.Json;

    /// <summary>
    /// RelatedLookup.
    /// </summary>
    public class RelatedLookup
    {
        /// <summary>
        /// Id of this lookup.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>
        /// Name of this lookup.
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
        /// Description of this lookup.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Id of the user that created this lookup.
        /// </summary>
        [JsonProperty(PropertyName = "created_by_id")]
        public int? CreatedById { get; set; }

        /// <summary>
        /// Id of the user that last modified this lookup.
        /// </summary>
        [JsonProperty(PropertyName = "modified_by_id")]
        public int? ModifiedById { get; set; }

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
    }
}
