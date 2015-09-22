namespace DreamFactory.Model.System.AppGroup
{
    using DreamFactory.Model.System.App;
    using DreamFactory.Model.System.AppAppGroup;
    using DreamFactory.Model.System.User;
    using global::System;
    using global::System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// AppGroupResponse.
    /// </summary>
    public class AppGroupResponse
    {
        /// <summary>
        /// Identifier of this application group.
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Displayable name of this application group.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of this application group.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Date this group was created.
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// User Id of who created this group.
        /// </summary>
        public int? CreatedById { get; set; }

        /// <summary>
        /// Date this group was last modified.
        /// </summary>
        public DateTime? LastModifiedDate { get; set; }

        /// <summary>
        /// User Id of who last modified this group.
        /// </summary>
        public int? LastModifiedById { get; set; }

        /// <summary>
        /// User that created this app group.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.AppGroup.UserCreated)]
        public RelatedUser UserCreated { get; set; }

        /// <summary>
        /// User that last modified this app group.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.AppGroup.UserLastModified)]
        public RelatedUser UserLastModified { get; set; }

        /// <summary>
        /// User that last modified this app group.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.AppGroup.AppToAppGroups)]
        public List<RelatedAppToAppGroup> AppToAppGroups { get; set; }

        /// <summary>
        /// User that last modified this app group.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.AppGroup.AppsInAppToAppGroups)]
        public List<RelatedApp> AppsInAppToAppGroups { get; set; }


    }
}