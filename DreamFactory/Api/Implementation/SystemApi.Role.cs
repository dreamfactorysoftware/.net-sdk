namespace DreamFactory.Api.Implementation
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DreamFactory.Http;
    using DreamFactory.Model;
    using DreamFactory.Model.Database;
    using DreamFactory.Model.System.Role;

    internal partial class SystemApi
    {
        public async Task<IEnumerable<RoleResponse>> GetRolesAsync(SqlQuery query)
        {
            ResourceWrapper<RoleResponse> response = await base.RequestAsync<ResourceWrapper<RoleResponse>>(
                method: HttpMethod.Get,
                resource: "role",
                query: query
                );

            return response.Records;
        }

        public Task<IEnumerable<RoleResponse>> CreateRolesAsync(SqlQuery query, params RoleRequest[] roles)
        {
            return base.RequestWithPayloadAsync<RoleRequest, RoleResponse>(
                method: HttpMethod.Post,
                resource: "role",
                query: query,
                payload: roles
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

        public Task<IEnumerable<RoleResponse>> DeleteRolesAsync(SqlQuery query, params int[] ids)
        {
            return base.RequestDeleteAsync<RoleResponse>(
                resource: "role",
                query: query,
                force: false,
                ids: ids
                );
        }
    }
}
