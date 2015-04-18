namespace DreamFactory.Demo
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using DreamFactory.Api;
    using DreamFactory.Model.File;
    using DreamFactory.Rest;
    using Newtonsoft.Json;

    public static class FilesDemo
    {
        private const string TestContainer = "test";

        public static async Task Run(IRestContext context)
        {
            IFilesApi filesApi = context.Factory.CreateFilesApi("files");

            // TODO: deletion is not working
            // await ContainerTest(filesApi);

            // Creating a folder: test/inbox
            // await filesApi.CreateFolderAsync(TestContainer, "inbox");

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

        public static async Task ContainerTest(IFilesApi filesApi)
        {
            Console.WriteLine("GetAccessComponentsAsync():");
            IEnumerable<string> components = await filesApi.GetAccessComponentsAsync();
            Console.WriteLine("{0}", components.ToStringList());
            Console.WriteLine();

            Console.WriteLine("GetContainersAsync():");
            IEnumerable<ContainerInfo> containers = await filesApi.GetContainersAsync();
            foreach (ContainerInfo info in containers)
            {
                string json = JsonConvert.SerializeObject(info, Formatting.Indented);
                Console.WriteLine("{0}", json);
            }
            Console.WriteLine();

            Console.WriteLine("GetContainerAsync({0}):", TestContainer);
            ContainerResponse container = await filesApi.GetContainerAsync(TestContainer, ListingFlags.IncludeEverything);
            string json2 = JsonConvert.SerializeObject(container, Formatting.Indented);
            Console.WriteLine("{0}", json2);
            Console.WriteLine();

            string[] names = { "foo", "bar" };
            Console.WriteLine("CreateContainersAsync(foo, bar): {0}", names.ToStringList());
            await filesApi.CreateContainersAsync(names);
            Console.WriteLine("DeleteContainersAsync(foo, bar): {0}", names.ToStringList());
            await filesApi.DeleteContainersAsync(names);
            Console.WriteLine();

            Console.WriteLine("UploadContainerAsync(newbie)");
            await filesApi.UploadContainerAsync("newbie", "http://pinebit.ddns.net/test.zip", true);
            Console.WriteLine("DeleteContainerAsync(newbie)");
            await filesApi.DeleteContainerAsync("newbie", true);
        }
    }
}
