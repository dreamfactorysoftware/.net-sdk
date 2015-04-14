namespace DreamFactory.Api.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DreamFactory.Http;
    using DreamFactory.Model;
    using DreamFactory.Model.User;
    using DreamFactory.Serialization;

    internal class UserApi : IUserApi
    {
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

            var address = baseAddress.WithResources("user", "register");
            if (login)
            {
                address = address.WithParameter("login", true);
            }

            string content = contentSerializer.Serialize(register);
            IHttpRequest request = new HttpRequest(HttpMethod.Post,
                                                   address.Build(),
                                                   baseHeaders,
                                                   content);

            IHttpResponse response = await httpFacade.SendAsync(request);
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

        public async Task<Session> LoginAsync(string applicationName, Login login)
        {
            if (applicationName == null)
            {
                throw new ArgumentNullException("applicationName");
            }

            if (login == null)
            {
                throw new ArgumentNullException("login");
            }

            var address = baseAddress.WithResources("user", "session");
            baseHeaders.AddOrUpdate(HttpHeaders.DreamFactoryApplicationHeader, applicationName);

            string loginContent = contentSerializer.Serialize(login);
            IHttpRequest request = new HttpRequest(HttpMethod.Post,
                                                   address.Build(),
                                                   baseHeaders,
                                                   loginContent);

            IHttpResponse response = await httpFacade.SendAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            Session session = contentSerializer.Deserialize<Session>(response.Body);
            baseHeaders.AddOrUpdate(HttpHeaders.DreamFactorySessionTokenHeader, session.session_id);

            return session;
        }

        public async Task<Session> GetSessionAsync()
        {
            var address = baseAddress.WithResources("user", "session");
            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), baseHeaders);
            IHttpResponse response = await httpFacade.SendAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            return contentSerializer.Deserialize<Session>(response.Body);
        }

        public async Task<bool> LogoutAsync()
        {
            var address = baseAddress.WithResources("user", "session");
            IHttpRequest request = new HttpRequest(HttpMethod.Delete, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.SendAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            baseHeaders.Delete(HttpHeaders.DreamFactorySessionTokenHeader);

            var logout = new { success = false };
            return contentSerializer.Deserialize(response.Body, logout).success;
        }

        public async Task<bool> UpdateProfileAsync(ProfileRequest profileRequest)
        {
            if (profileRequest == null)
            {
                throw new ArgumentNullException("profileRequest");
            }

            var address = baseAddress.WithResources("user", "profile");
            string content = contentSerializer.Serialize(profileRequest);
            IHttpRequest request = new HttpRequest(HttpMethod.Post, address.Build(), baseHeaders, content);

            IHttpResponse response = await httpFacade.SendAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            var success = new { success = false };
            return contentSerializer.Deserialize(response.Body, success).success;
        }

        public async Task<ProfileResponse> GetProfileAsync()
        {
            var address = baseAddress.WithResources("user", "profile");
            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.SendAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            return contentSerializer.Deserialize<ProfileResponse>(response.Body);
        }

        public async Task<bool> ChangePasswordAsync(string oldPassword, string newPassword)
        {
            if (oldPassword == null)
            {
                throw new ArgumentNullException("oldPassword");
            }

            if (newPassword == null)
            {
                throw new ArgumentNullException("newPassword");
            }

            var address = baseAddress.WithResources("user", "password");
            PasswordRequest data = new PasswordRequest { old_password = oldPassword, new_password = newPassword };
            string content = contentSerializer.Serialize(data);
            IHttpRequest request = new HttpRequest(HttpMethod.Post, address.Build(), baseHeaders, content);

            IHttpResponse response = await httpFacade.SendAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            return contentSerializer.Deserialize<PasswordResponse>(response.Body).success;
        }

        public async Task<PasswordResponse> RequestPasswordResetAsync(string email)
        {
            if (email == null)
            {
                throw new ArgumentNullException("email");
            }

            var address = baseAddress.WithResources("user", "password").WithParameter("reset", true);
            PasswordRequest data = new PasswordRequest { email = email };
            string content = contentSerializer.Serialize(data);
            IHttpRequest request = new HttpRequest(HttpMethod.Post, address.Build(), baseHeaders, content);

            IHttpResponse response = await httpFacade.SendAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            return contentSerializer.Deserialize<PasswordResponse>(response.Body);
        }

        public async Task<bool> CompletePasswordResetAsync(string email, string newPassword, string code, string answer)
        {
            if (email == null)
            {
                throw new ArgumentNullException("email");
            }

            if (newPassword == null)
            {
                throw new ArgumentNullException("newPassword");
            }

            if (code != null && answer != null)
            {
                throw new ArgumentException("You must specify either code or answer parameters but not both.", "answer");
            }

            var address = baseAddress.WithResources("user", "password").WithParameter("login", true);
            PasswordRequest data = new PasswordRequest { email = email, new_password = newPassword, code = code, security_answer = answer };
            string content = contentSerializer.Serialize(data);
            IHttpRequest request = new HttpRequest(HttpMethod.Post, address.Build(), baseHeaders, content);

            IHttpResponse response = await httpFacade.SendAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            bool success = contentSerializer.Deserialize<PasswordResponse>(response.Body).success;
            if (success)
            {
                Session session = await GetSessionAsync();
                baseHeaders.AddOrUpdate(HttpHeaders.DreamFactorySessionTokenHeader, session.session_id);
            }

            return success;
        }

        public async Task<IEnumerable<DeviceResponse>> GetDevicesAsync()
        {
            var address = baseAddress.WithResources("user", "device");
            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.SendAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            var data = new { record = new List<DeviceResponse>() };
            return contentSerializer.Deserialize(response.Body, data).record;
        }

        public async Task<bool> SetDeviceAsync(DeviceRequest deviceRequest)
        {
            if (deviceRequest == null)
            {
                throw new ArgumentNullException("deviceRequest");
            }

            var address = baseAddress.WithResources("user", "device");
            string content = contentSerializer.Serialize(deviceRequest);
            IHttpRequest request = new HttpRequest(HttpMethod.Post, address.Build(), baseHeaders, content);

            IHttpResponse response = await httpFacade.SendAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            var success = new { success = false };
            return contentSerializer.Deserialize(response.Body, success).success;
        }
    }
}
