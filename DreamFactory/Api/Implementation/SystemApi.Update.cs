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
            return base.RequestWithPayloadAsync<AppRequest, AppResponse>(
                method: HttpMethod.Patch,
                resource: "app", 
                query: query, 
                payload: apps
                );
        }

        public Task<IEnumerable<AppGroupResponse>> UpdateAppGroupsAsync(SqlQuery query, params AppGroupRequest[] appGroups)
        {
            return base.RequestWithPayloadAsync<AppGroupRequest, AppGroupResponse>(
                method: HttpMethod.Patch,
                resource: "app_group",
                query: query,
                payload: appGroups
                );
        }

        public Task<IEnumerable<RoleResponse>> UpdateRolesAsync(SqlQuery query, params RoleRequest[] roles)
        {
            return base.RequestWithPayloadAsync<RoleRequest, RoleResponse>(
                method: HttpMethod.Patch,
                resource: "role",
                query: query,
                payload: roles
                );
        }

        public Task<IEnumerable<UserResponse>> UpdateUsersAsync(SqlQuery query, params UserRequest[] users)
        {
            return base.RequestWithPayloadAsync<UserRequest, UserResponse>(
                method: HttpMethod.Patch,
                resource: "user",
                query: query,
                payload: users
                );
        }

        public Task<IEnumerable<ServiceResponse>> UpdateServicesAsync(SqlQuery query, params ServiceRequest[] services)
        {
            return base.RequestWithPayloadAsync<ServiceRequest, ServiceResponse>(
                method: HttpMethod.Patch,
                resource: "service",
                query: query,
                payload: services
                );
        }

        public Task<IEnumerable<EmailTemplateResponse>> UpdateEmailTemplatesAsync(SqlQuery query, params EmailTemplateRequest[] templates)
        {
            return base.RequestWithPayloadAsync<EmailTemplateRequest, EmailTemplateResponse>(
                method: HttpMethod.Patch,
                resource: "email_template",
                query: query,
                payload: templates
                );
        }

        public Task<EventScriptResponse> UpdateEventScriptAsync(string eventName, SqlQuery query, EventScriptRequest eventScript)
        {
            return base.RequestWithPayloadAsync<EventScriptRequest, EventScriptResponse>(
                method: HttpMethod.Patch,
                resource: "event", 
                resourceIdentifier: eventName,
                query: query, 
                payload: eventScript
                );
        }
    }
}
