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
    using DreamFactory.Model.System.Role;
    using DreamFactory.Model.System.Service;
    using DreamFactory.Model.System.User;

    internal partial class SystemApi
    {
        public async Task<IEnumerable<AppResponse>> CreateAppsAsync(SqlQuery query, params AppRequest[] apps)
        {
            IHttpResponse response = await CreateOrUpdateRecordsAsync(HttpMethod.Post, "app", query, apps);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            var responses = new { record = new List<AppResponse>() };
            return contentSerializer.Deserialize(response.Body, responses).record;
        }

        public async Task<IEnumerable<AppGroupResponse>> CreateAppGroupsAsync(SqlQuery query, params AppGroupRequest[] appGroups)
        {
            IHttpResponse response = await CreateOrUpdateRecordsAsync(HttpMethod.Post, "app_group", query, appGroups);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            var responses = new { record = new List<AppGroupResponse>() };
            return contentSerializer.Deserialize(response.Body, responses).record;
        }

        public async Task<IEnumerable<UserResponse>> CreateUsersAsync(SqlQuery query, params UserRequest[] users)
        {
            IHttpResponse response = await CreateOrUpdateRecordsAsync(HttpMethod.Post, "user", query, users);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            var responses = new { record = new List<UserResponse>() };
            return contentSerializer.Deserialize(response.Body, responses).record;
        }

        public async Task<IEnumerable<RoleResponse>> CreateRolesAsync(SqlQuery query, params RoleRequest[] roles)
        {
            IHttpResponse response = await CreateOrUpdateRecordsAsync(HttpMethod.Post, "role", query, roles);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            var responses = new { record = new List<RoleResponse>() };
            return contentSerializer.Deserialize(response.Body, responses).record;
        }

        public async Task<IEnumerable<ServiceResponse>> CreateServicesAsync(SqlQuery query, params ServiceRequest[] services)
        {
            IHttpResponse response = await CreateOrUpdateRecordsAsync(HttpMethod.Post, "service", query, services);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            var responses = new { record = new List<ServiceResponse>() };
            return contentSerializer.Deserialize(response.Body, responses).record;
        }

        public async Task<IEnumerable<EmailTemplateResponse>> CreateEmailTemplatesAsync(SqlQuery query, params EmailTemplateRequest[] templates)
        {
            IHttpResponse response = await CreateOrUpdateRecordsAsync(HttpMethod.Post, "email_template", query, templates);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            var responses = new { record = new List<EmailTemplateResponse>() };
            return contentSerializer.Deserialize(response.Body, responses).record;
        }

        #region --- Helpers ---

        private async Task<IHttpResponse> CreateOrUpdateRecordsAsync<TRecord>(HttpMethod method, string resource, SqlQuery query, params TRecord[] records)
        {
            if (query == null)
            {
                throw new ArgumentNullException("query");
            }

            if (records == null || records.Length < 1)
            {
                throw new ArgumentException("At least one parameter must be specificed", "records");
            }

            IHttpAddress address = baseAddress.WithResources(SystemService, resource);
            address = address.WithSqlQuery(query);

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
