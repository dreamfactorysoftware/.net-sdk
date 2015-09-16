namespace DreamFactory.Api.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using DreamFactory.Http;
    using DreamFactory.Model.Database;
    using DreamFactory.Model.System.Custom;
    using DreamFactory.Serialization;

    internal class CustomSettingsApi : BaseApi, ICustomSettingsApi
    {
        public CustomSettingsApi(
            IHttpAddress baseAddress,
            IHttpFacade httpFacade,
            IContentSerializer contentSerializer,
            HttpHeaders baseHeaders,
            string serviceName)
            : base(baseAddress, httpFacade, contentSerializer, baseHeaders, serviceName)
        {
        }

        public async Task<ResourceWrapper<CustomResponse>> GetCustomSettingsAsync(SqlQuery query = null)
        {
            return await base.RequestSingleAsync<ResourceWrapper<CustomResponse>>(
                method: HttpMethod.Get,
                resource: "custom",
                query: query
                );
        }
        
        public async Task<ResourceWrapper<CustomResponse>> SetCustomSettingsAsync(List<CustomRequest> customs, SqlQuery query = null)
        {
            return await base.RequestSingleWithPayloadAsync<object, ResourceWrapper<CustomResponse>>(
                method: HttpMethod.Post,
                resource: "custom",
                query: query,
                record: new { resource = customs, ids = customs.Select((item, index) => index) }
                );
        }

        public async Task<ResourceWrapper<CustomResponse>> UpdateCustomSettingsAsync(List<CustomRequest> customs, SqlQuery query = null)
        {
            return await base.RequestSingleWithPayloadAsync<object, ResourceWrapper<CustomResponse>>(
                method: HttpMethod.Patch,
                resource: "custom",
                query: query,
                record: new { resource = customs, ids = customs.Select((item, index) => index) }
                );
        }

        public async Task<CustomResponse> GetCustomSettingAsync(string settingName)
        {
            if (settingName == null)
            {
                throw new ArgumentNullException("settingName");
            }

            string reponseBody = await base.RequestBodyAsync(
                method: HttpMethod.Get,
                resource: "custom",
                resourceIdentifier: settingName,
                query: null
                );

            return new CustomResponse
            {
                Name = settingName,
                Value = reponseBody
            };
        }

        public async Task<CustomResponse> UpdateCustomSettingAsync(string settingName, CustomRequest custom, SqlQuery query = null)
        {
            if (settingName == null)
            {
                throw new ArgumentNullException("settingName");
            }

            return await base.RequestSingleWithPayloadAsync<CustomRequest, CustomResponse>(
                method: HttpMethod.Patch, 
                resource: "custom", 
                resourceIdentifier: settingName, 
                query: query, 
                record: custom
                );
        }

        public async Task<CustomResponse> DeleteCustomSettingAsync(string settingName, SqlQuery query = null)
        {
            if (settingName == null)
            {
                throw new ArgumentNullException("settingName");
            }

            return await base.RequestSingleAsync<CustomResponse>(
                method: HttpMethod.Delete, 
                resource: "custom", 
                resourceIdentifier: settingName, 
                query: query
                );
        }
    }
}
