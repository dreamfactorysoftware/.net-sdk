namespace DreamFactory.Api.Implementation
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DreamFactory.Http;
    using DreamFactory.Model;
    using DreamFactory.Model.Database;
    using DreamFactory.Model.System.User;

    internal partial class SystemApi
    {
        public async Task<IEnumerable<UserResponse>> GetUsersAsync(SqlQuery query)
        {
            ResourceWrapper<UserResponse> response = await base.RequestAsync<ResourceWrapper<UserResponse>>(
                method: HttpMethod.Get,
                resource: "user",
                query: query
                );

            return response.Records;
        }
        public Task<IEnumerable<UserResponse>> CreateUsersAsync(SqlQuery query, params UserRequest[] users)
        {
            return base.RequestWithPayloadAsync<UserRequest, UserResponse>(
                method: HttpMethod.Post,
                resource: "user",
                query: query,
                payload: users
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
        public Task<IEnumerable<UserResponse>> DeleteUsersAsync(SqlQuery query, params int[] ids)
        {
            return base.RequestDeleteAsync<UserResponse>(
                resource: "user",
                query: query,
                force: false,
                ids: ids
                );
        }
    }
}
