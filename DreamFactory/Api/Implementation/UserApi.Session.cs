namespace DreamFactory.Api.Implementation
{
    using System;
    using System.Threading.Tasks;
    using DreamFactory.Http;
    using DreamFactory.Model.Database;
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

            Session session = await CreateOrUpdateAsync<Login, Session>(
                HttpMethod.Post,
                new[] { "session" },
                new SqlQuery(),
                new Login { Email = email, Password = password, Duration = duration }
                );

            BaseHeaders.AddOrUpdate(HttpHeaders.DreamFactorySessionTokenHeader, session.SessionId);

            return session;
        }

        public async Task<Session> GetSessionAsync()
        {
            return await SingleAsync<Session>(new [] { "session" }, new SqlQuery());
        }

        public async Task<bool> LogoutAsync()
        {
            Logout logout = await DeleteAsync<Logout>(new[] { "session" }, new SqlQuery());

            if (logout.Success ?? false)
            {
                BaseHeaders.Delete(HttpHeaders.DreamFactorySessionTokenHeader);
            }

            return logout.Success ?? false;
        }
    }
}
