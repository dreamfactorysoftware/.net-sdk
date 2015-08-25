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
            Console.WriteLine("Apps: {0}", apps.Select(x => x.ApiName).ToStringList());

            // Cloning
            AppResponse todoApp = apps.Single(x => x.ApiName == "todoangular");
            AppRequest todoAppRequest = todoApp.Convert<AppResponse, AppRequest>();
            todoAppRequest.Name = todoApp.Name + "clone";
            todoAppRequest.ApiName = todoApp.ApiName + "clone";

            // Creating a clone
            apps = await systemApi.CreateAppsAsync(new SqlQuery(), todoAppRequest);
            AppResponse todoAppClone = apps.Single(x => x.ApiName == "todoangularclone");
            Console.WriteLine("Created a clone app={0}", todoAppClone.ApiName);

            // Deleting the clone
            Debug.Assert(todoAppClone.Id.HasValue);
            await systemApi.DeleteAppsAsync(true, todoAppClone.Id.Value);
            Console.WriteLine("Created clone has been deleted");
        }
    }
}
