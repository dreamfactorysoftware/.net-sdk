namespace DreamFactory.Api
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DreamFactory.Model.Database;
    using DreamFactory.Model.System.App;
    using DreamFactory.Model.System.AppGroup;
    using DreamFactory.Model.System.Config;
    using DreamFactory.Model.System.Email;
    using DreamFactory.Model.System.Environment;
    using DreamFactory.Model.System.Event;
    using DreamFactory.Model.System.Role;
    using DreamFactory.Model.System.Script;
    using DreamFactory.Model.System.Service;
    using DreamFactory.Model.System.User;
    using DreamFactory.Model.User;

    /// <summary>
    /// Represents /system API.
    /// </summary>
    public interface ISystemApi
    {

        #region admin

        /// <summary>
        /// Login and create a new admin session.
        /// </summary>
        /// <remarks>
        /// Successful login operation will set ApplicationName and SessionToken headers.
        /// This call works only with v2 of the api.
        /// </remarks>
        /// <param name="applicationName">Application name.</param>
        /// <param name="applicationApiKey">Application api key.</param>
        /// <param name="email">Email.</param>
        /// <param name="password">Password.</param>
        /// <param name="duration">Session duration.</param>
        /// <returns>Session object instance.</returns>
        Task<Session> LoginAdminAsync(string applicationName, string applicationApiKey, string email, string password, int duration = 0);

        /// <summary>
        /// Logout and destroy the current admin session.
        /// </summary>
        /// <returns>
        /// True if the operation was successful and false if it wasn't.
        /// </returns>
        Task<bool> LogoutAdminAsync();

        /// <summary>
        /// Retrieve the current admin session information.
        /// </summary>
        /// <returns>Session object instance.</returns>
        Task<Session> GetAdminSessionAsync();

        #endregion

        #region app

        /// <summary>
        /// Retrieve one or more applications.
        /// </summary>
        /// <param name="query">Query parameters.</param>
        /// <returns>List of applications.</returns>
        Task<IEnumerable<AppResponse>> GetAppsAsync(SqlQuery query);

        /// <summary>
        /// Create one or more applications.
        /// </summary>
        /// <param name="query">Query parameters.</param>
        /// <param name="apps">Applications to create.</param>
        /// <returns>List of created applications.</returns>
        Task<IEnumerable<AppResponse>> CreateAppsAsync(SqlQuery query, params AppRequest[] apps);

        /// <summary>
        /// Update one or more applications.
        /// </summary>
        /// <param name="query">Query parameters.</param>
        /// <param name="apps">Applications to update.</param>
        /// <returns>List of updated applications.</returns>
        Task<IEnumerable<AppResponse>> UpdateAppsAsync(SqlQuery query, params AppRequest[] apps);

        /// <summary>
        /// Delete one or more applications.
        /// </summary>
        /// <param name="query">Query parameters.</param>
        /// <param name="ids">Application IDs to delete.</param>
        /// <returns>By default, only the id property of the record deleted is returned on success. Use 'fields' and 'related' to return more properties of the deleted records.</returns>
        Task<IEnumerable<AppResponse>> DeleteAppsAsync(SqlQuery query, params int[] ids);

        /// <summary>
        /// Delete all applications.
        /// </summary>
        /// <param name="query">Query parameters.</param>
        /// <returns>By default, only the id property of the record deleted is returned on success. Use 'fields' and 'related' to return more properties of the deleted records.</returns>
        Task<IEnumerable<AppResponse>> DeleteAllAppsAsync(SqlQuery query = null);

        #endregion

        #region app group

        /// <summary>
        /// Retrieve one or more application groups.
        /// </summary>
        /// <param name="query">Query parameters.</param>
        /// <returns>List of application groups.</returns>
        Task<IEnumerable<AppGroupResponse>> GetAppGroupsAsync(SqlQuery query);

        /// <summary>
        /// Create one or more application groups.
        /// </summary>
        /// <param name="query">Query parameters.</param>
        /// <param name="appGroups">Application groups to create.</param>
        /// <returns>List of created application groups.</returns>
        Task<IEnumerable<AppGroupResponse>> CreateAppGroupsAsync(SqlQuery query, params AppGroupRequest[] appGroups);

        /// <summary>
        /// Update one or more application groups.
        /// </summary>
        /// <param name="query">Query parameters.</param>
        /// <param name="appGroups">Application groups to update.</param>
        /// <returns>List of updated application groups.</returns>
        Task<IEnumerable<AppGroupResponse>> UpdateAppGroupsAsync(SqlQuery query, params AppGroupRequest[] appGroups);

        /// <summary>
        /// Delete one or more application groups.
        /// </summary>
        /// <param name="query">Query parameters.</param>
        /// <param name="ids">Application Group IDs to delete.</param>
        /// <returns>By default, only the id property of the record deleted is returned on success. Use 'fields' and 'related' to return more properties of the deleted records.</returns>
        Task<IEnumerable<AppGroupResponse>> DeleteAppGroupsAsync(SqlQuery query, params int[] ids);

        /// <summary>
        /// Delete all application groups.
        /// </summary>
        /// <param name="query">Query parameters.</param>
        /// <returns>By default, only the id property of the record deleted is returned on success. Use 'fields' and 'related' to return more properties of the deleted records.</returns>
        Task<IEnumerable<AppGroupResponse>> DeleteAllAppGroupsAsync(SqlQuery query = null);

        #endregion

        #region config

        /// <summary>
        /// Retrieve system configuration properties.
        /// </summary>
        /// <returns>See <see cref="ConfigResponse"/>.</returns>
        Task<ConfigResponse> GetConfigAsync();

        /// <summary>
        /// Update one or more system configuration properties.
        /// </summary>
        /// <param name="config">New configuration properties.</param>
        /// <returns>See <see cref="ConfigResponse"/>.</returns>
        Task<ConfigResponse> SetConfigAsync(ConfigRequest config);

        #endregion

        #region constant

        /// <summary>
        /// Get all enumerated types.
        /// </summary>
        /// <returns>List of enumeration types.</returns>
        Task<IEnumerable<string>> GetConstantsAsync();

        /// <summary>
        /// Get enumerated type constant values.
        /// </summary>
        /// <param name="constant">Identifier of the enumeration type to retrieve.</param>
        /// <returns>Key-value pairs.</returns>
        Task<Dictionary<string, string>> GetConstantAsync(string constant);

        #endregion

        #region email template

        /// <summary>
        /// Retrieve one or more email templates.
        /// </summary>
        /// <param name="query">Query parameters.</param>
        /// <returns>List of email templates.</returns>
        Task<IEnumerable<EmailTemplateResponse>> GetEmailTemplatesAsync(SqlQuery query);

        /// <summary>
        /// Create one or more email templates.
        /// </summary>
        /// <param name="query">Query parameters.</param>
        /// <param name="templates">Email templates to create.</param>
        /// <returns>List of created email templates.</returns>
        Task<IEnumerable<EmailTemplateResponse>> CreateEmailTemplatesAsync(SqlQuery query, params EmailTemplateRequest[] templates);

        /// <summary>
        /// Update one or more email templates.
        /// </summary>
        /// <param name="query">Query parameters.</param>
        /// <param name="templates">Email templates to update.</param>
        /// <returns>List of updated email templates.</returns>
        Task<IEnumerable<EmailTemplateResponse>> UpdateEmailTemplatesAsync(SqlQuery query, params EmailTemplateRequest[] templates);

        /// <summary>
        /// Delete one or more email templates.
        /// </summary>
        /// <param name="query">Query parameters.</param>
        /// <param name="ids">Email template IDs to delete.</param>
        /// <returns>By default, only the id property of the record deleted is returned on success. Use 'fields' and 'related' to return more properties of the deleted records.</returns>
        Task<IEnumerable<EmailTemplateResponse>> DeleteEmailTemplatesAsync(SqlQuery query, params int[] ids);

        /// <summary>
        /// Delete all email templates.
        /// </summary>
        /// <param name="query">Query parameters.</param>
        /// <returns>By default, only the id property of the record deleted is returned on success. Use 'fields' and 'related' to return more properties of the deleted records.</returns>
        Task<IEnumerable<EmailTemplateResponse>> DeleteAllEmailTemplatesAsync(SqlQuery query = null);

        #endregion

        #region environment

        /// <summary>
        /// Retrieve environment information.
        /// </summary>
        /// <returns>See <see cref="EnvironmentResponse"/>.</returns>
        Task<EnvironmentResponse> GetEnvironmentAsync();

        #endregion

        #region event

        /// <summary>
        /// Gets all system events.
        /// </summary>
        /// <returns>List of all event names.</returns>
        Task<IEnumerable<string>> GetEventsAsync();

        /// <summary>
        /// Gets event script by name.
        /// </summary>
        /// <param name="eventName">Event script identifier.</param>
        /// <param name="query">Query parameters.</param>
        /// <returns>Event script with queried fields and relationships.</returns>
        Task<EventScriptResponse> GetEventScriptAsync(string eventName, SqlQuery query);

        /// <summary>
        /// Create event script.
        /// </summary>
        /// <param name="eventName">Event script identifier.</param>
        /// <param name="eventScript">Event script to create.</param>
        /// <param name="query">Query parameters.</param>
        /// <returns>Event script with queried fields and relationships.</returns>
        Task<EventScriptResponse> CreateEventScriptAsync(string eventName, EventScriptRequest eventScript, SqlQuery query);

        /// <summary>
        /// Update event script.
        /// </summary>
        /// <param name="eventName">Event script identifier.</param>
        /// <param name="eventScript">Event script to update.</param>
        /// <param name="query">Query parameters.</param>
        /// <returns>Event script with queried fields and relationships.</returns>
        Task<EventScriptResponse> UpdateEventScriptAsync(string eventName, EventScriptRequest eventScript, SqlQuery query);

        /// <summary>
        /// Delete event script.
        /// </summary>
        /// <param name="eventName">Event script identifier.</param>
        /// <param name="query">Query parameters.</param>
        /// <returns>Event script with queried fields and relationships.</returns>
        Task<EventScriptResponse> DeleteEventScriptAsync(string eventName, SqlQuery query);

        #endregion

        #region role

        /// <summary>
        /// Retrieve one or more roles.
        /// </summary>
        /// <param name="query">Query parameters.</param>
        /// <returns>List of roles.</returns>
        Task<IEnumerable<RoleResponse>> GetRolesAsync(SqlQuery query);

        /// <summary>
        /// Create one or more roles.
        /// </summary>
        /// <param name="query">Query parameters.</param>
        /// <param name="roles">Roles to create.</param>
        /// <returns>List of created roles.</returns>
        Task<IEnumerable<RoleResponse>> CreateRolesAsync(SqlQuery query, params RoleRequest[] roles);

        /// <summary>
        /// Update one or more roles.
        /// </summary>
        /// <param name="query">Query parameters.</param>
        /// <param name="roles">Roles to update.</param>
        /// <returns>List of updated roles.</returns>
        Task<IEnumerable<RoleResponse>> UpdateRolesAsync(SqlQuery query, params RoleRequest[] roles);

        /// <summary>
        /// Delete one or more roles.
        /// </summary>
        /// <param name="query">Query parameters.</param>
        /// <param name="ids">Role IDs to delete.</param>
        /// <returns>By default, only the id property of the record deleted is returned on success. Use 'fields' and 'related' to return more properties of the deleted records.</returns>
        Task<IEnumerable<RoleResponse>> DeleteRolesAsync(SqlQuery query, params int[] ids);

        /// <summary>
        /// Delete all roles.
        /// </summary>
        /// <param name="query">Query parameters.</param>
        /// <returns>By default, only the id property of the record deleted is returned on success. Use 'fields' and 'related' to return more properties of the deleted records.</returns>
        Task<IEnumerable<RoleResponse>> DeleteAllRolesAsync(SqlQuery query = null);

        #endregion

        #region script type

        /// <summary>
        /// Retrieve one or more script types.
        /// </summary>
        /// <param name="query">Query parameters.</param>
        /// <returns>List of script types.</returns>
        Task<IEnumerable<ScriptTypeResponse>> GetScriptTypesAsync(SqlQuery query);

        #endregion

        #region service

        /// <summary>
        /// Retrieve one or more services.
        /// </summary>
        /// <param name="query">Query parameters.</param>
        /// <returns>List of services.</returns>
        Task<IEnumerable<ServiceResponse>> GetServicesAsync(SqlQuery query);

        /// <summary>
        /// Create one or more services.
        /// </summary>
        /// <param name="query">Query parameters.</param>
        /// <param name="services">Services to create.</param>
        /// <returns>List of created services.</returns>
        Task<IEnumerable<ServiceResponse>> CreateServicesAsync(SqlQuery query, params ServiceRequest[] services);

        /// <summary>
        /// Update one or more services.
        /// </summary>
        /// <param name="query">Query parameters.</param>
        /// <param name="services">Services to update.</param>
        /// <returns>List of updated services.</returns>
        Task<IEnumerable<ServiceResponse>> UpdateServicesAsync(SqlQuery query, params ServiceRequest[] services);

        /// <summary>
        /// Delete one or more services.
        /// </summary>
        /// <param name="query">Query parameters.</param>
        /// <param name="ids">Service IDs to delete.</param>
        /// <returns>By default, only the id property of the record deleted is returned on success. Use 'fields' and 'related' to return more properties of the deleted records.</returns>
        Task<IEnumerable<ServiceResponse>> DeleteServicesAsync(SqlQuery query, params int[] ids);

        /// <summary>
        /// Delete all services.
        /// </summary>
        /// <param name="query">Query parameters.</param>
        /// <returns>By default, only the id property of the record deleted is returned on success. Use 'fields' and 'related' to return more properties of the deleted records.</returns>
        Task<IEnumerable<ServiceResponse>> DeleteAllServicesAsync(SqlQuery query = null);

        #endregion

        #region user

        /// <summary>
        /// Retrieve one or more users.
        /// </summary>
        /// <param name="query">Query parameters.</param>
        /// <returns>List of users.</returns>
        Task<IEnumerable<UserResponse>> GetUsersAsync(SqlQuery query);

        /// <summary>
        /// Create one or more users.
        /// </summary>
        /// <param name="query">Query parameters.</param>
        /// <param name="users">Users to create.</param>
        /// <returns>List of created users.</returns>
        Task<IEnumerable<UserResponse>> CreateUsersAsync(SqlQuery query, params UserRequest[] users);

        /// <summary>
        /// Update one or more users.
        /// </summary>
        /// <param name="query">Query parameters.</param>
        /// <param name="users">Users to update.</param>
        /// <returns>List of updated users.</returns>
        Task<IEnumerable<UserResponse>> UpdateUsersAsync(SqlQuery query, params UserRequest[] users);

        /// <summary>
        /// Delete one or more users.
        /// </summary>
        /// <param name="query">Query parameters.</param>
        /// <param name="ids">User IDs to delete.</param>
        /// <returns>By default, only the id property of the record deleted is returned on success. Use 'fields' and 'related' to return more properties of the deleted records.</returns>
        Task<IEnumerable<UserResponse>> DeleteUsersAsync(SqlQuery query, params int[] ids);

        /// <summary>
        /// Delete all users.
        /// </summary>
        /// <param name="query">Query parameters.</param>
        /// <returns>By default, only the id property of the record deleted is returned on success. Use 'fields' and 'related' to return more properties of the deleted records.</returns>
        Task<IEnumerable<UserResponse>> DeleteAllUsersAsync(SqlQuery query = null);

        #endregion

    }
}
