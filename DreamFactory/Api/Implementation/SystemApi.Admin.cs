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

            IHttpAddress address = base.BaseAddress.WithResource("admin", "session");

            Login login = new Login { Email = email, Password = password, Duration = duration };
            string loginContent = base.ContentSerializer.Serialize(login);
            IHttpRequest request = new HttpRequest(HttpMethod.Post,
                                                   address.Build(),
                                                   base.BaseHeaders,
                                                   loginContent);

            IHttpResponse response = await base.HttpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, base.ContentSerializer);

            Session session = base.ContentSerializer.Deserialize<Session>(response.Body);
            base.BaseHeaders.AddOrUpdate(HttpHeaders.DreamFactorySessionTokenHeader, session.SessionId);

            return session;
        }
        public async Task<Session> GetAdminSessionAsync()
        {
            var address = base.BaseAddress.WithResource("admin", "session");
            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), base.BaseHeaders);
            IHttpResponse response = await base.HttpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, base.ContentSerializer);

            return base.ContentSerializer.Deserialize<Session>(response.Body);
        }

        public async Task<bool> LogoutAdminAsync()
        {
            IHttpAddress address = base.BaseAddress.WithResource("admin", "session");
            IHttpRequest request = new HttpRequest(HttpMethod.Delete, address.Build(), base.BaseHeaders);

            IHttpResponse response = await base.HttpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, base.ContentSerializer);

            base.BaseHeaders.Delete(HttpHeaders.DreamFactorySessionTokenHeader);

            var logout = new { success = false };
            return base.ContentSerializer.Deserialize(response.Body, logout).success;
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

            var address = base.BaseAddress.WithResource("admin", "password");
            PasswordRequest data = new PasswordRequest { OldPassword = oldPassword, NewPassword = newPassword };
            string content = base.ContentSerializer.Serialize(data);
            IHttpRequest request = new HttpRequest(HttpMethod.Post, address.Build(), base.BaseHeaders, content);

            IHttpResponse response = await base.HttpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, base.ContentSerializer);

            return base.ContentSerializer.Deserialize<PasswordResponse>(response.Body).Success ?? false;
        }
    }
}
