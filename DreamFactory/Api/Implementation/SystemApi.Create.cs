namespace DreamFactory.Api.Implementation
{
    using System.Collections.Generic;
    using System.Linq;
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
        public Task<IEnumerable<AppResponse>> CreateAppsAsync(SqlQuery query, params AppRequest[] apps)
        {
            return base.RequestWithPayloadAsync<AppRequest, AppResponse>(HttpMethod.Post, "app", query, apps);
        }

        public Task<IEnumerable<AppGroupResponse>> CreateAppGroupsAsync(SqlQuery query, params AppGroupRequest[] appGroups)
        {
            return base.RequestWithPayloadAsync<AppGroupRequest, AppGroupResponse>(HttpMethod.Post, "app_group", query, appGroups);
        }

        public Task<IEnumerable<UserResponse>> CreateUsersAsync(SqlQuery query, params UserRequest[] users)
        {
            return base.RequestWithPayloadAsync<UserRequest, UserResponse>(HttpMethod.Post, "user", query, users);
        }

        public Task<IEnumerable<RoleResponse>> CreateRolesAsync(SqlQuery query, params RoleRequest[] roles)
        {
            return base.RequestWithPayloadAsync<RoleRequest, RoleResponse>(HttpMethod.Post, "role", query, roles);
        }

        public Task<IEnumerable<ServiceResponse>> CreateServicesAsync(SqlQuery query, params ServiceRequest[] services)
        {
            return base.RequestWithPayloadAsync<ServiceRequest, ServiceResponse>(HttpMethod.Post, "service", query, services);
        }

        public Task<IEnumerable<EmailTemplateResponse>> CreateEmailTemplatesAsync(SqlQuery query, params EmailTemplateRequest[] templates)
        {
            return base.RequestWithPayloadAsync<EmailTemplateRequest, EmailTemplateResponse>(HttpMethod.Post, "email_template", query, templates);
        }

        public Task<EventScriptResponse> CreateEventScriptAsync(string eventName, SqlQuery query, EventScriptRequest eventScript)
        {
            return base.RequestWithPayloadAsync<EventScriptRequest, EventScriptResponse>(HttpMethod.Post, "event", eventName, query, eventScript);
        }
    }
}
