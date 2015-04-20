namespace DreamFactory.Demo
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using DreamFactory.Api;
    using DreamFactory.Model.File;
    using DreamFactory.Rest;

    public static class FilesDemo
    {
        private const string TestContainer = "test";

        public static async Task Run(IRestContext context)
        {
            IFilesApi filesApi = context.Factory.CreateFilesApi("files");

            // Display existing containers
            Console.WriteLine("GetAccessComponentsAsync():");
            IEnumerable<string> components = await filesApi.GetAccessComponentsAsync();
            Console.WriteLine("{0}", components.ToStringList());
            Console.WriteLine();

            // Creating a test container - tank
            await filesApi.CreateContainersAsync(false, "tank");

            // Creating a file
            FileResponse response = await filesApi.CreateFileAsync("tank", "test.txt", "test", false);
            Console.WriteLine("Created file: {0}", response.path);

            // Reading the file
            string content = await filesApi.GetTextFileAsync("tank", "test.txt");
            Console.WriteLine("GetFile content: {0}", content);

            // Deleting the file
            response = await filesApi.DeleteFileAsync("tank", "test.txt");
            Console.WriteLine("Deleted file: {0}", response.path);

            // Deleting the container
            await filesApi.DeleteContainersAsync(new[] { "tank" });
            Console.WriteLine("Container 'tank' deleted.");

            // Downloading container
            Console.WriteLine("Downloading 'applications' container as zip archive...");
            const ListingFlags flags = ListingFlags.IncludeFiles | ListingFlags.IncludeFolders | ListingFlags.IncludeSubFolders;
            byte[] zip = await filesApi.DownloadContainerAsync("applications", flags);
            File.WriteAllBytes("applications-container.zip", zip);
            Console.WriteLine("Open applications-container.zip to see the contents.");
        }
    }
}
