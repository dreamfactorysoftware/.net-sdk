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
        public Task<IEnumerable<AppResponse>>  DeleteAppsAsync(SqlQuery query, params int[] ids)
        {
            return base.RequestDeleteAsync<AppResponse>(
                resource: "app",
                query: query, 
                force: false, 
                ids: ids
                );
        }

        public Task<IEnumerable<AppGroupResponse>> DeleteAppGroupsAsync(SqlQuery query, params int[] ids)
        {
            return base.RequestDeleteAsync<AppGroupResponse>(
                resource: "app_group",
                query: query,
                force: false,
                ids: ids
                );
        }

        public Task<IEnumerable<RoleResponse>> DeleteRolesAsync(SqlQuery query, params int[] ids)
        {
            return base.RequestDeleteAsync<RoleResponse>(
                resource: "role",
                query: query,
                force: false,
                ids: ids
                );
        }

        public Task<IEnumerable<UserResponse>> DeleteUsersAsync(SqlQuery query, params int[] ids)
        {
            return base.RequestDeleteAsync<UserResponse>(
                resource: "user",
                query: query,
                force: false,
                ids: ids
                );
        }

        public Task<IEnumerable<ServiceResponse>> DeleteServicesAsync(SqlQuery query, params int[] ids)
        {
            return base.RequestDeleteAsync<ServiceResponse>(
                resource: "service",
                query: query,
                force: false,
                ids: ids
                );
        }

        public Task<IEnumerable<EmailTemplateResponse>> DeleteEmailTemplatesAsync(SqlQuery query, params int[] ids)
        {
            return base.RequestDeleteAsync<EmailTemplateResponse>(
                resource: "email_template",
                query: query,
                force: false,
                ids: ids
                );
        }

        public Task<EventScriptResponse> DeleteEventScriptAsync(string eventName, SqlQuery query)
        {
            return base.RequestAsync<EventScriptResponse>(
                method: HttpMethod.Delete,
                resource: "event", 
                resourceIdentifier: eventName, 
                query: query
                );
        }
    }
}
