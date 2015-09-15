namespace DreamFactory.Api.Implementation
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
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
        public Task<IEnumerable<AppResponse>>  DeleteAppsAsync(SqlQuery query, params int[] ids)
        {
            return DeleteAsync<AppResponse>("app", query, false, ids);
        }

        public Task<IEnumerable<AppGroupResponse>> DeleteAppGroupsAsync(SqlQuery query, params int[] ids)
        {
            return DeleteAsync<AppGroupResponse>("app_group", query, false, ids);
        }

        public Task<IEnumerable<RoleResponse>> DeleteRolesAsync(SqlQuery query, params int[] ids)
        {
            return DeleteAsync<RoleResponse>("role", query, false, ids);
        }

        public Task<IEnumerable<UserResponse>> DeleteUsersAsync(SqlQuery query, params int[] ids)
        {
            return DeleteAsync<UserResponse>("user", query, false, ids);
        }

        public Task<IEnumerable<ServiceResponse>> DeleteServicesAsync(SqlQuery query, params int[] ids)
        {
            return DeleteAsync<ServiceResponse>("service", query, false, ids);
        }

        public Task<IEnumerable<EmailTemplateResponse>> DeleteEmailTemplatesAsync(SqlQuery query, params int[] ids)
        {
            return DeleteAsync<EmailTemplateResponse>("email_template", query, false, ids);
        }

        public Task<EventScriptResponse> DeleteEventScriptAsync(string eventName, SqlQuery query)
        {
            return DeleteAsync<EventScriptResponse>("event", eventName, query);
        }
    }
}
