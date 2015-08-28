namespace DreamFactory.Demo.Test
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    using DreamFactory.Api;
    using DreamFactory.Model.Database;
    using DreamFactory.Model.System.App;
    using DreamFactory.Rest;

    public class SystemAppTest : IRunnable
    {
        public async Task RunAsync(IRestContext context)
        {
            ISystemApi systemApi = context.Factory.CreateSystemApi();

            // Read
            SqlQuery query = new SqlQuery { Fields = "*", Related = "services,roles", };
            IEnumerable<AppResponse> apps = (await systemApi.GetAppsAsync(query)).ToList();
            Console.WriteLine("Apps: {0}", apps.Select(x => x.ApiKey).ToStringList());

            // Cloning
            AppResponse todoApp = apps.Single(x => x.ApiKey == "admin");
            AppRequest todoAppRequest = todoApp.Convert<AppResponse, AppRequest>();
            todoAppRequest.Name = todoApp.Name + "clone";
            todoAppRequest.ApiName = todoApp.ApiKey + "clone";

            // Creating a clone
            apps = await systemApi.CreateAppsAsync(new SqlQuery(), todoAppRequest);
            AppResponse todoAppClone = apps.Single(x => x.ApiKey == "admin-clone");
            Console.WriteLine("Created a clone app={0}", todoAppClone.ApiKey);

            // Deleting the clone
            Debug.Assert(todoAppClone.Id.HasValue);
            await systemApi.DeleteAppsAsync(true, todoAppClone.Id.Value);
            Console.WriteLine("Created clone has been deleted");
        }
    }
}
