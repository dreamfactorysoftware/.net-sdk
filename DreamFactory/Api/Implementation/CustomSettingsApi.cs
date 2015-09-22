namespace DreamFactory.Api.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using DreamFactory.Http;
    using DreamFactory.Model;
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

        public Task<ResourceWrapper<CustomResponse>> GetCustomSettingsAsync(SqlQuery query = null)
        {
            return base.RequestAsync<ResourceWrapper<CustomResponse>>(
                method: HttpMethod.Get,
                resource: "custom",
                query: query
                );
        }
        
        public Task<ResourceWrapper<CustomResponse>> SetCustomSettingsAsync(List<CustomRequest> customs, SqlQuery query = null)
        {
            return base.RequestWithPayloadAsync<RequestResourceWrapper<CustomRequest>, ResourceWrapper<CustomResponse>>(
                method: HttpMethod.Post,
                resource: "custom",
                query: query,
                payload: new RequestResourceWrapper<CustomRequest> { Records = customs, Ids = customs.Select((item, index) => (int?)index).ToArray() }
                );
        }

        public Task<ResourceWrapper<CustomResponse>> UpdateCustomSettingsAsync(List<CustomRequest> customs, SqlQuery query = null)
        {
            return base.RequestWithPayloadAsync<RequestResourceWrapper<CustomRequest>, ResourceWrapper<CustomResponse>>(
                method: HttpMethod.Patch,
                resource: "custom",
                query: query,
                payload: new RequestResourceWrapper<CustomRequest> { Records = customs, Ids = customs.Select((item, index) => (int?)index).ToArray() }
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

        public Task<CustomResponse> UpdateCustomSettingAsync(string settingName, CustomRequest custom, SqlQuery query = null)
        {
            if (settingName == null)
            {
                throw new ArgumentNullException("settingName");
            }

            return base.RequestWithPayloadAsync<CustomRequest, CustomResponse>(
                method: HttpMethod.Patch, 
                resource: "custom", 
                resourceIdentifier: settingName, 
                query: query, 
                payload: custom
                );
        }

        public Task<CustomResponse> DeleteCustomSettingAsync(string settingName, SqlQuery query = null)
        {
            if (settingName == null)
            {
                throw new ArgumentNullException("settingName");
            }

            return base.RequestAsync<CustomResponse>(
                method: HttpMethod.Delete, 
                resource: "custom", 
                resourceIdentifier: settingName, 
                query: query
                );
        }
    }
}
