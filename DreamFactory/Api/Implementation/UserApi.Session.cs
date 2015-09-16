namespace DreamFactory.Api.Implementation
{
    using System;
    using System.Threading.Tasks;
    using DreamFactory.Http;
    using DreamFactory.Model.User;

    internal partial class UserApi
    {
        public async Task<Session> LoginAsync(string email, string password, int duration)
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

            Session session = await base.RequestWithPayloadAsync<Login, Session>(
                method: HttpMethod.Post,
                resource: "session",
                query: null,
                payload: new Login { Email = email, Password = password, Duration = duration }
                );

            base.BaseHeaders.AddOrUpdate(HttpHeaders.DreamFactorySessionTokenHeader, session.SessionId);

            return session;
        }

        public Task<Session> GetSessionAsync()
        {
            return base.RequestAsync<Session>(
                method: HttpMethod.Get, 
                resource: "session", 
                query: null
                );
        }

        public async Task<bool> LogoutAsync()
        {
            Logout logout = await base.RequestAsync<Logout>(
                method: HttpMethod.Delete, 
                resource: "session", 
                query: null
                );

            if (logout.Success ?? false)
            {
                base.BaseHeaders.Delete(HttpHeaders.DreamFactorySessionTokenHeader);
            }

            return logout.Success ?? false;
        }
    }
}
