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
            IHttpResponse response = await CreateOrUpdateApps(HttpMethod.Post, apps);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            var responses = new { record = new List<AppResponse>() };
            return contentSerializer.Deserialize(response.Body, responses).record;
        }

        public async Task UpdateAppsAsync(params AppRequest[] apps)
        {
            await CreateOrUpdateApps(HttpMethod.Patch, apps);
        }

        public async Task DeleteAppsAsync(bool deleteStorage = false, params int[] ids)
        {
            if (ids == null || ids.Length < 1)
            {
                throw new ArgumentException("At least one application ID must be specificed", "ids");
            }

            string list = string.Join(",", ids);
            IHttpAddress address = baseAddress.WithResources("system", "app").WithParameter("ids", list);
            if (deleteStorage)
            {
                address = address.WithParameter("delete_storage", true);
            }
            
            IHttpRequest request = new HttpRequest(HttpMethod.Delete, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);
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

        public async Task<IEnumerable<RelatedAppGroup>> GetAppGroupsAsync(SqlQuery query = null)
        {
            IHttpAddress address = baseAddress.WithResources("system", "app_group");

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

            var apps = new { record = new List<RelatedAppGroup>() };
            return contentSerializer.Deserialize(response.Body, apps).record;
        }

        private async Task<IHttpResponse> CreateOrUpdateApps(HttpMethod method, params AppRequest[] apps)
        {
            if (apps == null || apps.Length < 1)
            {
                throw new ArgumentException("At least one application must be specificed", "apps");
            }

            IHttpAddress address = baseAddress.WithResources("system", "app");
            var requests = new { record = new List<AppRequest>(apps) };
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
    }
}
