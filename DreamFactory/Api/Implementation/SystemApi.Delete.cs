namespace DreamFactory.Api.Implementation
{
    using System;
    using System.Threading.Tasks;
    using DreamFactory.Http;

    internal partial class SystemApi
    {
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

        public Task DeleteEmailTemplatesAsync(params int[] ids)
        {
            return DeleteRecordsAsync("email_template", false, ids);
        }

        public Task DeleteProvidersAsync(params int[] ids)
        {
            return DeleteRecordsAsync("provider", false, ids);
        }

        public Task DeleteProviderUsersAsync(params int[] ids)
        {
            return DeleteRecordsAsync("provider_user", false, ids);
        }

        #region --- Helpers ---

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
