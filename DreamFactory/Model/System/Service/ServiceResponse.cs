namespace DreamFactory.Model.System.Service
{
    using DreamFactory.Model.System.App;
    using DreamFactory.Model.System.Role;
    using DreamFactory.Model.System.RoleServiceAccess;
    using DreamFactory.Model.System.Script;
    using DreamFactory.Model.System.User;
    using global::System;
    using global::System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// ServiceResponse.
    /// </summary>
    public class ServiceResponse
    {
        /// <summary>
        /// Identifier of this service.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>
        /// Displayable name of this service.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Label of this service.
        /// </summary>
        [JsonProperty(PropertyName = "label")]
        public string Label { get; set; }

        /// <summary>
        /// Description of this service.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// True if this service is active for use.
        /// </summary>
        [JsonProperty(PropertyName = "is_active")]
        public bool? IsActive { get; set; }

        /// <summary>
        /// One of the supported service types.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Indicates whether this service is mutable.
        /// </summary>
        [JsonProperty(PropertyName = "mutable")]
        public bool? Mutable { get; set; }

        /// <summary>
        /// Indicates whether this service can be deleted.
        /// </summary>
        [JsonProperty(PropertyName = "deletable")]
        public bool? Deletable { get; set; }

        /// <summary>
        /// Date this service was created.
        /// </summary>
        [JsonProperty(PropertyName = "created_date")]
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Date this service was last modified.
        /// </summary>
        [JsonProperty(PropertyName = "last_modified_date")]
        public DateTime? LastModifiedDate { get; set; }

        /// <summary>
        /// Id of the user that created this service.
        /// </summary>
        [JsonProperty(PropertyName = "created_by_id")]
        public int? CreatedById { get; set; }

        /// <summary>
        /// Id of the user that last modified this service.
        /// </summary>
        [JsonProperty(PropertyName = "last_modified_by_id")]
        public int? LastModifiedById { get; set; }

        /// <summary>
        /// Apps using this service.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.Service.Apps)]
        public List<RelatedApp> Apps { get; set; }

        /// <summary>
        /// Users in apps using this service.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.Service.UsersInApps)]
        public List<RelatedUser> UsersInApps { get; set; }

        /// <summary>
        /// Roles in apps using this service.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.Service.RolesInApps)]
        public List<RelatedRole> RolesInApps { get; set; }

        /// <summary>
        /// AWS config for this service.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.Service.AwsConfig)]
        public object AwsConfig { get; set; }

        /// <summary>
        /// Azure config for this service.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.Service.AzureConfig)]
        public object AzureConfig { get; set; }

        /// <summary>
        /// Couch db config for this service.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.Service.CouchDbConfig)]
        public object CouchDbConfig { get; set; }

        /// <summary>
        /// Db field extras for this service.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.Service.DbFieldExtras)]
        public object DbFieldExtras { get; set; }

        /// <summary>
        /// Users in db field extras for this service.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.Service.UsersInDbFieldExtras)]
        public List<RelatedUser> UsersInDbFieldExtras { get; set; }

        /// <summary>
        /// Db table extras for this service.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.Service.DbTableExtras)]
        public object DbTableExtras { get; set; }

        /// <summary>
        /// Users in db table extras for this service.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.Service.UsersInDbTableExtras)]
        public List<RelatedUser> UsersInDbTableExtras { get; set; }

        /// <summary>
        /// Email parameters config for this service.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.Service.EmailParametersConfig)]
        public object EmailParametersConfig { get; set; }

        /// <summary>
        /// File service config for this service.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.Service.FileServiceConfig)]
        public object FileServiceConfig { get; set; }

        /// <summary>
        /// Ldap config for this service.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.Service.LdapConfig)]
        public object LdapConfig { get; set; }

        /// <summary>
        /// Roles in ldap config for this service.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.Service.RolesInLdapConfig)]
        public List<RelatedRole> RolesInLdapConfig { get; set; }

        /// <summary>
        /// Mongo db config for this service.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.Service.MongoDbConfig)]
        public object MongoDbConfig { get; set; }

        /// <summary>
        /// OAuth config for this service.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.Service.OAuthConfig)]
        public object OAuthConfig { get; set; }

        /// <summary>
        /// Roles in OAuth config for this service.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.Service.RolesInOAuthConfig)]
        public List<RelatedRole> RolesInOAuthConfig { get; set; }

        /// <summary>
        /// Rackspace config for this service.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.Service.RackspaceConfig)]
        public object RackspaceConfig { get; set; }

        /// <summary>
        /// Role service accesses for this service.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.Service.RoleServiceAccesses)]
        public List<RelatedRoleServiceAccess> RoleServiceAccesses { get; set; }

        /// <summary>
        /// Users in role service accesses for this service.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.Service.UsersInRoleServiceAccesses)]
        public List<RelatedUser> UsersInRoleServiceAccesses { get; set; }

        /// <summary>
        /// Roles in role service accesses for this service.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.Service.RolesInRoleServiceAccesses)]
        public List<RelatedRole> RolesInRoleServiceAccesses { get; set; }

        /// <summary>
        /// RWS config for this service.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.Service.RwsConfig)]
        public object RwsConfig { get; set; }

        /// <summary>
        /// Headers for RWS config for this service.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.Service.HeadersInRwsConfig)]
        public object HeadersInRwsConfig { get; set; }

        /// <summary>
        /// Parameters in RWS config for this service.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.Service.ParametersInRwsConfig)]
        public object ParametersInRwsConfig { get; set; }

        /// <summary>
        /// Salesforce db config for this service.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.Service.SalesforceDbConfig)]
        public object SalesforceDbConfig { get; set; }

        /// <summary>
        /// Script configs for this service.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.Service.ScriptConfigs)]
        public object ScriptConfigs { get; set; }

        /// <summary>
        /// Script types in script configs for this service.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.Service.ScriptTypesInScriptConfigs)]
        public List<RelatedScriptType> ScriptTypesInScriptConfigs { get; set; }

        /// <summary>
        /// User that created this service.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.Service.UserCreated)]
        public RelatedUser UserCreated { get; set; }

        /// <summary>
        /// User that last modified this service.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.Service.UserLastModified)]
        public RelatedUser UserLastModified { get; set; }

        /// <summary>
        /// Service type of this service.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.Service.ServiceType)]
        public RelatedServiceType ServiceType { get; set; }

        /// <summary>
        /// Service cache config for this service.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.Service.ServiceCacheConfig)]
        public object ServiceCacheConfig { get; set; }

        /// <summary>
        /// Service docs for this service.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.Service.ServiceDocs)]
        public object ServiceDocs { get; set; }

        /// <summary>
        /// SMTP config for this service.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.Service.SmtpConfig)]
        public object SmtpConfig { get; set; }

        /// <summary>
        /// SQL Db configs for this service.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.Service.SqlDbConfigs)]
        public object SqlDbConfigs { get; set; }

        /// <summary>
        /// User config for this service.
        /// </summary>
        [JsonProperty(PropertyName = RelatedResources.Service.UserConfig)]
        public object UserConfig { get; set; }
    }
}