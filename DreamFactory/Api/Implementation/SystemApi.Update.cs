namespace DreamFactory.Api.Implementation
{
    using System.Threading.Tasks;
    using DreamFactory.Http;
    using DreamFactory.Model.System.App;
    using DreamFactory.Model.System.AppGroup;
    using DreamFactory.Model.System.Email;
    using DreamFactory.Model.System.Provider;
    using DreamFactory.Model.System.ProviderUser;
    using DreamFactory.Model.System.Role;
    using DreamFactory.Model.System.Service;
    using DreamFactory.Model.System.User;

    internal partial class SystemApi
    {
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

        public Task UpdateEmailTemplatesAsync(params EmailTemplateRequest[] templates)
        {
            return CreateOrUpdateRecordsAsync(HttpMethod.Patch, "email_template", templates);
        }

        public Task UpdateProvidersAsync(params ProviderRequest[] providers)
        {
            return CreateOrUpdateRecordsAsync(HttpMethod.Patch, "provider", providers);
        }

        public Task UpdateProviderUsersAsync(params ProviderUserRequest[] providerUsers)
        {
            return CreateOrUpdateRecordsAsync(HttpMethod.Patch, "provider_user", providerUsers);
        }
    }
}
