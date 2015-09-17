namespace DreamFactory.Model
{
    /// <summary>
    /// RelatedResources contains string constants of related resources that can be used when querying.
    /// </summary>
    public static class RelatedResources
    {
        /// <summary>
        /// Related resource names for app record.
        /// </summary>
        public struct App
        {
            /// <summary>
            /// Related resource name for the app group records.
            /// </summary>
            public const string AppGroups = "app_group_by_app_to_app_group";

            /// <summary>
            /// Related resource name for the lookup by app id record.
            /// </summary>
            public const string AppLookups = "app_lookup_by_app_id";

            /// <summary>
            /// Related resource name for the app records.
            /// </summary>
            public const string Apps = "app_to_app_group_by_app_id";

            /// <summary>
            /// Related resource name for the default role record.
            /// </summary>
            public const string DefaultRole = "role_by_role_id";

            /// <summary>
            /// Related resource name for the role records.
            /// </summary>
            public const string Roles = "role_by_user_to_app_to_role";

            /// <summary>
            /// Related resource name for the user created record.
            /// </summary>
            public const string UserCreated = "user_by_created_by_id";

            /// <summary>
            /// Related resource name for the user modified record.
            /// </summary>
            public const string UserLastModified = "user_by_last_modified_by_id";

            /// <summary>
            /// Related resource name for the user role records.
            /// </summary>
            public const string UserRoles = "user_to_app_to_role_by_app_id";

            /// <summary>
            /// Related resource name for the user records.
            /// </summary>
            public const string Users = "user_by_user_to_app_to_role";

            /// <summary>
            /// Related resource name for the lookup of user in app records.
            /// </summary>
            public const string UsersInAppLookup = "user_by_app_lookup";

            /// <summary>
            /// Related resource name for the storage service record.
            /// </summary>
            public const string StorageService = "service_by_storage_service_id";
        }

        /// <summary>
        /// Related resource names for user record.
        /// </summary>
        public struct User
        {
            /// <summary>
            /// Related resource name for the app records created by user.
            /// </summary>
            public const string AppsCreated = "app_by_created_by_id";

            /// <summary>
            /// Related resource name for the role records linked to this user.
            /// </summary>
            public const string RolesInApps = "role_by_app";

            /// <summary>
            /// Related resource name for the services records linked to this user.
            /// </summary>
            public const string ServicesInApps = "service_by_app";

            /// <summary>
            /// Related resource name for the app records created by user.
            /// </summary>
            public const string AppsLastModified = "app_by_last_modified_by_id";

            /// <summary>
            /// Related resource name for the app group records created by user.
            /// </summary>
            public const string AppGroupsCreated = "app_group_by_created_by_id";

            /// <summary>
            /// Related resource name for the app group records last modified by user.
            /// </summary>
            public const string AppGroupsLastModified = "app_group_by_last_modified_by_id";

            /// <summary>
            /// Related resource name for the app lookup records created by user.
            /// </summary>
            public const string AppLookupsCreated = "app_lookup_by_created_by_id";

            /// <summary>
            /// Related resource name for the apps in app lookup records linked to user.
            /// </summary>
            public const string AppsInAppLookups = "app_by_app_lookup";

            /// <summary>
            /// Related resource name for the app lookup records modified by user.
            /// </summary>
            public const string AppLookupsLastModified = "app_lookup_by_last_modified_by_id";

            /// <summary>
            /// Related resource name for cors config records created by user.
            /// </summary>
            public const string CorsConfigsCreated = "cors_config_by_created_by_id";

            /// <summary>
            /// Related resource name for cors config records last modified by user.
            /// </summary>
            public const string CorsConfigsLastModified = "cors_config_by_last_modified_by_id";

            /// <summary>
            /// Related resource name for db field extras records created by user.
            /// </summary>
            public const string DbFieldExtrasCreated = "db_field_extras_by_created_by_id";

            /// <summary>
            /// Related resource name for db field extras records last modified by user.
            /// </summary>
            public const string DbFieldExtrasLastModified = "db_field_extras_by_last_modified_by_id";

            /// <summary>
            /// Related resource name for services related to user through db table extras records.
            /// </summary>
            public const string ServicesInDbFieldExtras = "service_by_db_field_extras";

            /// <summary>
            /// Related resource name for db table extras records created by user.
            /// </summary>
            public const string DbTableExtrasCreated = "db_table_extras_by_created_by_id";

            /// <summary>
            /// Related resource name for db table extras records last modified by user.
            /// </summary>
            public const string DbTableExtrasLastModified = "db_table_extras_by_last_modified_by_id";

            /// <summary>
            /// Related resource name for services related to user through db table extras records.
            /// </summary>
            public const string ServicesInDbTableExtras = "service_by_db_table_extras";

            /// <summary>
            /// Related resource name for email template records created by user.
            /// </summary>
            public const string EmailTemplatesCreated = "email_template_by_created_by_id";

            /// <summary>
            /// Related resource name for email template records last modified by user.
            /// </summary>
            public const string EmailTemplatesLastModified = "email_template_by_last_modified_by_id";

            /// <summary>
            /// Related resource name for event script records created by user.
            /// </summary>
            public const string EventScriptsCreated = "event_script_by_created_by_id";

            /// <summary>
            /// Related resource name for event script records last modified by user.
            /// </summary>
            public const string EventScriptsLastModified = "event_script_by_last_modified_by_id";

            /// <summary>
            /// Related resource name for script type related to user through event script records.
            /// </summary>
            public const string ScriptTypesInEventScripts = "script_type_by_event_script";

            /// <summary>
            /// Related resource name for event subscriber records created by user.
            /// </summary>
            public const string EventSubscribersCreated = "event_subscriber_by_created_by_id";

            /// <summary>
            /// Related resource name for event subscriber records last modified by user.
            /// </summary>
            public const string EventSubscribersLastModified = "event_subscriber_by_last_modified_by_id";

            /// <summary>
            /// Related resource name for role records created by user.
            /// </summary>
            public const string RolesCreated = "role_by_created_by_id";

            /// <summary>
            /// Related resource name for role records last modified by user.
            /// </summary>
            public const string RolesLastModified = "role_by_last_modified_by_id";

            /// <summary>
            /// Related resource name for role lookup records created by user.
            /// </summary>
            public const string RoleLookupsCreated = "role_lookup_by_created_by_id";

            /// <summary>
            /// Related resource name for role lookup records last modified by user.
            /// </summary>
            public const string RoleLookupsLastModified = "role_lookup_by_last_modified_by_id";

            /// <summary>
            /// Related resource name for the lookup of role in role lookup records.
            /// </summary>
            public const string RolesInRoleLookups = "role_by_role_lookup";

            /// <summary>
            /// Related resource name for role service access records created by user.
            /// </summary>
            public const string RoleServiceAccessesCreated = "role_service_access_by_created_by_id";

            /// <summary>
            /// Related resource name for role service access records last modified by user.
            /// </summary>
            public const string RoleServiceAccessesLastModified = "role_service_access_by_last_modified_by_id";

            /// <summary>
            /// Related resource name for roles in role service access records linked to user.
            /// </summary>
            public const string RolesInRoleServiceAccesses = "role_by_role_service_access";

            /// <summary>
            /// Related resource name for services in role service access records linked to user.
            /// </summary>
            public const string ServicesInRoleServiceAccesses = "service_by_role_service_access";

            /// <summary>
            /// Related resource name for service records created by user.
            /// </summary>
            public const string ServicesCreated = "service_by_created_by_id";

            /// <summary>
            /// Related resource name for service records last modified by user.
            /// </summary>
            public const string ServicesLastModified = "service_by_last_modified_by_id";

            /// <summary>
            /// Related resource name for service types in service records linked to user.
            /// </summary>
            public const string ServiceTypesInServices = "service_type_by_service";

            /// <summary>
            /// Related resource name for system config records created by user.
            /// </summary>
            public const string SystemConfigsCreated = "system_config_by_created_by_id";

            /// <summary>
            /// Related resource name for system config records last modified by user.
            /// </summary>
            public const string SystemConfigsLastModified = "system_config_by_last_modified_by_id";

            /// <summary>
            /// Related resource name for system custom records created by user.
            /// </summary>
            public const string SystemCustomsCreated = "system_custom_by_created_by_id";

            /// <summary>
            /// Related resource name for system custom records last modified by user.
            /// </summary>
            public const string SystemCustomsLastModified = "system_custom_by_last_modified_by_id";

            /// <summary>
            /// Related resource name for system lookup records created by user.
            /// </summary>
            public const string SystemLookupsCreated = "system_lookup_by_created_by_id";

            /// <summary>
            /// Related resource name for system lookup records last modified by user.
            /// </summary>
            public const string SystemLookupsLastModified = "system_lookup_by_last_modified_by_id";

            /// <summary>
            /// Related resource name for system setting records created by user.
            /// </summary>
            public const string SystemSettingsCreated = "system_setting_by_created_by_id";

            /// <summary>
            /// Related resource name for system setting records last modified by user.
            /// </summary>
            public const string SystemSettingsLastModified = "system_setting_by_last_modified_by_id";

            /// <summary>
            /// Related resource name for token map records linked to user.
            /// </summary>
            public const string TokenMap = "token_map_by_user_id";

            /// <summary>
            /// Related resource name for user records created by user.
            /// </summary>
            public const string UsersCreated = "user_by_created_by_id";

            /// <summary>
            /// Related resource name for user records last modified by user.
            /// </summary>
            public const string UsersLastModified = "user_by_last_modified_by_id";

            /// <summary>
            /// Related resource name for user custom records created by user.
            /// </summary>
            public const string UserCustomsCreated = "user_custom_by_created_by_id";

            /// <summary>
            /// Related resource name for user custom records last modified by user.
            /// </summary>
            public const string UserCustomsLastModified = "user_custom_by_last_modified_by_id";

            /// <summary>
            /// Related resource name user custom records linked to user.
            /// </summary>
            public const string UserCustoms = "user_custom_by_user_id";

            /// <summary>
            /// Related resource name for user lookup records created by user.
            /// </summary>
            public const string UserLookupsCreated = "user_lookup_by_created_by_id";

            /// <summary>
            /// Related resource name for user lookup records last modified by user.
            /// </summary>
            public const string UserLookupsLastModified = "user_lookup_by_last_modified_by_id";

            /// <summary>
            /// Related resource name for user lookup records linked to user.
            /// </summary>
            public const string UserLookups = "user_lookup_by_user_id";

            /// <summary>
            /// Related resource name for user app role records linked to user.
            /// </summary>
            public const string UserAppRoles = "user_to_app_to_role_by_user_id";

            /// <summary>
            /// Related resource name for apps in user app role records linked to user.
            /// </summary>
            public const string AppsInUserAppRoles = "app_by_user_to_app_to_role";

            /// <summary>
            /// Related resource name for roles in user app role records linked to user.
            /// </summary>
            public const string RolesInUserAppRoles = "role_by_user_to_app_to_role";
        }

        /// <summary>
        /// Related resource names for role record.
        /// </summary>
        public struct Role
        {
            /// <summary>
            /// Related resource name for the app records linked to role.
            /// </summary>
            public const string Apps = "app_by_role_id";

            /// <summary>
            /// Related resource name for the user in app records linked to role.
            /// </summary>
            public const string UsersInApps = "user_by_app";

            /// <summary>
            /// Related resource name for the service in app records linked to role.
            /// </summary>
            public const string ServicesInApps = "service_by_app";

            /// <summary>
            /// Related resource name for the LDAP config for default role.
            /// </summary>
            public const string LdapConfig = "ldap_config_by_default_role";

            /// <summary>
            /// Related resource name for the services in LDAP config record linked to role.
            /// </summary>
            public const string ServicesInLdapConfig = "service_by_ldap_config";

            /// <summary>
            /// Related resource name for the OAuth config linked to role.
            /// </summary>
            public const string OAuthConfig = "oauth_config_by_default_role";

            /// <summary>
            /// Related resource name for the services in OAuth config record linked to role.
            /// </summary>
            public const string ServicesInOAuthConfig = "service_by_oauth_config";

            /// <summary>
            /// Related resource name for the user that created a role.
            /// </summary>
            public const string UserCreated = "user_by_created_by_id";

            /// <summary>
            /// Related resource name for the user that last modified a role.
            /// </summary>
            public const string UserLastModified = "user_by_last_modified_by_id";

            /// <summary>
            /// Related resource name for the role lookups linked to role.
            /// </summary>
            public const string RoleLookups = "role_lookup_by_role_id";

            /// <summary>
            /// Related resource name for the users in role lookup records linked to role.
            /// </summary>
            public const string UsersInRoleLookups = "user_by_role_lookup";

            /// <summary>
            /// Related resource name for the role service accesses linked to role.
            /// </summary>
            public const string RoleServiceAccesses = "role_service_access_by_role_id";

            /// <summary>
            /// Related resource name for the users in role service access records linked to role.
            /// </summary>
            public const string UsersInRoleServiceAccesses = "user_by_role_service_access";

            /// <summary>
            /// Related resource name for the services in role service access records linked to role.
            /// </summary>
            public const string ServicesInRoleServiceAccesses = "service_by_role_service_access";

            /// <summary>
            /// Related resource name for the user app role records linked to role.
            /// </summary>
            public const string UserAppRoles = "user_to_app_to_role_by_role_id";

            /// <summary>
            /// Related resource name for the apps in user app role records linked to role.
            /// </summary>
            public const string AppsInUserAppRoles = "app_by_user_to_app_to_role";

            /// <summary>
            /// Related resource name for the users in user app role records linked to role.
            /// </summary>
            public const string UsersInUserAppRoles = "user_by_user_to_app_to_role";
        }

        /// <summary>
        /// Related resource names for script type record.
        /// </summary>
        public struct ScriptType
        {
            /// <summary>
            /// Related resource name for the event script records linked to script type.
            /// </summary>
            public const string EventScripts = "event_script_by_type";

            /// <summary>
            /// Related resource name for the users in event script records linked to script type.
            /// </summary>
            public const string UsersInEventScripts = "user_by_event_script";

            /// <summary>
            /// Related resource name for script config record linked to script type.
            /// </summary>
            public const string ScriptConfig = "script_config_by_type";

            /// <summary>
            /// Related resource name for the services in script config record linked to script type.
            /// </summary>
            public const string ServicesInScriptConfig = "service_by_script_config";
        }

        /// <summary>
        /// Related resource names for event script record.
        /// </summary>
        public struct EventScript
        {
            /// <summary>
            /// Related resource name for user record linked to event script.
            /// </summary>
            public const string UserCreated = "user_by_created_by_id";

            /// <summary>
            /// Related resource name for user record linked to event script.
            /// </summary>
            public const string UserLastModified = "user_by_last_modified_by_id";

            /// <summary>
            /// Related resource name for script type record linked to event script.
            /// </summary>
            public const string ScriptType = "script_type_by_type";
        }

        /// <summary>
        /// Related resource names for event script record.
        /// </summary>
        public struct Custom
        {
            /// <summary>
            /// Related resource name for user record linked to custom setting.
            /// </summary>
            public const string UserCreated = "user_by_created_by_id";

            /// <summary>
            /// Related resource name for user record linked to custom setting.
            /// </summary>
            public const string UserLastModified = "user_by_last_modified_by_id";

            /// <summary>
            /// Related resource name for user record in custom setting.
            /// </summary>
            public const string User = "user_by_user_id";
        }

        /// <summary>
        /// Related resource names for app group record.
        /// </summary>
        public struct AppGroup
        {
            /// <summary>
            /// Related resource name for user record linked to app group.
            /// </summary>
            public const string UserCreated = "user_by_created_by_id";

            /// <summary>
            /// Related resource name for user record linked to app group.
            /// </summary>
            public const string UserLastModified = "user_by_last_modified_by_id";

            /// <summary>
            /// Related resource name for app to app group records linked to app group.
            /// </summary>
            public const string AppToAppGroups = "app_to_app_group_by_group_id";

            /// <summary>
            /// Related resource name for the apps in app to app group records linked to app group.
            /// </summary>
            public const string AppsInAppToAppGroups = "app_by_app_to_app_group";
        }

        /// <summary>
        /// Related resource names for service record.
        /// </summary>
        public struct Service
        {
            /// <summary>
            /// Related resource name for the app records using this service.
            /// </summary>
            public const string Apps = "app_by_storage_service_id";

            /// <summary>
            /// Related resource name for the roles in app records linked to this service.
            /// </summary>
            public const string UsersInApps = "user_by_app";

            /// <summary>
            /// Related resource name for the roles in app records linked to this service.
            /// </summary>
            public const string RolesInApps = "role_by_app";

            /// <summary>
            /// Related resource name for the aws config record linked to this service.
            /// </summary>
            public const string AwsConfig = "aws_config_by_service_id";

            /// <summary>
            /// Related resource name for the azure config record linked to this service.
            /// </summary>
            public const string AzureConfig = "azure_config_by_service_id";

            /// <summary>
            /// Related resource name for the cloud email config record linked to this service.
            /// </summary>
            public const string CloudEmailConfig = "cloud_email_config_by_service_id";

            /// <summary>
            /// Related resource name for the couch db config record linked to this service.
            /// </summary>
            public const string CouchDbConfig = "couchdb_config_by_service_id";

            /// <summary>
            /// Related resource name for the db field extra records linked to this service.
            /// </summary>
            public const string DbFieldExtras = "db_field_extras_by_service_id";

            /// <summary>
            /// Related resource name for the users in db field extra records linked to this service.
            /// </summary>
            public const string UsersInDbFieldExtras = "user_by_db_field_extras";

            /// <summary>
            /// Related resource name for the db table extra records linked to this service.
            /// </summary>
            public const string DbTableExtras = "db_table_extras_by_service_id";

            /// <summary>
            /// Related resource name for the users in db table extra records linked to this service.
            /// </summary>
            public const string UsersInDbTableExtras = "user_by_db_table_extras";

            /// <summary>
            /// Related resource name for the email parameters record linked to this service.
            /// </summary>
            public const string EmailParametersConfig = "email_parameters_config_by_service_id";

            /// <summary>
            /// Related resource name for the users in file service record linked to this service.
            /// </summary>
            public const string FileServiceConfig = "file_service_config_by_service_id";

            /// <summary>
            /// Related resource name for the ldap config record linked to this service.
            /// </summary>
            public const string LdapConfig = "ldap_config_by_service_id";

            /// <summary>
            /// Related resource name for the roles in ldap config record linked to this service.
            /// </summary>
            public const string RolesInLdapConfig = "role_by_ldap_config";

            /// <summary>
            /// Related resource name for the mongo db config record linked to this service.
            /// </summary>
            public const string MongoDbConfig = "mongodb_config_by_service_id";

            /// <summary>
            /// Related resource name for the OAuth config record linked to this service.
            /// </summary>
            public const string OAuthConfig = "oauth_config_by_service_id";

            /// <summary>
            /// Related resource name for the roles in OAuth config record linked to this service.
            /// </summary>
            public const string RolesInOAuthConfig = "role_by_oauth_config";

            /// <summary>
            /// Related resource name for the rackspace config record linked to this service.
            /// </summary>
            public const string RackspaceConfig = "rackspace_config_by_service_id";

            /// <summary>
            /// Related resource name for the role service access records linked to this service.
            /// </summary>
            public const string RoleServiceAccesses = "role_service_access_by_service_id";

            /// <summary>
            /// Related resource name for the users in role service access records linked to this service.
            /// </summary>
            public const string UsersInRoleServiceAccesses = "user_by_role_service_access";

            /// <summary>
            /// Related resource name for the roles in role service access records linked to this service.
            /// </summary>
            public const string RolesInRoleServiceAccesses = "role_by_role_service_access";

            /// <summary>
            /// Related resource name for the rws config record linked to this service.
            /// </summary>
            public const string RwsConfig = "rws_config_by_service_id";

            /// <summary>
            /// Related resource name for the headers in rws config record linked to this service.
            /// </summary>
            public const string HeadersInRwsConfig = "rws_headers_config_by_service_id";

            /// <summary>
            /// Related resource name for the parameters in rws config record linked to this service.
            /// </summary>
            public const string ParametersInRwsConfig = "rws_parameters_config_by_service_id";

            /// <summary>
            /// Related resource name for the salesforce db config record linked to this service.
            /// </summary>
            public const string SalesforceDbConfig = "salesforce_db_config_by_service_id";

            /// <summary>
            /// Related resource name for the script config records linked to this service.
            /// </summary>
            public const string ScriptConfigs = "script_config_by_service_id";

            /// <summary>
            /// Related resource name for the script types in script config records linked to this service.
            /// </summary>
            public const string ScriptTypesInScriptConfigs = "script_type_by_script_config";

            /// <summary>
            /// Related resource name for user record linked to this service.
            /// </summary>
            public const string UserCreated = "user_by_created_by_id";

            /// <summary>
            /// Related resource name for user record linked to this service.
            /// </summary>
            public const string UserLastModified = "user_by_last_modified_by_id";

            /// <summary>
            /// Related resource name for service type record linked to this service.
            /// </summary>
            public const string ServiceType = "service_type_by_type";

            /// <summary>
            /// Related resource name for the service cache config record linked to this service.
            /// </summary>
            public const string ServiceCacheConfig = "service_cache_config_by_service_id";

            /// <summary>
            /// Related resource name for the service doc records linked to this service.
            /// </summary>
            public const string ServiceDocs = "service_doc_by_service_id";

            /// <summary>
            /// Related resource name for the SMTP config records linked to this service.
            /// </summary>
            public const string SmtpConfig = "smtp_config_by_service_id";

            /// <summary>
            /// Related resource name for the SQL DB config records linked to this service.
            /// </summary>
            public const string SqlDbConfigs = "sql_db_config_by_service_id";

            /// <summary>
            /// Related resource name for the user config record linked to this service.
            /// </summary>
            public const string UserConfig = "user_config_by_service_id";
        }

        /// <summary>
        /// Related resource names for environment record.
        /// </summary>
        public struct Environment
        {
            /// <summary>
            /// Related resource name for the apps in app group records in this environment.
            /// </summary>
            public const string AppsInAppGroups = "app_group";

            /// <summary>
            /// Related resource name for the apps not in app group records in this environment.
            /// </summary>
            public const string AppsNotInAppGroups = "no_app_group";
        }

        /// <summary>
        /// Related resource names for cors record.
        /// </summary>
        public struct Cors
        {
            /// <summary>
            /// Related resource name for the user created record.
            /// </summary>
            public const string UserCreated = "user_by_created_by_id";

            /// <summary>
            /// Related resource name for the user modified record.
            /// </summary>
            public const string UserLastModified = "user_by_last_modified_by_id";
        }
    }
}
