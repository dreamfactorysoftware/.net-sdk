namespace DreamFactory.Demo.Test
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    using DreamFactory.Api;
    using DreamFactory.Model;
    using DreamFactory.Model.Database;
    using DreamFactory.Model.System.Role;
    using DreamFactory.Rest;

    public class SystemRoleTest : IRunnable
    {
        private const string NewRole = "NewRole";

        public async Task RunAsync(IRestContext context)
        {
            ISystemApi systemApi = context.Factory.CreateSystemApi();

            SqlQuery query = new SqlQuery
            {
                Fields = "*",
                Related = string.Join(",", RelatedResources.Role.Apps, RelatedResources.Role.UsersInApps, RelatedResources.Role.ServicesInApps)
            };
            IEnumerable<RoleResponse> roles = (await systemApi.GetRolesAsync(query)).ToList();
            Console.WriteLine("GetRolesAsync(): {0}", roles.Select(x => x.Name).ToStringList());

            RoleResponse role = roles.SingleOrDefault(x => x.Name == NewRole);
            if (role != null)
            {
                await DeleteRole(role, systemApi);
            }

            RoleRequest newRole = new RoleRequest
            {
                Name = NewRole,
                Description = "new role",
                IsActive = true
            };
                
            roles = await systemApi.CreateRolesAsync(new SqlQuery(), newRole);
            role = roles.Single(x => x.Name == NewRole);
            Console.WriteLine("CreateRolesAsync(): {0}", context.ContentSerializer.Serialize(role));

            newRole.Id = role.Id;
            newRole.Description = "new description";
            role = (await systemApi.UpdateRolesAsync(new SqlQuery(), newRole)).Single(x => x.Name == NewRole);
            Console.WriteLine("UpdateUsersAsync(): new description={0}", role.Description);

            await DeleteRole(role, systemApi);
        }

        private static async Task DeleteRole(RoleResponse role, ISystemApi systemApi)
        {
            Debug.Assert(role.Id.HasValue, "Role ID must be set");
            await systemApi.DeleteRolesAsync(new SqlQuery(), role.Id.Value);
            Console.WriteLine("DeleteRolesAsync():: id={0}", role.Id);
        }
    }
}
