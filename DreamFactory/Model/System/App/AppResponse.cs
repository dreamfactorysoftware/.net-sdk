namespace DreamFactory.Model.System.App
{
    using DreamFactory.Model.System.AppAppGroup;
    using DreamFactory.Model.System.AppGroup;
    using DreamFactory.Model.System.Lookup;
    using DreamFactory.Model.System.Role;
    using DreamFactory.Model.System.Service;
    using DreamFactory.Model.System.User;
    using DreamFactory.Model.System.UserAppRole;
    using global::System;
    using global::System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// AppResponse.
    /// </summary>
    public class AppResponse
    {
        /// <summary>
        /// Identifier of this application.
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Displayable name of this application.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ApiKey used for this application.
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// Description of this application.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Is this system application active for use.
        /// </summary>
        public bool? IsActive { get; set; }

        /// <summary>
        /// Is this system application active for use.
        /// </summary>
        public int? Type{ get; set; }

        /// <summary>
        /// Path for this application.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// URL for accessing this application.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// If hosted, the storage service identifier.
        /// </summary>
        public string StorageServiceId { get; set; }

        /// <summary>
        /// If hosted, the container of the storage service.
        /// </summary>
        public string StorageContainer { get; set; }

        /// <summary>
        /// True when this app needs to hide launchpad.
        /// </summary>
        public bool? RequiresFullscreen { get; set; }

        /// <summary>
        /// True to allow launchpad access via toggle.
        /// </summary>
        public bool? AllowFullscreenToggle { get; set; }

        /// <summary>
        /// Screen location for toggle placement.
        /// </summary>
        public string ToggleLocation { get; set; }

        /// <summary>
        /// RoleId of the default role assigned to this application.
        /// </summary>
        public int? RoleId { get; set; }

        /// <summary>
        /// A single User record that this record potentially belongs to.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.App.UserCreated)]
        public RelatedUser UserCreated { get; set; }

        /// <summary>
        /// A single User record that this record potentially belongs to.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.App.UserModified)]
        public RelatedUser UserModified { get; set; }

        /// <summary>
        /// A single Role record that this record potentially belongs to.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.App.DefaultRole)]
        public RelatedRole DefaultRole { get; set; }

        /// <summary>
        /// A single Service record that this record potentially belongs to.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.App.StorageService)]
        public RelatedService StorageService { get; set; }

        /// <summary>
        ///  Zero or more AppLookup records that are potentially linked to this record directly.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.App.AppLookups)]
        public List<RelatedLookup> AppLookups { get; set; }

        /// <summary>
        /// Zero or more User records that are potentially linked to this record via the AppLookup table.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.App.UsersInAppLookup)]
        public List<RelatedUser> UsersInAppLookup { get; set; }

        /// <summary>
        /// Zero or more AppToAppGroup records that are potentially linked to this record directly.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.App.Apps)]
        public List<RelatedAppToAppGroup> Apps { get; set; }

        /// <summary>
        /// Zero or more AppGroup records that are potentially linked to this record via the AppToAppGroup table.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.App.AppGroups)]
        public List<RelatedAppGroup> AppGroups { get; set; }

        /// <summary>
        /// Zero or more UserAppRole records that are potentially linked to this record directly.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.App.UserRoles)]
        public List<RelatedUserAppRole> UserRoles { get; set; }

        /// <summary>
        /// Zero or more Role records that are potentially linked to this record via the UserAppRole table.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.App.Roles)]
        public List<RelatedRole> Roles { get; set; }

        /// <summary>
        /// Zero or more User records that are potentially linked to this record via the UserAppRole table.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.App.Users)]
        public List<RelatedUser> Users { get; set; }

        /// <summary>
        /// Date this application was created.
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// User Id of who created this application.
        /// </summary>
        public int? CreatedById { get; set; }

        /// <summary>
        /// Date this application was last modified.
        /// </summary>
        public DateTime? LastModifiedDate { get; set; }

        /// <summary>
        /// User Id of who last modified this application.
        /// </summary>
        public int? LastModifiedById { get; set; }
    }
}
