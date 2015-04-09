namespace DreamFactory.Demo
{
    using System;
    using System.Threading.Tasks;
    using DreamFactory.Api;
    using DreamFactory.Model;
    using DreamFactory.Rest;

    public static class FilesDemo
    {
        public static async Task Run(string baseAddress)
        {
            // Must login first...
            IRestContext context = new RestContext(baseAddress);
            IUserSessionApi userSessionApi = context.GetServiceApi<IUserSessionApi>();
            Session session = await userSessionApi.LoginAsync("todoangular", Utils.CreateLogin());
            Console.WriteLine("Logged in as {0}", session.display_name);

            // Creating a file
            IFilesApi filesApi = context.GetServiceApi<IFilesApi>("files");
            FileResponse response = await filesApi.CreateFileAsync("applications", "calendar/test.txt", "test", false);
            Console.WriteLine("Created file: {0}", response.path);

            // Reading the file
            string content = await filesApi.GetFileAsync("applications", "calendar/test.txt");
            Console.WriteLine("GetFile content: {0}", content);

            // Deleting the file
            response = await filesApi.DeleteFileAsync("applications", "calendar/test.txt");
            Console.WriteLine("Deleted file: {0}", response.path);
        }
    }
}