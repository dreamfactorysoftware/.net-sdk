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
        public Task<IEnumerable<AppResponse>>  DeleteAppsAsync(SqlQuery query, params int[] ids)
        {
            return DeleteRecordsAsync<AppResponse>("app", query, false, ids);
        }

        public Task<IEnumerable<AppGroupResponse>> DeleteAppGroupsAsync(SqlQuery query, params int[] ids)
        {
            return DeleteRecordsAsync<AppGroupResponse>("app_group", query, false, ids);
        }

        public Task<IEnumerable<RoleResponse>> DeleteRolesAsync(SqlQuery query, params int[] ids)
        {
            return DeleteRecordsAsync<RoleResponse>("role", query, false, ids);
        }

        public Task<IEnumerable<UserResponse>> DeleteUsersAsync(SqlQuery query, params int[] ids)
        {
            return DeleteRecordsAsync<UserResponse>("user", query, false, ids);
        }

        public Task<IEnumerable<ServiceResponse>> DeleteServicesAsync(SqlQuery query, params int[] ids)
        {
            return DeleteRecordsAsync<ServiceResponse>("service", query, false, ids);
        }

        public Task<IEnumerable<EmailTemplateResponse>> DeleteEmailTemplatesAsync(SqlQuery query, params int[] ids)
        {
            return DeleteRecordsAsync<EmailTemplateResponse>("email_template", query, false, ids);
        }

        #region --- Helpers ---

        private async Task<IEnumerable<TResponseRecord>> DeleteRecordsAsync<TResponseRecord>(string resource, SqlQuery query, bool force, params int[] ids)
            where TResponseRecord : class, new()
        {
            if (resource == null)
            {
                throw new ArgumentNullException("resource");
            }

            if (query == null)
            {
                throw new ArgumentNullException("query");
            }

            if (ids == null || ids.Length < 1)
            {
                throw new ArgumentException("At least one application ID must be specified", "ids");
            }


            IHttpAddress address = baseAddress.WithResource(resource);
            address = address.WithSqlQuery(query);

            if (force)
            {
                address = address.WithParameter("force", true);
            }
            else
            {
                address = address.WithParameter("ids", string.Join(",", ids));
            }

            IHttpRequest request = new HttpRequest(HttpMethod.Delete, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            var responses = new { resource = new List<TResponseRecord>() };
            return contentSerializer.Deserialize(response.Body, responses).resource;
        }

        private async Task<TResponseRecord> DeleteRecordAsync<TResponseRecord>(string resource, string identifier, SqlQuery query)
            where TResponseRecord : class, new()
        {
            if (resource == null)
            {
                throw new ArgumentNullException("resource");
            }

            if (identifier == null)
            {
                throw new ArgumentNullException("identifier");
            }

            if (query == null)
            {
                throw new ArgumentNullException("query");
            }

            IHttpAddress address = baseAddress.WithResource(resource, identifier);
            address = address.WithSqlQuery(query);

            IHttpRequest request = new HttpRequest(HttpMethod.Delete, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            return contentSerializer.Deserialize<TResponseRecord>(response.Body);
        }

        #endregion
    }
}
