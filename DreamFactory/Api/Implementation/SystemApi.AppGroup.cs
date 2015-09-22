namespace DreamFactory.Api.Implementation
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DreamFactory.Http;
    using DreamFactory.Model;
    using DreamFactory.Model.Database;
    using DreamFactory.Model.System.AppGroup;

    internal partial class SystemApi
    {
        public async Task<IEnumerable<AppGroupResponse>> GetAppGroupsAsync(SqlQuery query)
        {
            ResourceWrapper<AppGroupResponse> response = await base.RequestAsync<ResourceWrapper<AppGroupResponse>>(
                method: HttpMethod.Get,
                resource: "app_group",
                query: query
                );

            return response.Records;
        }

        public Task<IEnumerable<AppGroupResponse>> CreateAppGroupsAsync(SqlQuery query, params AppGroupRequest[] appGroups)
        {
            return base.RequestWithPayloadAsync<AppGroupRequest, AppGroupResponse>(
                method: HttpMethod.Post,
                resource: "app_group",
                query: query,
                payload: appGroups
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

        public Task<IEnumerable<AppGroupResponse>> DeleteAppGroupsAsync(SqlQuery query, params int[] ids)
        {
            return base.RequestDeleteAsync<AppGroupResponse>(
                resource: "app_group",
                query: query,
                force: false,
                ids: ids
                );
        }
    }
}
