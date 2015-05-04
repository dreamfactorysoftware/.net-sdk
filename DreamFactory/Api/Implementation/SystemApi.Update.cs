namespace DreamFactory.Api.Implementation
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DreamFactory.Http;
    using DreamFactory.Model.System.App;
    using DreamFactory.Model.System.AppGroup;
    using DreamFactory.Model.System.Email;
    using DreamFactory.Model.System.Role;
    using DreamFactory.Model.System.Service;
    using DreamFactory.Model.System.User;

    internal partial class SystemApi
    {
        public async Task<IEnumerable<AppResponse>> UpdateAppsAsync(params AppRequest[] apps)
        {
            var response = await CreateOrUpdateRecordsAsync(HttpMethod.Patch, "app", apps);
            var responses = new { record = new List<AppResponse>() };
            return contentSerializer.Deserialize(response.Body, responses).record;
        }

        public async Task<IEnumerable<AppGroupResponse>> UpdateAppGroupsAsync(params AppGroupRequest[] appGroups)
        {
            var response = await CreateOrUpdateRecordsAsync(HttpMethod.Patch, "app_group", appGroups);
            var responses = new { record = new List<AppGroupResponse>() };
            return contentSerializer.Deserialize(response.Body, responses).record;
        }

        public async Task<IEnumerable<RoleResponse>> UpdateRolesAsync(params RoleRequest[] roles)
        {
            var response = await CreateOrUpdateRecordsAsync(HttpMethod.Patch, "role", roles);
            var responses = new { record = new List<RoleResponse>() };
            return contentSerializer.Deserialize(response.Body, responses).record;
        }

        public async Task<IEnumerable<UserResponse>> UpdateUsersAsync(params UserRequest[] users)
        {
            var response = await CreateOrUpdateRecordsAsync(HttpMethod.Patch, "user", users);
            var responses = new { record = new List<UserResponse>() };
            return contentSerializer.Deserialize(response.Body, responses).record;
        }

        public async Task<IEnumerable<ServiceResponse>> UpdateServicesAsync(params ServiceRequest[] services)
        {
            var response = await CreateOrUpdateRecordsAsync(HttpMethod.Patch, "service", services);
            var responses = new { record = new List<ServiceResponse>() };
            return contentSerializer.Deserialize(response.Body, responses).record;
        }

        public async Task<IEnumerable<EmailTemplateResponse>> UpdateEmailTemplatesAsync(params EmailTemplateRequest[] templates)
        {
            var response = await CreateOrUpdateRecordsAsync(HttpMethod.Patch, "email_template", templates);
            var responses = new { record = new List<EmailTemplateResponse>() };
            return contentSerializer.Deserialize(response.Body, responses).record;
        }
    }
}
