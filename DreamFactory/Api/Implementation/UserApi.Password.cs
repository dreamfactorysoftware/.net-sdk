namespace DreamFactory.Api.Implementation
{
    using System;
    using System.Threading.Tasks;
    using DreamFactory.Http;
    using DreamFactory.Model.Database;
    using DreamFactory.Model.User;

    internal partial class UserApi
    {
        public async Task<bool> ChangePasswordAsync(string oldPassword, string newPassword)
        {
            if (oldPassword == null)
            {
                throw new ArgumentNullException("oldPassword");
            }

            if (newPassword == null)
            {
                throw new ArgumentNullException("newPassword");
            }

            PasswordResponse response = await RequestWithPayloadAsync<PasswordRequest, PasswordResponse>(
                method: HttpMethod.Post, 
                resource: "password", 
                query: null,
                payload: new PasswordRequest { OldPassword = oldPassword, NewPassword = newPassword }
                );

            return response.Success ?? false;
        }

        public Task<PasswordResponse> RequestPasswordResetAsync(string email)
        {
            if (email == null)
            {
                throw new ArgumentNullException("email");
            }

            SqlQuery query = new SqlQuery { Fields = null };
            query.CustomParameters.Add("reset", true);

            return RequestWithPayloadAsync<PasswordRequest, PasswordResponse>(
                method: HttpMethod.Post,
                resource: "password",
                query: query,
                payload: new PasswordRequest { Email = email }
            );
        }

        public async Task<bool> CompletePasswordResetAsync(string email, string newPassword, string code, string answer)
        {
            if (email == null)
            {
                throw new ArgumentNullException("email");
            }

            if (newPassword == null)
            {
                throw new ArgumentNullException("newPassword");
            }

            if (code != null && answer != null)
            {
                throw new ArgumentException("You must specify either code or answer parameters but not both.", "answer");
            }

            SqlQuery query = new SqlQuery { Fields = null };
            query.CustomParameters.Add("login", true);

            PasswordResponse response = await RequestWithPayloadAsync<PasswordRequest, PasswordResponse>(
                method: HttpMethod.Post,
                resource: "password",
                query: query, 
                payload: new PasswordRequest { Email = email, NewPassword = newPassword, Code = code, SecurityAnswer = answer }
                );

            if (response.Success ?? false)
            {
                Session session = await GetSessionAsync();
                BaseHeaders.AddOrUpdate(HttpHeaders.DreamFactorySessionTokenHeader, session.SessionId);
            }

            return response.Success ?? false;
        }
    }
}
