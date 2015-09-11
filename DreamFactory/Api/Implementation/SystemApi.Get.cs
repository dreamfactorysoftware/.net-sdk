namespace DreamFactory.Api.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DreamFactory.Http;
    using DreamFactory.Model.Database;
    using DreamFactory.Model.System.App;
    using DreamFactory.Model.System.AppGroup;
    using DreamFactory.Model.System.Email;
    using DreamFactory.Model.System.Environment;
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

        public async Task<IEnumerable<RoleResponse>> GetRolesAsync(SqlQuery query)
        {
            return await QueryRecordsAsync<RoleResponse>("role", query);
        }

        public async Task<IEnumerable<UserResponse>> GetUsersAsync(SqlQuery query)
        {
            return await QueryRecordsAsync<UserResponse>("user", query);
        }

        public async Task<IEnumerable<ServiceResponse>> GetServicesAsync(SqlQuery query)
        {
            return await QueryRecordsAsync<ServiceResponse>("service", query);
        }

        public async Task<IEnumerable<EmailTemplateResponse>> GetEmailTemplatesAsync(SqlQuery query)
        {
            return await QueryRecordsAsync<EmailTemplateResponse>("email_template", query);
        }

        public async Task<IEnumerable<ScriptTypeResponse>> GetScriptTypesAsync(SqlQuery query)
        {
            return await QueryRecordsAsync<ScriptTypeResponse>("script_type", query);
        }

        public async Task<EnvironmentResponse> GetEnvironmentAsync()
        {
            IHttpAddress address = baseAddress.WithResource("environment");
            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            return contentSerializer.Deserialize<EnvironmentResponse>(response.Body);
        }

        public async Task<IEnumerable<string>> GetConstantsAsync()
        {
            IHttpAddress address = baseAddress.WithResource("constant");
            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            Dictionary<string, object> types = contentSerializer.Deserialize<Dictionary<string, object>>(response.Body);
            return types.Keys;
        }

        public async Task<Dictionary<string, string>> GetConstantAsync(string constant)
        {
            IHttpAddress address = baseAddress.WithResource("constant", constant);
            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            return contentSerializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(response.Body)[constant];
        }

        #region --- Helpers ---

        private async Task<IEnumerable<TResponseRecord>> QueryRecordsAsync<TResponseRecord>(string resource, SqlQuery query)
        {
            if (resource == null)
            {
                throw new ArgumentNullException("resource");
            }

            if (query == null)
            {
                throw new ArgumentNullException("query");
            }

            IHttpAddress address = baseAddress.WithResource(resource);
            address = address.WithSqlQuery(query);

            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), baseHeaders);
            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            var result = new { resource = new List<TResponseRecord>() };
            return contentSerializer.Deserialize(response.Body, result).resource;
        }

        private async Task<IEnumerable<TResponseRecord>> QueryRecordsWithParametersAsync<TResponseRecord>(string resource, params KeyValuePair<string, object>[] parameters)
        {
            if (resource == null)
            {
                throw new ArgumentNullException("resource");
            }

            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }

            IHttpAddress address = baseAddress.WithResource(resource);

            foreach (var keyValuePair in parameters)
            {
                address = address.WithParameter(keyValuePair.Key, keyValuePair.Value);
            }

            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), baseHeaders);
            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            var result = new { resource = new List<TResponseRecord>() };
            return contentSerializer.Deserialize(response.Body, result).resource;
        }

        #endregion
    }
}
