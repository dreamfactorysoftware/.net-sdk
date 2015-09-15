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
        public async Task<IEnumerable<AppResponse>> GetAppsAsync(SqlQuery query)
        {
            return await RequestGetMultiple<AppResponse>("app", query);
        }

        public async Task<IEnumerable<AppGroupResponse>> GetAppGroupsAsync(SqlQuery query)
        {
            return await RequestGetMultiple<AppGroupResponse>("app_group", query);
        }

        public async Task<IEnumerable<RoleResponse>> GetRolesAsync(SqlQuery query)
        {
            return await RequestGetMultiple<RoleResponse>("role", query);
        }

        public async Task<IEnumerable<UserResponse>> GetUsersAsync(SqlQuery query)
        {
            return await RequestGetMultiple<UserResponse>("user", query);
        }

        public async Task<IEnumerable<ServiceResponse>> GetServicesAsync(SqlQuery query)
        {
            return await RequestGetMultiple<ServiceResponse>("service", query);
        }

        public async Task<IEnumerable<EmailTemplateResponse>> GetEmailTemplatesAsync(SqlQuery query)
        {
            return await RequestGetMultiple<EmailTemplateResponse>("email_template", query);
        }

        public Task<EventScriptResponse> GetEventScriptAsync(string eventName, SqlQuery query)
        {
            return RequestSingleAsync<EventScriptResponse>(HttpMethod.Get, "event", eventName, query);
        }

        public Task<IEnumerable<string>> GetEventsAsync()
        {
            return RequestGetMultiple<string>("event", new SqlQuery { CustomParameters = new Dictionary<string, object> { { "as_list", true } } });
        }
    }
}
