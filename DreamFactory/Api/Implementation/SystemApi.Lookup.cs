namespace DreamFactory.Api.Implementation
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DreamFactory.Http;
    using DreamFactory.Model;
    using DreamFactory.Model.Database;
    using DreamFactory.Model.System.Lookup;

    internal partial class SystemApi
    {
        public async Task<IEnumerable<LookupResponse>> GetLookupsAsync(SqlQuery query)
        {
            ResourceWrapper<LookupResponse> response = await base.RequestAsync<ResourceWrapper<LookupResponse>>(
                method: HttpMethod.Get,
                resource: "lookup",
                query: query
                );

            return response.Records;
        }

        public Task<IEnumerable<LookupResponse>> CreateLookupsAsync(SqlQuery query, params LookupRequest[] Lookups)
        {
            return base.RequestWithPayloadAsync<LookupRequest, LookupResponse>(
                method: HttpMethod.Post,
                resource: "lookup",
                query: query,
                payload: Lookups
                );
        }

        public Task<IEnumerable<LookupResponse>> UpdateLookupsAsync(SqlQuery query, params LookupRequest[] Lookups)
        {
            return base.RequestWithPayloadAsync<LookupRequest, LookupResponse>(
                method: HttpMethod.Patch,
                resource: "lookup",
                query: query,
                payload: Lookups
                );
        }

        public Task<IEnumerable<LookupResponse>> DeleteLookupsAsync(SqlQuery query, params int[] ids)
        {
            return base.RequestDeleteAsync<LookupResponse>(
                resource: "Lookup",
                query: query,
                force: false,
                ids: ids
                );
        }
    }
}
