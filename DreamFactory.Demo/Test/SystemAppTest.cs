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
    using DreamFactory.Model.System.App;
    using DreamFactory.Rest;

    public class SystemAppTest : IRunnable
    {
        public async Task RunAsync(IRestContext context)
        {
            ISystemAppApi appApi = context.Factory.CreateSystemAppApi();

            // Read
            SqlQuery query = new SqlQuery {
                Fields = "*",
                Related = String.Join(",", RelatedResources.App.StorageService, RelatedResources.App.Roles)
            };
            IEnumerable<AppResponse> apps = (await appApi.GetAppsAsync(query)).ToList();
            Console.WriteLine("Apps: {0}", apps.Select(x => x.ApiKey).ToStringList());

            // Cloning
            AppResponse adminApp = apps.Single(x => x.Name == "admin");
            AppRequest adminAppRequest = adminApp.Convert<AppResponse, AppRequest>();
            adminAppRequest.Id = null;
            adminAppRequest.Name = adminApp.Name + "clone";

            // Creating a clone
            apps = await appApi.CreateAppsAsync(new SqlQuery(), adminAppRequest);
            AppResponse adminAppClone = apps.Single(x => x.Name == "adminclone");
            Console.WriteLine("Created a clone app={0}", adminAppClone.ApiKey);

            // Deleting the clone
            Debug.Assert(adminAppClone.Id.HasValue);
            await appApi.DeleteAppsAsync(new SqlQuery(), adminAppClone.Id.Value);
            Console.WriteLine("Created clone has been deleted");
        }
    }
}
