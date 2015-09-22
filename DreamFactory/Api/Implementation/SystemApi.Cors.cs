namespace DreamFactory.Api.Implementation
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DreamFactory.Http;
    using DreamFactory.Model;
    using DreamFactory.Model.Database;
    using DreamFactory.Model.System.Cors;

    internal partial class SystemApi
    {
        public async Task<IEnumerable<CorsResponse>> GetCorsAsync(SqlQuery query)
        {
            ResourceWrapper<CorsResponse> response = await base.RequestAsync<ResourceWrapper<CorsResponse>>(
                method: HttpMethod.Get,
                resource: "cors",
                query: query
                );

            return response.Records;
        }


        public Task<IEnumerable<CorsResponse>> CreateCorsAsync(SqlQuery query, params CorsRequest[] templates)
        {
            return base.RequestWithPayloadAsync<CorsRequest, CorsResponse>(
                method: HttpMethod.Post,
                resource: "cors",
                query: query,
                payload: templates
                );
        }

        public Task<IEnumerable<CorsResponse>> UpdateCorsAsync(SqlQuery query, params CorsRequest[] templates)
        {
            return base.RequestWithPayloadAsync<CorsRequest, CorsResponse>(
                method: HttpMethod.Patch,
                resource: "cors",
                query: query,
                payload: templates
                );
        }

        public Task<IEnumerable<CorsResponse>> DeleteCorsAsync(SqlQuery query, params int[] ids)
        {
            return base.RequestDeleteAsync<CorsResponse>(
                resource: "cors",
                query: query,
                force: false,
                ids: ids
                );
        }
    }
}
