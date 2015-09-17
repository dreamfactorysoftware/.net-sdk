namespace DreamFactory.Api.Implementation
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DreamFactory.Http;
    using DreamFactory.Model;
    using DreamFactory.Model.Database;
    using DreamFactory.Model.System.App;

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

        public Task<IEnumerable<AppResponse>> CreateAppsAsync(SqlQuery query, params AppRequest[] apps)
        {
            return base.RequestWithPayloadAsync<AppRequest, AppResponse>(
                method: HttpMethod.Post, 
                resource: "app", 
                query: query, 
                payload: apps
                );
        }

        public Task<IEnumerable<AppResponse>> UpdateAppsAsync(SqlQuery query, params AppRequest[] apps)
        {
            return base.RequestWithPayloadAsync<AppRequest, AppResponse>(
                method: HttpMethod.Patch,
                resource: "app",
                query: query,
                payload: apps
                );
        }

        public Task<IEnumerable<AppResponse>> DeleteAppsAsync(SqlQuery query, params int[] ids)
        {
            return base.RequestDeleteAsync<AppResponse>(
                resource: "app",
                query: query,
                force: false,
                ids: ids
                );
        }
    }
}
