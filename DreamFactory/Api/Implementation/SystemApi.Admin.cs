namespace DreamFactory.Api.Implementation
{
    using System;
    using System.Threading.Tasks;
    using DreamFactory.Http;
    using DreamFactory.Model.Database;
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

            Session session = await base.RequestSingleWithPayloadAsync<Login, Session>(
                method: HttpMethod.Post,
                resource: "admin",
                resourceIdentifier: "session",
                query: new SqlQuery(),
                record: new Login { Email = email, Password = password, Duration = duration }
                );

            base.BaseHeaders.AddOrUpdate(HttpHeaders.DreamFactorySessionTokenHeader, session.SessionId);
            return session;
        }
        public async Task<Session> GetAdminSessionAsync()
        {
            return await base.RequestSingleAsync<Session>(HttpMethod.Get, new[] { "admin", "session" }, new SqlQuery());
        }

        public async Task<bool> LogoutAdminAsync()
        {
            Logout logout = await RequestSingleAsync<Logout>(HttpMethod.Delete, new[] { "admin", "session" }, new SqlQuery());

            if (logout.Success.HasValue && logout.Success.Value)
            {
                base.BaseHeaders.Delete(HttpHeaders.DreamFactorySessionTokenHeader);
            }

            return logout.Success ?? false;
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

            PasswordResponse response = await base.RequestSingleWithPayloadAsync<PasswordRequest, PasswordResponse>(HttpMethod.Post, "admin", "password",
                new SqlQuery(), new PasswordRequest { OldPassword = oldPassword, NewPassword = newPassword });

            return response.Success ?? false;
        }
    }
}
