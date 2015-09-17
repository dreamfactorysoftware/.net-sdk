namespace DreamFactory.Api.Implementation
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DreamFactory.Http;
    using DreamFactory.Model;
    using DreamFactory.Model.Database;
    using DreamFactory.Model.System.Service;

    internal partial class SystemApi
    {
        public async Task<IEnumerable<ServiceResponse>> GetServicesAsync(SqlQuery query)
        {
            ResourceWrapper<ServiceResponse> response = await base.RequestAsync<ResourceWrapper<ServiceResponse>>(
                method: HttpMethod.Get,
                resource: "service",
                query: query
                );

            return response.Records;
        }

        public Task<IEnumerable<ServiceResponse>> CreateServicesAsync(SqlQuery query, params ServiceRequest[] services)
        {
            return base.RequestWithPayloadAsync<ServiceRequest, ServiceResponse>(
                method: HttpMethod.Post,
                resource: "service",
                query: query,
                payload: services
                );
        }

        public Task<IEnumerable<ServiceResponse>> UpdateServicesAsync(SqlQuery query, params ServiceRequest[] services)
        {
            return base.RequestWithPayloadAsync<ServiceRequest, ServiceResponse>(
                method: HttpMethod.Patch,
                resource: "service",
                query: query,
                payload: services
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
    }
}
