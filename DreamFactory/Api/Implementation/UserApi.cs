namespace DreamFactory.Api.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using DreamFactory.Http;
    using DreamFactory.Model.User;
    using DreamFactory.Serialization;

    internal partial class UserApi : IUserApi
    {
        private const string UserService = "user";

        private readonly IHttpAddress baseAddress;
        private readonly IHttpFacade httpFacade;
        private readonly IContentSerializer contentSerializer;
        private readonly HttpHeaders baseHeaders;

        public UserApi(IHttpAddress baseAddress, IHttpFacade httpFacade, IContentSerializer contentSerializer, HttpHeaders baseHeaders)
        {
            this.baseAddress = baseAddress;
            this.httpFacade = httpFacade;
            this.contentSerializer = contentSerializer;
            this.baseHeaders = baseHeaders;
        }

        public async Task<bool> RegisterAsync(Register register, bool login = false)
        {
            if (register == null)
            {
                throw new ArgumentNullException("register");
            }

            var address = baseAddress.WithResources(UserService, "register");
            if (login)
            {
                address = address.WithParameter("login", true);
            }

            string content = contentSerializer.Serialize(register);
            IHttpRequest request = new HttpRequest(HttpMethod.Post,
                                                   address.Build(),
                                                   baseHeaders,
                                                   content);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            var success = new { success = false };
            success = contentSerializer.Deserialize(response.Body, success);

            if (success.success && login)
            {
                Session session = await GetSessionAsync();
                baseHeaders.AddOrUpdate(HttpHeaders.DreamFactorySessionTokenHeader, session.session_id);
            }

            return success.success;
        }

        public async Task<bool> UpdateProfileAsync(ProfileRequest profileRequest)
        {
            if (profileRequest == null)
            {
                throw new ArgumentNullException("profileRequest");
            }

            var address = baseAddress.WithResources(UserService, "profile");
            string content = contentSerializer.Serialize(profileRequest);
            IHttpRequest request = new HttpRequest(HttpMethod.Post, address.Build(), baseHeaders, content);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            var success = new { success = false };
            return contentSerializer.Deserialize(response.Body, success).success;
        }

        public async Task<ProfileResponse> GetProfileAsync()
        {
            var address = baseAddress.WithResources(UserService, "profile");
            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            return contentSerializer.Deserialize<ProfileResponse>(response.Body);
        }

        public async Task<IEnumerable<DeviceResponse>> GetDevicesAsync()
        {
            var address = baseAddress.WithResources(UserService, "device");
            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            var data = new { record = new List<DeviceResponse>() };
            data = contentSerializer.Deserialize(response.Body, data);
            if (data == null || data.record == null)
            {
                return Enumerable.Empty<DeviceResponse>();
            }

            return data.record;
        }

        public async Task<bool> SetDeviceAsync(DeviceRequest deviceRequest)
        {
            if (deviceRequest == null)
            {
                throw new ArgumentNullException("deviceRequest");
            }

            var address = baseAddress.WithResources(UserService, "device");
            string content = contentSerializer.Serialize(deviceRequest);
            IHttpRequest request = new HttpRequest(HttpMethod.Post, address.Build(), baseHeaders, content);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            var success = new { success = false };
            return contentSerializer.Deserialize(response.Body, success).success;
        }
    }
}
