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
// ReSharper disable PossibleMultipleEnumeration
        public async Task RunAsync(IRestContext context)
        {
            ISystemApi systemApi = context.Factory.CreateSystemApi();

            // Read
            SqlQuery query = new SqlQuery { fields = "*", related = "services,roles", };
            IEnumerable<AppResponse> apps = await systemApi.GetAppsAsync(query);
            Console.WriteLine("Apps: {0}", apps.Select(x => x.api_name).ToStringList());

            // Cloning
            AppResponse todoApp = apps.Single(x => x.api_name == "todoangular");
            AppRequest todoAppRequest = todoApp.Convert<AppResponse, AppRequest>();
            todoAppRequest.name = todoApp.name + "clone";
            todoAppRequest.api_name = todoApp.api_name + "clone";

            // Creating a clone
            apps = await systemApi.CreateAppsAsync(new SqlQuery(), todoAppRequest);
            AppResponse todoAppClone = apps.Single(x => x.api_name == "todoangularclone");
            Console.WriteLine("Created a clone app={0}", todoAppClone.api_name);

            // Deleting the clone
            Debug.Assert(todoAppClone.id.HasValue);
            await systemApi.DeleteAppsAsync(true, todoAppClone.id.Value);
            Console.WriteLine("Created clone has been deleted");
        }
    }
}
