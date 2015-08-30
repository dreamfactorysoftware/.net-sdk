namespace DreamFactory.Api.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using DreamFactory.Http;
    using DreamFactory.Model;
    using DreamFactory.Model.Database;
    using DreamFactory.Model.System.App;
    using DreamFactory.Model.System.AppGroup;
    using DreamFactory.Model.System.Email;
    using DreamFactory.Model.System.Role;
    using DreamFactory.Model.System.Service;
    using DreamFactory.Model.System.User;

    internal partial class SystemApi
    {
        public Task<IEnumerable<AppResponse>> CreateAppsAsync(SqlQuery query, params AppRequest[] apps)
        {
            return CreateOrUpdateRecordsAsync<AppRequest, AppResponse>(HttpMethod.Post, "app", query, apps);
        }

        public Task<IEnumerable<AppGroupResponse>> CreateAppGroupsAsync(SqlQuery query, params AppGroupRequest[] appGroups)
        {
            return CreateOrUpdateRecordsAsync<AppGroupRequest, AppGroupResponse>(HttpMethod.Post, "app_group", query, appGroups);
        }

        public Task<IEnumerable<UserResponse>> CreateUsersAsync(SqlQuery query, params UserRequest[] users)
        {
            return CreateOrUpdateRecordsAsync<UserRequest, UserResponse>(HttpMethod.Post, "user", query, users);
        }

        public Task<IEnumerable<RoleResponse>> CreateRolesAsync(SqlQuery query, params RoleRequest[] roles)
        {
            return CreateOrUpdateRecordsAsync<RoleRequest, RoleResponse>(HttpMethod.Post, "role", query, roles);
        }

        public Task<IEnumerable<ServiceResponse>> CreateServicesAsync(SqlQuery query, params ServiceRequest[] services)
        {
            return CreateOrUpdateRecordsAsync<ServiceRequest, ServiceResponse>(HttpMethod.Post, "service", query, services);
        }

        public Task<IEnumerable<EmailTemplateResponse>> CreateEmailTemplatesAsync(SqlQuery query, params EmailTemplateRequest[] templates)
        {
            return CreateOrUpdateRecordsAsync<EmailTemplateRequest, EmailTemplateResponse>(HttpMethod.Post, "email_template", query, templates);
        }

        #region --- Helpers ---

        private async Task<IEnumerable<TResponseRecord>> CreateOrUpdateRecordsAsync<TRequestRecord, TResponseRecord>(HttpMethod method, string resource, SqlQuery query, params TRequestRecord[] records)
            where TRequestRecord : IRecord
            where TResponseRecord : class, new()
        {
            if (query == null)
            {
                throw new ArgumentNullException("query");
            }

            if (records == null || records.Length < 1)
            {
                throw new ArgumentException("At least one parameter must be specified", "records");
            }

            IHttpAddress address = baseAddress.WithResource(resource);
            address = address.WithSqlQuery(query);

            string body = contentSerializer.Serialize(new { resource = new List<TRequestRecord>(records), ids = records.Select(x => x.Id) });
            IHttpRequest request = new HttpRequest(method, address.Build(), baseHeaders, body);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            var responses = new { resource = new List<TResponseRecord>() };
            return contentSerializer.Deserialize(response.Body, responses).resource;
        }

        #endregion
    }
}
