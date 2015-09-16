namespace DreamFactory.Api.Implementation
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DreamFactory.Http;
    using DreamFactory.Model;
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
        public async Task<IEnumerable<AppResponse>> GetAppsAsync(SqlQuery query)
        {
            ResourceWrapper<AppResponse> response = await base.RequestAsync<ResourceWrapper<AppResponse>>(
                method: HttpMethod.Get,
                resource: "app", 
                query: query
                );

            return response.Records;
        }

        public async Task<IEnumerable<AppGroupResponse>> GetAppGroupsAsync(SqlQuery query)
        {
            ResourceWrapper<AppGroupResponse> response = await base.RequestAsync<ResourceWrapper<AppGroupResponse>>(
                method: HttpMethod.Get,
                resource: "app_group", 
                query: query
                );

            return response.Records;
        }

        public async Task<IEnumerable<RoleResponse>> GetRolesAsync(SqlQuery query)
        {
            ResourceWrapper<RoleResponse> response = await base.RequestAsync<ResourceWrapper<RoleResponse>>(
                method: HttpMethod.Get,
                resource: "role",
                query: query
                );

            return response.Records;
        }

        public async Task<IEnumerable<UserResponse>> GetUsersAsync(SqlQuery query)
        {
            ResourceWrapper<UserResponse> response = await base.RequestAsync<ResourceWrapper<UserResponse>>(
                method: HttpMethod.Get,
                resource: "user",
                query: query
                );

            return response.Records;
        }

        public async Task<IEnumerable<ServiceResponse>> GetServicesAsync(SqlQuery query)
        {
            ResourceWrapper<ServiceResponse> response = await base.RequestAsync<ResourceWrapper<ServiceResponse>>(
                method: HttpMethod.Get,
                resource: "service",
                query: query
                );

            return response.Records;
        }

        public async Task<IEnumerable<EmailTemplateResponse>> GetEmailTemplatesAsync(SqlQuery query)
        {
            ResourceWrapper<EmailTemplateResponse> response = await base.RequestAsync<ResourceWrapper<EmailTemplateResponse>>(
                method: HttpMethod.Get,
                resource: "email_template",
                query: query
                );

            return response.Records;
        }

        public Task<EventScriptResponse> GetEventScriptAsync(string eventName, SqlQuery query)
        {
            return base.RequestAsync<EventScriptResponse>(
                method: HttpMethod.Get, 
                resource: "event",
                resourceIdentifier: eventName,
                query: query
                );
        }

        public async Task<IEnumerable<string>> GetEventsAsync()
        {
            ResourceWrapper<string> response = await base.RequestAsync<ResourceWrapper<string>>(
                method: HttpMethod.Get,
                resource: "event",
                query: new SqlQuery { Fields = null, CustomParameters = new Dictionary<string, object> { { "as_list", true } } }
                );

            return response.Records;
        }
    }
}
