namespace DreamFactory.Demo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using DreamFactory.Api;
    using DreamFactory.Model.System;
    using DreamFactory.Rest;

    public static class SystemDemo
    {
        public static async Task Run(IRestContext context)
        {
            // IUserApi provides all functions for user management
            ISystemApi systemApi = context.Factory.CreateSystemApi();

            // List apps
            IEnumerable<AppResponse> apps = await systemApi.GetAppsAsync();
            Console.WriteLine("Apps: {0}", apps.Select(x => x.api_name).ToStringList());
        }
    }
}