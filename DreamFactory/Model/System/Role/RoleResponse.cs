namespace DreamFactory.Model.System.Role
{
    using DreamFactory.Model.System.App;
    using DreamFactory.Model.System.Lookup;
    using DreamFactory.Model.System.RoleServiceAccess;
    using DreamFactory.Model.System.Service;
    using DreamFactory.Model.System.User;
    using DreamFactory.Model.System.UserAppRole;
    using global::System;
    using global::System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// RoleResponse.
    /// </summary>
    public class RoleResponse
    {
        /// <summary>
        /// Identifier of this role.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>
        /// Displayable name of this role.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Description of this role.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Is this role active for use.
        /// </summary>
        [JsonProperty(PropertyName = "is_active")]
        public bool? IsActive { get; set; }

        /// <summary>
        /// Date this role was created.
        /// </summary>
        [JsonProperty(PropertyName = "created_date")]
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// User Id of who created this role.
        /// </summary>
        [JsonProperty(PropertyName = "created_by_id")]
        public int? CreatedById { get; set; }

        /// <summary>
        /// Date this role was last modified.
        /// </summary>
        [JsonProperty(PropertyName = "last_modified_date")]
        public DateTime? LastModifiedDate { get; set; }

        /// <summary>
        /// User Id of who last modified this role.
        /// </summary>
        [JsonProperty(PropertyName = "last_modified_by_id")]
        public int? LastModifiedById { get; set; }

        /// <summary>
        /// Apps linked to this role.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.Role.Apps)]
        public List<RelatedApp> Apps { get; set; }

        /// <summary>
        /// Users linked to this role via apps.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.Role.UsersInApps)]
        public List<RelatedUser> UsersInApps { get; set; }

        /// <summary>
        /// Services linked to this role via apps.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.Role.ServicesInApps)]
        public List<RelatedService> ServicesInApps { get; set; }

        /// <summary>
        /// LDAP config linked to this role.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.Role.LdapConfig)]
        public object LdapConfig { get; set; }

        /// <summary>
        /// Services linked to this role via LDAP config.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.Role.ServicesInLdapConfig)]
        public List<RelatedService> ServicesInLdapConfig { get; set; }

        /// <summary>
        /// OAuth config linked to this role.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.Role.OAuthConfig)]
        public object OAuthConfig { get; set; }

        /// <summary>
        /// Services linked to this role via OAuth config.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.Role.ServicesInOAuthConfig)]
        public List<RelatedService> ServicesInOAuthConfig { get; set; }

        /// <summary>
        /// User that created this role.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.Role.UserCreated)]
        public RelatedUser UserCreated { get; set; }

        /// <summary>
        /// User that last modified this role.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.Role.UserLastModified)]
        public RelatedUser UserLastModified { get; set; }

        /// <summary>
        /// Role lookups linked to this role.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.Role.RoleLookups)]
        public List<RelatedLookup> RoleLookups { get; set; }

        /// <summary>
        /// Users linked to this role via role lookup.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.Role.UsersInRoleLookups)]
        public List<RelatedUser> UsersInRoleLookups { get; set; }

        /// <summary>
        /// Role service accesses linked to this role.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.Role.RoleServiceAccesses)]
        public List<RelatedRoleServiceAccess> RoleServiceAccesses { get; set; }

        /// <summary>
        /// Users linked to this role via role service access.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.Role.UsersInRoleServiceAccesses)]
        public List<RelatedUser> UsersInRoleServiceAccesses { get; set; }

        /// <summary>
        /// Services linked to this role via role service access.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.Role.ServicesInRoleServiceAccesses)]
        public List<RelatedService> ServicesInRoleServiceAccesses { get; set; }

        /// <summary>
        /// User app roles linked to this role.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.Role.UserAppRoles)]
        public List<RelatedUserAppRole> UserAppRoles { get; set; }

        /// <summary>
        /// Apps linked to this role via user app roles.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.Role.AppsInUserAppRoles)]
        public List<RelatedApp> AppsInUserAppRoles { get; set; }

        /// <summary>
        /// Users linked to this role via user app roles.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.Role.UsersInUserAppRoles)]
        public List<RelatedUser> UsersInUserAppRoles { get; set; }
    }
}
