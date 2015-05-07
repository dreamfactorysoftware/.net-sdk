namespace DreamFactory.Demo.Demo
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using DreamFactory.Api;
    using DreamFactory.Model.Database;
    using DreamFactory.Model.System.App;
    using DreamFactory.Model.System.Config;
    using DreamFactory.Model.System.User;
    using DreamFactory.Rest;

    public static class SystemDemo
    {
        public static async Task Run(IRestContext context)
        {
            // IUserApi provides all functions for user management
            ISystemApi systemApi = context.Factory.CreateSystemApi();

            // List apps
            SqlQuery query = new SqlQuery { filter = "is_active=true", fields = "*" };
            IEnumerable<AppResponse> apps = await systemApi.GetAppsAsync(query);
            Console.WriteLine("Apps: {0}", apps.Select(x => x.api_name).ToStringList());
            Console.WriteLine();

            // List users with roles
            IEnumerable<UserResponse> users = await systemApi.GetUsersAsync(new SqlQuery());
            Console.WriteLine("Users: {0}", users.Select(x => x.display_name).ToStringList());
            Console.WriteLine();

            // Download app package & SDK
            Console.WriteLine("Downloading app package and SDK...");
            byte[] package = await systemApi.DownloadApplicationPackageAsync(1);
            byte[] sdk = await systemApi.DownloadApplicationSdkAsync(1);
            File.WriteAllBytes("todojquery-package.zip", package);
            File.WriteAllBytes("todojquery-sdk.zip", sdk);
            Console.WriteLine();

            // Get environment info - does not work for WAMP, uncomment when using linux hosted DSP.
            // EnvironmentResponse environment = await systemApi.GetEnvironmentAsync();
            // Console.WriteLine("DreamFactory Server is running on {0}", environment.server.server_os);

            // Get config
            ConfigResponse config = await systemApi.GetConfigAsync();
            Console.WriteLine("config.install_name = {0}", config.install_name);

            // Get constant
            Dictionary<string, string> contentTypes = await systemApi.GetConstantAsync("content_types");
            Console.WriteLine("Content Types: {0}", contentTypes.Keys.ToStringList());
        }
    }
}
