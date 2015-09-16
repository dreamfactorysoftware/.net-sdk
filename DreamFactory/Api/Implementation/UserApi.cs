namespace DreamFactory.Api.Implementation
{
    using System;
    using System.Threading.Tasks;
    using DreamFactory.Http;
    using DreamFactory.Model.Database;
    using DreamFactory.Model.User;
    using DreamFactory.Serialization;

    internal partial class UserApi : BaseApi, IUserApi
    {
        public UserApi(
            IHttpAddress baseAddress, 
            IHttpFacade httpFacade, 
            IContentSerializer contentSerializer, 
            HttpHeaders baseHeaders)
            : base(baseAddress, httpFacade, contentSerializer, baseHeaders, "user")
        {
        }

        public async Task<bool> RegisterAsync(Register register, bool login = false)
        {
            if (register == null)
            {
                throw new ArgumentNullException("register");
            }

            SqlQuery query = new SqlQuery { Fields = null };
            query.CustomParameters.Add("login", login);

            RegisterResponse response = await base.RequestWithPayloadAsync<Register, RegisterResponse>(
                method: HttpMethod.Post,
                resource: "register",
                query: query,
                payload: register
                );

            if ((response.Success ?? false) && login)
            {
                base.BaseHeaders.AddOrUpdate(HttpHeaders.DreamFactorySessionTokenHeader, response.SessionToken);
            }

            return response.Success ?? false;
        }

        public async Task<bool> UpdateProfileAsync(ProfileRequest profile)
        {
            if (profile == null)
            {
                throw new ArgumentNullException("profile");
            }

            ProfileUpdateResponse response = await base.RequestWithPayloadAsync<ProfileRequest, ProfileUpdateResponse>(
                method: HttpMethod.Post, 
                resource: "profile", 
                query: null, 
                payload: profile
                );
            return response.Success ?? false;
        }

        public Task<ProfileResponse> GetProfileAsync()
        {
            return base.RequestAsync<ProfileResponse>(
                method: HttpMethod.Get,
                resource: "profile", 
                query: new SqlQuery()
                );
        }
    }
}
