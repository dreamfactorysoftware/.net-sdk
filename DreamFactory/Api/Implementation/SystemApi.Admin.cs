namespace DreamFactory.Api.Implementation
{
    using System;
    using System.Threading.Tasks;
    using DreamFactory.Http;
    using DreamFactory.Model.User;

    internal partial class SystemApi
    {
        public async Task<Session> LoginAdminAsync(string applicationName, string applicationApiKey, string email, string password, int duration = 0)
        {
            if (applicationName == null)
            {
                throw new ArgumentNullException("applicationName");
            }

            if (applicationName == null)
            {
                throw new ArgumentNullException("applicationApiKey");
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

            var address = baseAddress.WithResource("admin").WithResource("session");
            baseHeaders.Include(HttpHeaders.FolderNameHeader, applicationName);
            baseHeaders.Include(HttpHeaders.DreamFactoryApiKeyHeader, applicationApiKey);

            Login login = new Login { Email = email, Password = password, Duration = duration };
            string loginContent = contentSerializer.Serialize(login);
            IHttpRequest request = new HttpRequest(HttpMethod.Post,
                                                   address.Build(),
                                                   baseHeaders,
                                                   loginContent);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            Session session = contentSerializer.Deserialize<Session>(response.Body);
            baseHeaders.Include(HttpHeaders.DreamFactorySessionTokenHeader, session.SessionId);

            return session;
        }
    }
}
