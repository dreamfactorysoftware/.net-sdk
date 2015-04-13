namespace DreamFactory.Api.Implementation
{
    using System.Threading.Tasks;
    using DreamFactory.Http;
    using DreamFactory.Model;
    using DreamFactory.Serialization;

    internal class UserSessionApi : IUserSessionApi
    {
        private readonly IHttpAddress httpAddress;
        private readonly IHttpFacade httpFacade;
        private readonly IContentSerializer contentSerializer;
        private readonly HttpHeaders baseHeaders;

        public UserSessionApi(IHttpAddress httpAddress, IHttpFacade httpFacade, IContentSerializer contentSerializer, HttpHeaders baseHeaders)
        {
            this.httpAddress = httpAddress.WithResources("user", "session");
            this.httpFacade = httpFacade;
            this.contentSerializer = contentSerializer;
            this.baseHeaders = baseHeaders;
        }

        public async Task<Session> LoginAsync(string applicationName, Login login)
        {
            baseHeaders.AddOrUpdate(HttpHeaders.DreamFactoryApplicationHeader, applicationName);

            string loginContent = contentSerializer.Serialize(login);
            IHttpRequest request = new HttpRequest(HttpMethod.Post,
                                                   httpAddress.Build(),
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
            IHttpRequest request = new HttpRequest(HttpMethod.Get,
                                                   httpAddress.Build(),
                                                   baseHeaders);

            IHttpResponse response = await httpFacade.SendAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            return contentSerializer.Deserialize<Session>(response.Body);
        }

        public async Task<Logout> LogoutAsync()
        {
            IHttpRequest request = new HttpRequest(HttpMethod.Delete, httpAddress.Build(), baseHeaders);
            
            IHttpResponse response = await httpFacade.SendAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            baseHeaders.Delete(HttpHeaders.DreamFactorySessionTokenHeader);

            return contentSerializer.Deserialize<Logout>(response.Body);
        }
    }
}
