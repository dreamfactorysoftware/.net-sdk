namespace DreamFactory.Api.Implementation
{
    using System;
    using System.Threading.Tasks;
    using DreamFactory.Http;

    using CustomSetting = System.Collections.Generic.Dictionary<string, object>;
    using CustomSettings = System.Collections.Generic.Dictionary<string, System.Collections.Generic.Dictionary<string, object>>;
    
    internal partial class UserApi
    {
        public async Task<CustomSettings> GetCustomSettingsAsync()
        {
            var address = baseAddress.WithResources("user", "custom");
            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.SendAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            return contentSerializer.Deserialize<CustomSettings>(response.Body);
        }

        public async Task<bool> SetCustomSettingsAsync(CustomSettings customSettings)
        {
            if (customSettings == null)
            {
                throw new ArgumentNullException("customSettings");
            }

            var address = baseAddress.WithResources("user", "custom");
            string content = contentSerializer.Serialize(customSettings);
            IHttpRequest request = new HttpRequest(HttpMethod.Post, address.Build(), baseHeaders, content);

            IHttpResponse response = await httpFacade.SendAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            var success = new { success = false };
            return contentSerializer.Deserialize(response.Body, success).success;
        }

        public async Task<CustomSetting> GetCustomSettingAsync(string settingName)
        {
            if (settingName == null)
            {
                throw new ArgumentNullException("settingName");
            }

            var address = baseAddress.WithResources("user", "custom", settingName);
            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.SendAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            return contentSerializer.Deserialize<CustomSettings>(response.Body)[settingName];
        }

        public async Task<bool> DeleteCustomSettingAsync(string settingName)
        {
            if (settingName == null)
            {
                throw new ArgumentNullException("settingName");
            }

            var address = baseAddress.WithResources("user", "custom", settingName);
            IHttpRequest request = new HttpRequest(HttpMethod.Delete, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.SendAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            var success = new { success = false };
            return contentSerializer.Deserialize(response.Body, success).success;
        }
    }
}
