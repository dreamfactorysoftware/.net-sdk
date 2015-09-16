namespace DreamFactory.Api.Implementation
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DreamFactory.Http;
    using DreamFactory.Model;
    using DreamFactory.Model.Database;
    using DreamFactory.Model.System.Config;
    using DreamFactory.Model.System.Environment;
    using DreamFactory.Model.System.Script;
    using DreamFactory.Serialization;

    internal partial class SystemApi : BaseApi, ISystemApi
    {
        public SystemApi(
            IHttpAddress baseAddress, 
            IHttpFacade httpFacade, 
            IContentSerializer contentSerializer, 
            HttpHeaders baseHeaders)
            : base(baseAddress, httpFacade, contentSerializer, baseHeaders, "system")
        {
        }

        public Task<EnvironmentResponse> GetEnvironmentAsync()
        {
            return base.RequestAsync<EnvironmentResponse>(
                method: HttpMethod.Get,
                resource: "environment", 
                query: new SqlQuery()
                );
        }

        public async Task<IEnumerable<string>> GetConstantsAsync()
        {
            Dictionary<string, object> result = await base.RequestAsync<Dictionary<string, object>>(
                method: HttpMethod.Get, 
                resource: "constant", 
                query: new SqlQuery()
                );

            return result.Keys;
        }

        public async Task<Dictionary<string, string>> GetConstantAsync(string constant)
        {
            var result = await base.RequestAsync<Dictionary<string, Dictionary<string, string>>>(
                method: HttpMethod.Get,
                resource: "constant",
                resourceIdentifier: constant,
                query: new SqlQuery()
                );

            return result[constant];
        }

        public Task<ConfigResponse> GetConfigAsync()
        {
            return base.RequestAsync<ConfigResponse>(
                method: HttpMethod.Get,
                resource: "config",
                query: new SqlQuery()
                );
        }

        public Task<ConfigResponse> SetConfigAsync(ConfigRequest config)
        {
            return base.RequestWithPayloadAsync<ConfigRequest, ConfigResponse>(
                method: HttpMethod.Post,
                resource: "config",
                query: new SqlQuery(),
                payload: config
                );
        }

        public async Task<IEnumerable<ScriptTypeResponse>> GetScriptTypesAsync(SqlQuery query)
        {
            ResourceWrapper<ScriptTypeResponse> response = await base.RequestAsync<ResourceWrapper<ScriptTypeResponse>>(
                method: HttpMethod.Get,
                resource: "script_type", 
                query: query
                );

            return response.Records;
        }
    }
}
