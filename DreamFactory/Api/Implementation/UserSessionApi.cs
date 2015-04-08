namespace DreamFactory.Api.Implementation
{
    using System.Threading.Tasks;
    using DreamFactory.Http;
    using DreamFactory.Model;
    using DreamFactory.Serialization;

    internal class UserSessionApi : IUserSessionApi
    {
        private readonly HttpAddress httpAddress;
        private readonly IHttpFacade httpFacade;
        private readonly IObjectSerializer objectSerializer;
        private readonly HttpHeaders baseHeaders;

        public UserSessionApi(HttpAddress httpAddress, IHttpFacade httpFacade, IObjectSerializer objectSerializer, HttpHeaders baseHeaders)
        {
            this.httpAddress = httpAddress.WithResources("user", "session");
            this.httpFacade = httpFacade;
            this.objectSerializer = objectSerializer;
            this.baseHeaders = baseHeaders;
        }

        public async Task<Session> LoginAsync(string applicationName, Login login)
        {
            baseHeaders.Override(HttpHeaders.DreamFactoryApplicationHeader, applicationName);

            string loginContent = objectSerializer.Serialize(login);
            IHttpRequest request = new HttpRequest(HttpMethod.Post,
                                                   httpAddress.Build(),
                                                   baseHeaders,
                                                   loginContent);

            IHttpResponse response = await httpFacade.SendAsync(request);
            HttpUtils.ThrowOnBadStatus(response, objectSerializer);

            Session session = objectSerializer.Deserialize<Session>(response.Body);
            baseHeaders.Override(HttpHeaders.DreamFactorySessionTokenHeader, session.session_id);

            return session;
        }

        public async Task<Logout> LogoutAsync()
        {
            IHttpRequest request = new HttpRequest(HttpMethod.Delete, httpAddress.Build(), baseHeaders);
            
            IHttpResponse response = await httpFacade.SendAsync(request);
            HttpUtils.ThrowOnBadStatus(response, objectSerializer);

            baseHeaders.Override(HttpHeaders.DreamFactorySessionTokenHeader);

            return objectSerializer.Deserialize<Logout>(response.Body);
        }
    }
}
