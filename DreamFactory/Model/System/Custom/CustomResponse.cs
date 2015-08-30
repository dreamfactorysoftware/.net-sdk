namespace DreamFactory.Model.System.Custom
{
    using DreamFactory.Model.System.User;
    using global::System;
    using Newtonsoft.Json;

    /// <summary>
    /// CustomResponse.
    /// </summary>
    public class CustomResponse
    {
        /// <summary>
        /// Name of the created resource.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Value of the created resource.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Date when the resource was created.
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Date when the resource was modified.
        /// </summary>
        public DateTime? LastModifiedDate { get; set; }

        /// <summary>
        /// UserId that created the resource.
        /// </summary>
        public int? CreatedById { get; set; }

        /// <summary>
        /// UserId that modified the resource.
        /// </summary>
        public int? LastModifiedById { get; set; }

        /// <summary>
        /// A single User record that this record potentially belongs to.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.UserCreated)]
        public RelatedUser UserCreated { get; set; }

        /// <summary>
        /// A single User record that this record potentially belongs to.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.UserModified)]
        public RelatedUser UserModified { get; set; }
    }
}
