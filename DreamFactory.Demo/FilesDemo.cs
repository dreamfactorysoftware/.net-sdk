namespace DreamFactory.Demo
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using DreamFactory.Api;
    using DreamFactory.Model.File;
    using DreamFactory.Rest;

    public static class FilesDemo
    {
        public static async Task Run(IRestContext context)
        {
            IFilesApi filesApi = context.Factory.CreateFilesApi("files");

            // Create and list available containers
            await filesApi.CreateContainersAsync(new[] { "tank" }, false);
            var containers = filesApi.GetContainersAsync().Result.Select(x => x.name);
            string flatList = string.Join(", ", containers);
            Console.WriteLine("Containers: [{0}]", flatList);

            // Creating a file
            FileResponse response = await filesApi.CreateFileAsync("tank", "test.txt", "test", false);
            Console.WriteLine("Created file: {0}", response.path);

            // Reading the file
            string content = await filesApi.GetTextFileAsync("tank", "test.txt");
            byte[] raw = await filesApi.GetBinaryFileAsync("tank", "test.txt");
            Console.WriteLine("GetFile content: {0}, raw: {1}", content, Convert.ToBase64String(raw));

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