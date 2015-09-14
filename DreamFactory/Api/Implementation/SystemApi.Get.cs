namespace DreamFactory.Api.Implementation
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DreamFactory.Model.Database;
    using DreamFactory.Model.System.App;
    using DreamFactory.Model.System.AppGroup;
    using DreamFactory.Model.System.Email;
    using DreamFactory.Model.System.Role;
    using DreamFactory.Model.System.Script;
    using DreamFactory.Model.System.Service;
    using DreamFactory.Model.System.User;

    internal partial class SystemApi
    {
        public async Task<IEnumerable<AppResponse>> GetAppsAsync(SqlQuery query)
        {
            return await QueryRecordsAsync<AppResponse>("app", query);
        }

        public async Task<IEnumerable<AppGroupResponse>> GetAppGroupsAsync(SqlQuery query)
        {
            return await QueryRecordsAsync<AppGroupResponse>("app_group", query);
        }

        public async Task<IEnumerable<RoleResponse>> GetRolesAsync(SqlQuery query)
        {
            return await QueryRecordsAsync<RoleResponse>("role", query);
        }

        public async Task<IEnumerable<UserResponse>> GetUsersAsync(SqlQuery query)
        {
            return await QueryRecordsAsync<UserResponse>("user", query);
        }

        public async Task<IEnumerable<ServiceResponse>> GetServicesAsync(SqlQuery query)
        {
            return await QueryRecordsAsync<ServiceResponse>("service", query);
        }

        public async Task<IEnumerable<EmailTemplateResponse>> GetEmailTemplatesAsync(SqlQuery query)
        {
            return await QueryRecordsAsync<EmailTemplateResponse>("email_template", query);
        }

        public async Task<IEnumerable<ScriptTypeResponse>> GetScriptTypesAsync(SqlQuery query)
        {
            return await QueryRecordsAsync<ScriptTypeResponse>("script_type", query);
        }
    }
}
