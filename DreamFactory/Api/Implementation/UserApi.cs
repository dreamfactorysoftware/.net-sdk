namespace DreamFactory.Api.Implementation
{
    using System;
    using System.Threading.Tasks;
    using DreamFactory.Http;
    using DreamFactory.Model.User;
    using DreamFactory.Serialization;

    internal partial class UserApi : IUserApi
    {
        private readonly IHttpAddress baseAddress;
        private readonly IHttpFacade httpFacade;
        private readonly IContentSerializer contentSerializer;
        private readonly HttpHeaders baseHeaders;

        public UserApi(IHttpAddress baseAddress, IHttpFacade httpFacade, IContentSerializer contentSerializer, HttpHeaders baseHeaders)
        {
            this.baseAddress = baseAddress.WithResource("user");
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

            var address = baseAddress.WithResource("register");
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
                baseHeaders.AddOrUpdate(HttpHeaders.DreamFactorySessionTokenHeader, session.SessionId);
            }

            return success.success;
        }

        public async Task<bool> UpdateProfileAsync(ProfileRequest profileRequest)
        {
            if (profileRequest == null)
            {
                throw new ArgumentNullException("profileRequest");
            }

            var address = baseAddress.WithResource("profile");
            string content = contentSerializer.Serialize(profileRequest);
            IHttpRequest request = new HttpRequest(HttpMethod.Post, address.Build(), baseHeaders, content);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            var success = new { success = false };
            return contentSerializer.Deserialize(response.Body, success).success;
        }

        public async Task<ProfileResponse> GetProfileAsync()
        {
            var address = baseAddress.WithResource("profile");
            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            return contentSerializer.Deserialize<ProfileResponse>(response.Body);
        }
    }
}
