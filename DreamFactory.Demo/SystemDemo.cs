namespace DreamFactory.Demo
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using DreamFactory.Api;
    using DreamFactory.Model.Database;
    using DreamFactory.Model.System.App;
    using DreamFactory.Model.System.Environment;
    using DreamFactory.Model.System.User;
    using DreamFactory.Rest;

    public static class SystemDemo
    {
        public static async Task Run(IRestContext context)
        {
            // IUserApi provides all functions for user management
            ISystemApi systemApi = context.Factory.CreateSystemApi();

            // List apps
            IEnumerable<AppResponse> apps = await systemApi.GetAppsAsync(new SqlQuery("is_active=true"));
            Console.WriteLine("Apps: {0}", apps.Select(x => x.api_name).ToStringList());
            Console.WriteLine();

            // List users with roles
            IEnumerable<UserResponse> users = await systemApi.GetUsersAsync();
            Console.WriteLine("Users: {0}", users.Select(x => x.display_name).ToStringList());
            Console.WriteLine();

            // Download app package & SDK
            Console.WriteLine("Downloading app package and SDK...");
            byte[] package = await systemApi.DownloadApplicationPackageAsync(1);
            byte[] sdk = await systemApi.DownloadApplicationSdkAsync(1);
            File.WriteAllBytes("todojquery-package.zip", package);
            File.WriteAllBytes("todojquery-sdk.zip", sdk);

            // Get environment info
            EnvironmentResponse environment = await systemApi.GetEnvironmentAsync();
            Console.WriteLine("DreamFactory Server is running on {0}", environment.server.server_os);
        }
    }
}
