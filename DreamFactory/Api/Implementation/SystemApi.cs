namespace DreamFactory.Api.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading.Tasks;
    using DreamFactory.Http;
    using DreamFactory.Model.Database;
    using DreamFactory.Model.System;
    using DreamFactory.Serialization;

    internal class SystemApi : ISystemApi
    {
        private readonly IHttpAddress baseAddress;
        private readonly IHttpFacade httpFacade;
        private readonly IContentSerializer contentSerializer;
        private readonly IHttpHeaders baseHeaders;

        public SystemApi(IHttpAddress baseAddress, IHttpFacade httpFacade, IContentSerializer contentSerializer, IHttpHeaders baseHeaders)
        {
            this.baseAddress = baseAddress;
            this.httpFacade = httpFacade;
            this.contentSerializer = contentSerializer;
            this.baseHeaders = baseHeaders;
        }

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

        public Task UpdateAppsAsync(params AppRequest[] apps)
        {
            return CreateOrUpdateRecordsAsync(HttpMethod.Patch, "app", apps);
        }

        public Task UpdateAppGroupsAsync(params AppGroupRequest[] appGroups)
        {
            return CreateOrUpdateRecordsAsync(HttpMethod.Patch, "app_group", appGroups);
        }

        public Task UpdateRolesAsync(params RoleRequest[] roles)
        {
            return CreateOrUpdateRecordsAsync(HttpMethod.Patch, "role", roles);
        }

        public Task UpdateUsersAsync(params UserRequest[] users)
        {
            return CreateOrUpdateRecordsAsync(HttpMethod.Patch, "user", users);
        }

        public Task UpdateServicesAsync(params ServiceRequest[] services)
        {
            return CreateOrUpdateRecordsAsync(HttpMethod.Patch, "service", services);
        }

        public Task DeleteAppsAsync(bool deleteStorage = false, params int[] ids)
        {
            return DeleteRecordsAsync("app", deleteStorage, ids);
        }

        public Task DeleteAppGroupsAsync(params int[] ids)
        {
            return DeleteRecordsAsync("app_group", false, ids);
        }

        public Task DeleteRolesAsync(params int[] ids)
        {
            return DeleteRecordsAsync("role", false, ids);
        }

        public Task DeleteUsersAsync(params int[] ids)
        {
            return DeleteRecordsAsync("user", false, ids);
        }

        public Task DeleteServicesAsync(params int[] ids)
        {
            return DeleteRecordsAsync("service", false, ids);
        }

        public async Task<byte[]> DownloadApplicationPackageAsync(int applicationId, bool includeFiles, bool includeServices, bool includeSchema)
        {
            IHttpAddress address = baseAddress.WithResources("system", "app",
                applicationId.ToString(CultureInfo.InvariantCulture))
                .WithParameter("pkg", true)
                .WithParameter("include_files", includeFiles)
                .WithParameter("include_services", includeServices)
                .WithParameter("include_schema", includeSchema);

            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            return response.RawBody;
        }

        public async Task<byte[]> DownloadApplicationSdkAsync(int applicationId)
        {
            IHttpAddress address = baseAddress.WithResources("system", "app",
                applicationId.ToString(CultureInfo.InvariantCulture))
                .WithParameter("sdk", true);

            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            return response.RawBody;
        }

        #region --- Helpers ---

        private async Task<IHttpResponse> CreateOrUpdateRecordsAsync<TRecord>(HttpMethod method, string resource, params TRecord[] records)
        {
            if (records == null || records.Length < 1)
            {
                throw new ArgumentException("At least one parameter must be specificed", "records");
            }

            IHttpAddress address = baseAddress.WithResources("system", resource);
            var requests = new { record = new List<TRecord>(records) };
            string body = contentSerializer.Serialize(requests);
            IHttpRequest request = new HttpRequest(method, address.Build(), baseHeaders, body);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            return response;
        }

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

        private async Task DeleteRecordsAsync(string resource, bool setDeleteStorage, params int[] ids)
        {
            if (ids == null || ids.Length < 1)
            {
                throw new ArgumentException("At least one application ID must be specificed", "ids");
            }

            string list = string.Join(",", ids);
            IHttpAddress address = baseAddress.WithResources("system", resource).WithParameter("ids", list);
            if (setDeleteStorage)
            {
                address = address.WithParameter("delete_storage", true);
            }

            IHttpRequest request = new HttpRequest(HttpMethod.Delete, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);
        }

        #endregion
    }
}
