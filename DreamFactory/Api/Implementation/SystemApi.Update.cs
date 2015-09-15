namespace DreamFactory.Api.Implementation
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DreamFactory.Http;
    using DreamFactory.Model.Database;
    using DreamFactory.Model.System.App;
    using DreamFactory.Model.System.AppGroup;
    using DreamFactory.Model.System.Email;
    using DreamFactory.Model.System.Event;
    using DreamFactory.Model.System.Role;
    using DreamFactory.Model.System.Service;
    using DreamFactory.Model.System.User;

    internal partial class SystemApi
    {
        public Task<IEnumerable<AppResponse>> UpdateAppsAsync(SqlQuery query, params AppRequest[] apps)
        {
            return CreateOrUpdateAsync<AppRequest, AppResponse>(HttpMethod.Patch, "app", query, apps);
        }

        public Task<IEnumerable<AppGroupResponse>> UpdateAppGroupsAsync(SqlQuery query, params AppGroupRequest[] appGroups)
        {
            return CreateOrUpdateAsync<AppGroupRequest, AppGroupResponse>(HttpMethod.Patch, "app_group", query, appGroups);
        }

        public Task<IEnumerable<RoleResponse>> UpdateRolesAsync(SqlQuery query, params RoleRequest[] roles)
        {
            return CreateOrUpdateAsync<RoleRequest, RoleResponse>(HttpMethod.Patch, "role", query, roles);
        }

        public Task<IEnumerable<UserResponse>> UpdateUsersAsync(SqlQuery query, params UserRequest[] users)
        {
            return CreateOrUpdateAsync<UserRequest, UserResponse>(HttpMethod.Patch, "user", query, users);
        }

        public Task<IEnumerable<ServiceResponse>> UpdateServicesAsync(SqlQuery query, params ServiceRequest[] services)
        {
            return CreateOrUpdateAsync<ServiceRequest, ServiceResponse>(HttpMethod.Patch, "service", query, services);
        }

        public Task<IEnumerable<EmailTemplateResponse>> UpdateEmailTemplatesAsync(SqlQuery query, params EmailTemplateRequest[] templates)
        {
            return CreateOrUpdateAsync<EmailTemplateRequest, EmailTemplateResponse>(HttpMethod.Patch, "email_template", query, templates);
        }

        public Task<EventScriptResponse> UpdateEventScriptAsync(string eventName, SqlQuery query, EventScriptRequest eventScript)
        {
            return CreateOrUpdateAsync<EventScriptRequest, EventScriptResponse>(HttpMethod.Patch, "event", eventName, query, eventScript);
        }
    }
}
