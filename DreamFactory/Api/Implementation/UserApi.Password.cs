namespace DreamFactory.Api.Implementation
{
    using System;
    using System.Threading.Tasks;
    using DreamFactory.Http;
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

            var address = baseAddress.WithResources("user", "password");
            PasswordRequest data = new PasswordRequest { old_password = oldPassword, new_password = newPassword };
            string content = contentSerializer.Serialize(data);
            IHttpRequest request = new HttpRequest(HttpMethod.Post, address.Build(), baseHeaders, content);

            IHttpResponse response = await httpFacade.SendAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            return contentSerializer.Deserialize<PasswordResponse>(response.Body).success ?? false;
        }

        public async Task<PasswordResponse> RequestPasswordResetAsync(string email)
        {
            if (email == null)
            {
                throw new ArgumentNullException("email");
            }

            var address = baseAddress.WithResources("user", "password").WithParameter("reset", true);
            PasswordRequest data = new PasswordRequest { email = email };
            string content = contentSerializer.Serialize(data);
            IHttpRequest request = new HttpRequest(HttpMethod.Post, address.Build(), baseHeaders, content);

            IHttpResponse response = await httpFacade.SendAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            return contentSerializer.Deserialize<PasswordResponse>(response.Body);
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

            var address = baseAddress.WithResources("user", "password").WithParameter("login", true);
            PasswordRequest data = new PasswordRequest { email = email, new_password = newPassword, code = code, security_answer = answer };
            string content = contentSerializer.Serialize(data);
            IHttpRequest request = new HttpRequest(HttpMethod.Post, address.Build(), baseHeaders, content);

            IHttpResponse response = await httpFacade.SendAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            bool success = contentSerializer.Deserialize<PasswordResponse>(response.Body).success ?? false;
            if (success)
            {
                Session session = await GetSessionAsync();
                baseHeaders.AddOrUpdate(HttpHeaders.DreamFactorySessionTokenHeader, session.session_id);
            }

            return success;
        }
    }
}
