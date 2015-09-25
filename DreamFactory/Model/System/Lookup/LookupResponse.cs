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
        public int? Id { get; set; }

        /// <summary>
        /// Name for this lookup.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Value of this lookup.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Indicator whether this lookup is private.
        /// </summary>
        public bool? Private { get; set; }

        /// <summary>
        /// Description for this lookup.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Date this lookup was created.
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Date this lookup was last modified.
        /// </summary>
        public DateTime? LastModifiedDate { get; set; }

        /// <summary>
        /// Id of the user that created this lookup.
        /// </summary>
        public int? CreatedById { get; set; }

        /// <summary>
        /// Id of the user that last modified this lookup.
        /// </summary>
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
