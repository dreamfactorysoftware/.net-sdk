namespace DreamFactory.Model.System.User
{
    using DreamFactory.Model.System.App;
    using DreamFactory.Model.System.AppGroup;
    using DreamFactory.Model.System.Email;
    using DreamFactory.Model.System.Event;
    using DreamFactory.Model.System.Lookup;
    using DreamFactory.Model.System.Role;
    using DreamFactory.Model.System.RoleServiceAccess;
    using DreamFactory.Model.System.Script;
    using DreamFactory.Model.System.Service;
    using DreamFactory.Model.System.Setting;
    using DreamFactory.Model.System.UserAppRole;
    using global::System;
    using global::System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// UserResponse.
    /// </summary>
    public class UserResponse
    {
        /// <summary>
        /// Identifier of this user.
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Displayable name of this user.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The first name for this user.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The last name for this user.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Date this user last logged in.
        /// </summary>
        public DateTime? LastLoginDate { get; set; }

        /// <summary>
        /// The email address required for this user.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The set-able, but never readable, password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// True if this user is system admin.
        /// </summary>
        public bool? IsSysAdmin { get; set; }

        /// <summary>
        /// True if this user is active for use.
        /// </summary>
        public bool? IsActive { get; set; }

        /// <summary>
        /// Phone number for this user.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Security question for this user.
        /// </summary>
        public string SecurityQuestion { get; set; }

        /// <summary>
        /// Security answer for this user.
        /// </summary>
        public string SecurityAnswer { get; set; }

        /// <summary>
        /// Confirm code for this user.
        /// </summary>
        public string ConfirmCode { get; set; }

        /// <summary>
        /// The id of the default launched app for this user.
        /// </summary>
        public int DefaultAppId { get; set; }

        /// <summary>
        /// Remember token for this user.
        /// </summary>
        public string RememberToken { get; set; }

        /// <summary>
        /// Adldap for this user.
        /// </summary>
        public string Adldap { get; set; }

        /// <summary>
        /// OAuth provider for this user.
        /// </summary>
        public string OauthProvider { get; set; }

        /// <summary>
        /// Date this user was created.
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// User Id of who created this user.
        /// </summary>
        public int? CreatedById { get; set; }

        /// <summary>
        /// Date this user was last modified.
        /// </summary>
        public DateTime? LastModifiedDate { get; set; }

        /// <summary>
        /// User Id of who last modified this user.
        /// </summary>
        public int? LastModifiedById { get; set; }

        /// <summary>
        /// Apps created by user.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.User.AppsCreated)]
        public List<RelatedApp> AppsCreated { get; set; }

        /// <summary>
        /// Roles related to user via apps.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.User.RolesInApps)]
        public List<RelatedRole> RolesInApps { get; set; }

        /// <summary>
        /// Services related to user via apps.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.User.ServicesInApps)]
        public List<RelatedService> ServicesInApps { get; set; }

        /// <summary>
        /// Apps last modified by user.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.User.AppsLastModified)]
        public List<RelatedApp> AppsLastModified { get; set; }

        /// <summary>
        /// App groups created by user.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.User.AppGroupsCreated)]
        public List<RelatedAppGroup> AppGroupsCreated { get; set; }

        /// <summary>
        /// App groups last modified by user.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.User.AppGroupsLastModified)]
        public List<RelatedAppGroup> AppGroupsLastModified { get; set; }

        /// <summary>
        /// App lookups created by user.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.User.AppLookupsCreated)]
        public List<RelatedLookup> AppLookupsCreated { get; set; }

        /// <summary>
        /// Apps related to user via app lookups.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.User.AppsInAppLookups)]
        public List<RelatedApp> AppsInAppLookups { get; set; }

        /// <summary>
        /// App lookups last modified by user.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.User.AppLookupsLastModified)]
        public List<RelatedLookup> AppLookupsLastModified { get; set; }

        /// <summary>
        /// CORS configs created by user.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.User.CorsConfigsCreated)]
        public object CorsConfigsCreated { get; set; }

        /// <summary>
        /// CORS configs last modified by user.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.User.CorsConfigsLastModified)]
        public object CorsConfigsLastModified { get; set; }

        /// <summary>
        /// Db field extras created by user.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.User.DbFieldExtrasCreated)]
        public object DbFieldExtrasCreated { get; set; }

        /// <summary>
        /// Services related to user via db field extras.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.User.ServicesInDbFieldExtras)]
        public List<RelatedService> ServicesInDbFieldExtras { get; set; }

        /// <summary>
        /// Db field extras last modified by user.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.User.DbFieldExtrasLastModified)]
        public object DbFieldExtrasLastModified { get; set; }

        /// <summary>
        /// Db table extras created by user.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.User.DbTableExtrasCreated)]
        public object DbTableExtrasCreated { get; set; }

        /// <summary>
        /// Services related to user via db table extras.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.User.ServicesInDbTableExtras)]
        public List<RelatedService> ServicesInDbTableExtras { get; set; }

        /// <summary>
        /// Db table extras last modified by user.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.User.DbTableExtrasLastModified)]
        public object DbTableExtrasLastModified { get; set; }

        /// <summary>
        /// Email templates created by user.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.User.EmailTemplatesCreated)]
        public List<RelatedEmailTemplate> EmailTemplatesCreated { get; set; }

        /// <summary>
        /// Email templates last modified by user.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.User.EmailTemplatesLastModified)]
        public List<RelatedEmailTemplate> EmailTemplatesLastModified { get; set; }

        /// <summary>
        /// Event scripts created by user.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.User.EventScriptsCreated)]
        public List<RelatedEventScript> EventScriptsCreated { get; set; }

        /// <summary>
        /// Script types related to user via event scripts.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.User.ScriptTypesInEventScripts)]
        public List<RelatedScriptType> ScriptTypesInEventScripts { get; set; }

        /// <summary>
        /// Event scripts last modified by user.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.User.EventScriptsLastModified)]
        public List<RelatedEventScript> EventScriptsLastModified { get; set; }

        /// <summary>
        /// Event subscribers created by user.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.User.EventSubscribersCreated)]
        public List<RelatedEventSubscriber> EventSubscribersCreated { get; set; }

        /// <summary>
        /// Event subscribers last modified by user.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.User.EventSubscribersLastModified)]
        public List<RelatedEventSubscriber> EventSubscribersLastModified { get; set; }

        /// <summary>
        /// Roles created by user.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.User.RolesCreated)]
        public List<RelatedRole> RolesCreated { get; set; }

        /// <summary>
        /// Roles last modified by user.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.User.RolesLastModified)]
        public List<RelatedRole> RolesLastModified { get; set; }

        /// <summary>
        /// Role lookups created by user.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.User.RoleLookupsCreated)]
        public List<RelatedLookup> RoleLookupsCreated { get; set; }

        /// <summary>
        /// Roles related to user via role lookups.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.User.RolesInRoleLookups)]
        public List<RelatedRole> RolesInRoleLookups { get; set; }

        /// <summary>
        /// Role lookups last modified by user.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.User.RoleLookupsLastModified)]
        public List<RelatedLookup> RoleLookupsLastModified { get; set; }

        /// <summary>
        /// Role service accesses created by user.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.User.RoleServiceAccessesCreated)]
        public List<RelatedRoleServiceAccess> RoleServiceAccessesCreated { get; set; }

        /// <summary>
        /// Roles related to user via role service accesses.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.User.RolesInRoleServiceAccesses)]
        public List<RelatedRole> RolesInRoleServiceAccesses { get; set; }

        /// <summary>
        /// Services related to user via role service accesses.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.User.ServicesInRoleServiceAccesses)]
        public List<RelatedRole> ServicesInRoleServiceAccesses { get; set; }

        /// <summary>
        /// Role service accesses last modified by user.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.User.RoleServiceAccessesLastModified)]
        public List<RelatedRoleServiceAccess> RoleServiceAccessesLastModified { get; set; }

        /// <summary>
        /// Services created by user.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.User.ServicesCreated)]
        public List<RelatedService> ServicesCreated { get; set; }

        /// <summary>
        /// Service types related to user via services.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.User.ServiceTypesInServices)]
        public List<RelatedServiceType> ServiceTypesInServices { get; set; }

        /// <summary>
        /// Services last modified by user.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.User.ServicesLastModified)]
        public List<RelatedService> ServicesLastModified { get; set; }

        /// <summary>
        /// System configs created by user.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.User.SystemConfigsCreated)]
        public object SystemConfigsCreated { get; set; }

        /// <summary>
        /// System configs last modified by user.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.User.SystemConfigsLastModified)]
        public object SystemConfigsLastModified { get; set; }

        /// <summary>
        /// System customs created by user.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.User.SystemCustomsCreated)]
        public object SystemCustomsCreated { get; set; }

        /// <summary>
        /// System customs last modified by user.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.User.SystemCustomsLastModified)]
        public object SystemCustomsLastModified { get; set; }

        /// <summary>
        /// System lookups created by user.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.User.SystemLookupsCreated)]
        public List<RelatedLookup> SystemLookupsCreated { get; set; }

        /// <summary>
        /// System lookups last modified by user.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.User.SystemLookupsLastModified)]
        public List<RelatedLookup> SystemLookupsLastModified { get; set; }

        /// <summary>
        /// System settings created by user.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.User.SystemSettingsCreated)]
        public List<RelatedSetting> SystemSettingsCreated { get; set; }

        /// <summary>
        /// System settings last modified by user.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.User.SystemSettingsLastModified)]
        public List<RelatedSetting> SystemSettingsLastModified { get; set; }

        /// <summary>
        /// Token map linked to user.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.User.TokenMap)]
        public object TokenMap { get; set; }

        /// <summary>
        /// Users created by user.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.User.UsersCreated)]
        public List<RelatedUser> UsersCreated { get; set; }

        /// <summary>
        /// Users last modified by user.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.User.UsersLastModified)]
        public List<RelatedUser> UsersLastModified { get; set; }

        /// <summary>
        /// User customs created by user.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.User.UserCustomsCreated)]
        public object UserCustomsCreated { get; set; }

        /// <summary>
        /// User customs last modified by user.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.User.UserCustomsLastModified)]
        public object UserCustomsLastModified { get; set; }

        /// <summary>
        /// User customs linked to user.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.User.UserCustoms)]
        public object UserCustoms { get; set; }

        /// <summary>
        /// User lookups created by user.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.User.UserLookupsCreated)]
        public List<RelatedLookup> UserLookupsCreated { get; set; }

        /// <summary>
        /// User lookups last modified by user.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.User.UserLookupsLastModified)]
        public List<RelatedLookup> UserLookupsLastModified { get; set; }

        /// <summary>
        /// User lookups linked to user.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.User.UserLookups)]
        public List<RelatedLookup> UserLookups { get; set; }

        /// <summary>
        /// User app roles linked to user.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.User.UserAppRoles)]
        public List<RelatedUserAppRole> UserAppRoles { get; set; }

        /// <summary>
        /// Apps related to user via user app roles.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.User.AppsInUserAppRoles)]
        public List<RelatedApp> AppsInUserAppRoles { get; set; }

        /// <summary>
        /// Roles related to user via user app roles.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.User.RolesInUserAppRoles)]
        public List<RelatedRole> RolesInUserAppRoles { get; set; }
    }
}
