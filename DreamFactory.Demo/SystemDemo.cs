namespace DreamFactory.Demo
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using DreamFactory.Api;
    using DreamFactory.Model.Database;
    using DreamFactory.Model.System;
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

            // Download app package & SDK
            Console.WriteLine("Downloading app package and SDK...");
            byte[] package = await systemApi.DownloadApplicationPackageAsync(1);
            byte[] sdk = await systemApi.DownloadApplicationSdkAsync(1);
            File.WriteAllBytes("todojquery-package.zip", package);
            File.WriteAllBytes("todojquery-sdk.zip", sdk);
        }
    }
}
