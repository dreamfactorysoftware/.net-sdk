namespace DreamFactory.Api.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using DreamFactory.Http;
    using DreamFactory.Model.User;

    internal partial class UserApi
    {
        public async Task<IEnumerable<CustomSetting>> GetCustomSettingsAsync()
        {
            var address = baseAddress.WithResources("user", "custom");
            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.SendAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            var data = new { record = new List<CustomSetting>() };
            data = contentSerializer.Deserialize(response.Body, data);
            if (data == null || data.record == null)
            {
                return Enumerable.Empty<CustomSetting>();
            }

            return data.record;
        }

        public async Task<bool> SetCustomSettingsAsync(IEnumerable<CustomSetting> customSettings)
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

            return contentSerializer.Deserialize<CustomSetting>(response.Body);
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
