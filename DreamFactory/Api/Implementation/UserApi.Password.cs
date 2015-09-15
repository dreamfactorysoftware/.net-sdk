namespace DreamFactory.Api.Implementation
{
    using System;
    using System.Collections.Generic;
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

            PasswordResponse response = await RequestSingleWithPayloadAsync<PasswordRequest, PasswordResponse>(
                HttpMethod.Post, 
                new []{ "password" }, 
                new SqlQuery(),
                new PasswordRequest { OldPassword = oldPassword, NewPassword = newPassword });

            return response.Success ?? false;
        }

        public async Task<PasswordResponse> RequestPasswordResetAsync(string email)
        {
            if (email == null)
            {
                throw new ArgumentNullException("email");
            }

            return await RequestSingleWithPayloadAsync<PasswordRequest, PasswordResponse>(
                HttpMethod.Post,
                new[] { "password" },
                new SqlQuery { CustomParameters = new Dictionary<string, object> { { "reset", true } } },
                new PasswordRequest { Email = email });
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

            PasswordResponse response = await RequestSingleWithPayloadAsync<PasswordRequest, PasswordResponse>(
                HttpMethod.Post,
                new[] { "password" },
                new SqlQuery { CustomParameters = new Dictionary<string, object> { { "login", true } } }, 
                new PasswordRequest { Email = email, NewPassword = newPassword, Code = code, SecurityAnswer = answer });

            if (response.Success ?? false)
            {
                Session session = await GetSessionAsync();
                BaseHeaders.AddOrUpdate(HttpHeaders.DreamFactorySessionTokenHeader, session.SessionId);
            }

            return response.Success ?? false;
        }
    }
}
