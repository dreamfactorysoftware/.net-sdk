namespace DreamFactory.Api.Implementation
{
    using System;
    using System.Threading.Tasks;
    using DreamFactory.Http;
    using DreamFactory.Model.User;

    internal partial class SystemApi
    {
        public async Task<Session> LoginAdminAsync(string email, string password, int duration = 0)
        {
            if (email == null)
            {
                throw new ArgumentNullException("email");
            }

            if (password == null)
            {
                throw new ArgumentNullException("password");
            }

            if (duration < 0)
            {
                throw new ArgumentOutOfRangeException("duration");
            }

            IHttpAddress address = baseAddress.WithResource("admin", "session");

            Login login = new Login { Email = email, Password = password, Duration = duration };
            string loginContent = contentSerializer.Serialize(login);
            IHttpRequest request = new HttpRequest(HttpMethod.Post,
                                                   address.Build(),
                                                   baseHeaders,
                                                   loginContent);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            Session session = contentSerializer.Deserialize<Session>(response.Body);
            baseHeaders.AddOrUpdate(HttpHeaders.DreamFactorySessionTokenHeader, session.SessionId);

            return session;
        }
        public async Task<Session> GetAdminSessionAsync()
        {
            var address = baseAddress.WithResource("admin", "session");
            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), baseHeaders);
            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            return contentSerializer.Deserialize<Session>(response.Body);
        }

        public async Task<bool> LogoutAdminAsync()
        {
            IHttpAddress address = baseAddress.WithResource("admin", "session");
            IHttpRequest request = new HttpRequest(HttpMethod.Delete, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            baseHeaders.Delete(HttpHeaders.DreamFactorySessionTokenHeader);

            var logout = new { success = false };
            return contentSerializer.Deserialize(response.Body, logout).success;
        }

        public async Task<bool> ChangeAdminPasswordAsync(string oldPassword, string newPassword)
        {
            if (oldPassword == null)
            {
                throw new ArgumentNullException("oldPassword");
            }

            if (newPassword == null)
            {
                throw new ArgumentNullException("newPassword");
            }

            var address = baseAddress.WithResource("admin", "password");
            PasswordRequest data = new PasswordRequest { OldPassword = oldPassword, NewPassword = newPassword };
            string content = contentSerializer.Serialize(data);
            IHttpRequest request = new HttpRequest(HttpMethod.Post, address.Build(), baseHeaders, content);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            return contentSerializer.Deserialize<PasswordResponse>(response.Body).Success ?? false;
        }
    }
}
