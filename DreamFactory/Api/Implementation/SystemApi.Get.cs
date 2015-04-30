namespace DreamFactory.Api.Implementation
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DreamFactory.Http;
    using DreamFactory.Model.Database;
    using DreamFactory.Model.System.App;
    using DreamFactory.Model.System.AppGroup;
    using DreamFactory.Model.System.Email;
    using DreamFactory.Model.System.Environment;
    using DreamFactory.Model.System.Provider;
    using DreamFactory.Model.System.ProviderUser;
    using DreamFactory.Model.System.Role;
    using DreamFactory.Model.System.Script;
    using DreamFactory.Model.System.Service;
    using DreamFactory.Model.System.User;

    internal partial class SystemApi
    {
        public async Task<IEnumerable<AppResponse>> GetAppsAsync(SqlQuery query)
        {
            return await QueryRecordsAsync<AppResponse>("app", query);
        }

        public async Task<IEnumerable<AppGroupResponse>> GetAppGroupsAsync(SqlQuery query)
        {
            return await QueryRecordsAsync<AppGroupResponse>("app_group", query);
        }

        public async Task<IEnumerable<RoleResponse>> GetRolesAsync(SqlQuery query = null)
        {
            return await QueryRecordsAsync<RoleResponse>("role", query);
        }

        public async Task<IEnumerable<UserResponse>> GetUsersAsync(SqlQuery query = null)
        {
            return await QueryRecordsAsync<UserResponse>("user", query);
        }

        public async Task<IEnumerable<ServiceResponse>> GetServicesAsync(SqlQuery query = null)
        {
            return await QueryRecordsAsync<ServiceResponse>("service", query);
        }

        public async Task<IEnumerable<EmailTemplateResponse>> GetEmailTemplatesAsync(SqlQuery query = null)
        {
            return await QueryRecordsAsync<EmailTemplateResponse>("email_template", query);
        }

        public async Task<IEnumerable<ProviderResponse>> GetProvidersAsync(int? userId = null)
        {
            IHttpAddress address = baseAddress.WithResources("system", "provider");
            if (userId.HasValue)
            {
                address = address.WithParameter("user_id", userId.Value);
            }

            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            var apps = new { record = new List<ProviderResponse>() };
            return contentSerializer.Deserialize(response.Body, apps).record;
        }

        public async Task<IEnumerable<ProviderUserResponse>> GetProviderUserAsync(SqlQuery query = null)
        {
            return await QueryRecordsAsync<ProviderUserResponse>("provider_user", query);
        }

        public async Task<EnvironmentResponse> GetEnvironmentAsync()
        {
            IHttpAddress address = baseAddress.WithResources("system", "environment");
            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            return contentSerializer.Deserialize<EnvironmentResponse>(response.Body);
        }

        public async Task<IEnumerable<ScriptResponse>> GetScriptsAsync()
        {
            IHttpAddress address = baseAddress.WithResources("system", "script");
            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            var apps = new { script = new List<ScriptResponse>() };
            return contentSerializer.Deserialize(response.Body, apps).script;
        }

        #region --- Helpers ---

        private async Task<IEnumerable<TRecord>> QueryRecordsAsync<TRecord>(string resource, SqlQuery query)
        {
            IHttpAddress address = baseAddress.WithResources("system", resource);

            if (query != null)
            {
                address = address.WithParameter("filter", query.filter);

                if (query.limit.HasValue)
                {
                    address = address.WithParameter("limit", query.limit.Value);
                }

                if (query.offset.HasValue)
                {
                    address = address.WithParameter("offset", query.offset.Value);
                }

                if (!string.IsNullOrEmpty(query.order))
                {
                    address = address.WithParameter("order", query.order);
                }
            }

            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            var apps = new { record = new List<TRecord>() };
            return contentSerializer.Deserialize(response.Body, apps).record;
        }

        #endregion
    }
}
