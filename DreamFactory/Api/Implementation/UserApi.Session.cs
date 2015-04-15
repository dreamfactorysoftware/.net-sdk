namespace DreamFactory.Api.Implementation
{
    using System;
    using System.Threading.Tasks;
    using DreamFactory.Http;
    using DreamFactory.Model.User;

    internal partial class UserApi
    {
        public async Task<Session> LoginAsync(string applicationName, string email, string password, int duration)
        {
            if (applicationName == null)
            {
                throw new ArgumentNullException("applicationName");
            }

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

            var address = baseAddress.WithResources("user", "session");
            baseHeaders.AddOrUpdate(HttpHeaders.DreamFactoryApplicationHeader, applicationName);

            Login login = new Login { email = email, password = password, duration = duration };
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
    }
}
