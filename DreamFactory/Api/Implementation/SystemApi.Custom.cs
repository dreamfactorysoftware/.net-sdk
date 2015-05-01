namespace DreamFactory.Api.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DreamFactory.Http;

    internal partial class SystemApi
    {
        public async Task<IEnumerable<string>> GetCustomSettingsAsync()
        {
            var address = baseAddress.WithResources("system", "custom");
            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            Dictionary<string, object> settings = new Dictionary<string, object>();
            return contentSerializer.Deserialize(response.Body, settings).Keys;
        }

        public async Task<bool> SetCustomSettingAsync<TEntity>(string settingName, TEntity entity)
            where TEntity : class, new()
        {
            if (settingName == null)
            {
                throw new ArgumentNullException("settingName");
            }

            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            var address = baseAddress.WithResources("system", "custom");

            Dictionary<string, TEntity> setting = new Dictionary<string, TEntity> { { settingName, entity } };
            string content = contentSerializer.Serialize(setting);
            IHttpRequest request = new HttpRequest(HttpMethod.Post, address.Build(), baseHeaders, content);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            var success = new { success = false };
            return contentSerializer.Deserialize(response.Body, success).success;
        }

        public async Task<TEntity> GetCustomSettingAsync<TEntity>(string settingName)
            where TEntity : class, new()
        {
            if (settingName == null)
            {
                throw new ArgumentNullException("settingName");
            }

            var address = baseAddress.WithResources("system", "custom", settingName);
            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            Dictionary<string, TEntity> settings = new Dictionary<string, TEntity>();
            return contentSerializer.Deserialize(response.Body, settings)[settingName];
        }

        public async Task<bool> DeleteCustomSettingAsync(string settingName)
        {
            if (settingName == null)
            {
                throw new ArgumentNullException("settingName");
            }

            var address = baseAddress.WithResources("system", "custom", settingName);
            IHttpRequest request = new HttpRequest(HttpMethod.Delete, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            var success = new { success = false };
            return contentSerializer.Deserialize(response.Body, success).success;
        }
    }
}
