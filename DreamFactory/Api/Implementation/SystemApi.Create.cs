namespace DreamFactory.Api.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DreamFactory.Http;
    using DreamFactory.Model.System.App;
    using DreamFactory.Model.System.Email;
    using DreamFactory.Model.System.Provider;
    using DreamFactory.Model.System.ProviderUser;
    using DreamFactory.Model.System.Role;
    using DreamFactory.Model.System.Service;
    using DreamFactory.Model.System.User;

    internal partial class SystemApi
    {
        public async Task<IEnumerable<AppResponse>> CreateAppsAsync(params AppRequest[] apps)
        {
            IHttpResponse response = await CreateOrUpdateRecordsAsync(HttpMethod.Post, "app", apps);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            var responses = new { record = new List<AppResponse>() };
            return contentSerializer.Deserialize(response.Body, responses).record;
        }

        public async Task<IEnumerable<UserResponse>> CreateUsersAsync(params UserRequest[] users)
        {
            IHttpResponse response = await CreateOrUpdateRecordsAsync(HttpMethod.Post, "user", users);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            var responses = new { record = new List<UserResponse>() };
            return contentSerializer.Deserialize(response.Body, responses).record;
        }

        public async Task<IEnumerable<RoleResponse>> CreateRolesAsync(params RoleRequest[] roles)
        {
            IHttpResponse response = await CreateOrUpdateRecordsAsync(HttpMethod.Post, "roles", roles);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            var responses = new { record = new List<RoleResponse>() };
            return contentSerializer.Deserialize(response.Body, responses).record;
        }

        public async Task<IEnumerable<ServiceResponse>> CreateServicesAsync(params ServiceRequest[] services)
        {
            IHttpResponse response = await CreateOrUpdateRecordsAsync(HttpMethod.Post, "services", services);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            var responses = new { record = new List<ServiceResponse>() };
            return contentSerializer.Deserialize(response.Body, responses).record;
        }

        public async Task<IEnumerable<EmailTemplateResponse>> CreateEmailTemplatesAsync(params EmailTemplateRequest[] templates)
        {
            IHttpResponse response = await CreateOrUpdateRecordsAsync(HttpMethod.Post, "email_template", templates);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            var responses = new { record = new List<EmailTemplateResponse>() };
            return contentSerializer.Deserialize(response.Body, responses).record;
        }

        public async Task<IEnumerable<ProviderResponse>> CreateProvidersAsync(params ProviderRequest[] providers)
        {
            IHttpResponse response = await CreateOrUpdateRecordsAsync(HttpMethod.Post, "provider", providers);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            var responses = new { record = new List<ProviderResponse>() };
            return contentSerializer.Deserialize(response.Body, responses).record;
        }

        public async Task<IEnumerable<ProviderUserResponse>> CreateProviderUsersAsync(params ProviderUserRequest[] providerUsers)
        {
            IHttpResponse response = await CreateOrUpdateRecordsAsync(HttpMethod.Post, "provider_user", providerUsers);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            var responses = new { record = new List<ProviderUserResponse>() };
            return contentSerializer.Deserialize(response.Body, responses).record;
        }

        #region --- Helpers ---

        private async Task<IHttpResponse> CreateOrUpdateRecordsAsync<TRecord>(HttpMethod method, string resource, params TRecord[] records)
        {
            if (records == null || records.Length < 1)
            {
                throw new ArgumentException("At least one parameter must be specificed", "records");
            }

            IHttpAddress address = baseAddress.WithResources(SystemService, resource);
            var requests = new { record = new List<TRecord>(records) };
            string body = contentSerializer.Serialize(requests);
            IHttpRequest request = new HttpRequest(method, address.Build(), baseHeaders, body);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            return response;
        }

        #endregion
    }
}
