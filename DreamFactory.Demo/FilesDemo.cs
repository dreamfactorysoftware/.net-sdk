namespace DreamFactory.Demo
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using DreamFactory.Api;
    using DreamFactory.Model.File;
    using DreamFactory.Rest;
    using Newtonsoft.Json;

    public static class FilesDemo
    {
        public static async Task Run(IRestContext context)
        {
            IFilesApi filesApi = context.Factory.CreateFilesApi("files");

            // await ContainerTest(filesApi);

            // Create and list available containers
            await filesApi.CreateContainersAsync(new[] { "tank" }, false);
            var containers = filesApi.GetContainersAsync().Result.Select(x => x.name);
            Console.WriteLine("Containers: [{0}]", containers.ToStringList());

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

            Console.WriteLine("GetContainerAsync(applications):");
            ContainerResponse container = await filesApi.GetContainerAsync("applications", ListingFlags.IncludeEverything);
            string json2 = JsonConvert.SerializeObject(container, Formatting.Indented);
            Console.WriteLine("{0}", json2);
            Console.WriteLine();

            string[] names = { "foo", "bar" };
            Console.WriteLine("CreateContainersAsync(): {0}", names.ToStringList());
            await filesApi.CreateContainersAsync(names);
            Console.WriteLine("DeleteContainersAsync(): {0}", names.ToStringList());
            await filesApi.DeleteContainersAsync(names);

            Console.WriteLine("CreateContainerAsync()");
            ContainerRequest request = CreateContainerRequest();
            ContainerResponse response = await filesApi.CreateContainerAsync("foo", request, false);
            string json3 = JsonConvert.SerializeObject(response, Formatting.Indented);
            Console.WriteLine("{0}", json3);
            Console.WriteLine();
        }

        private static ContainerRequest CreateContainerRequest()
        {
            return new ContainerRequest
            {
                name = "foo",
                path = "foo",
                folder = new List<FolderRequest> { CreateFolderRequest() },
                file = new List<FileRequest> { CreateFileRequest() }
            };
        }

        private static FolderRequest CreateFolderRequest()
        {
            return new FolderRequest
            {
                name = "folder",
                path = "folder",
            };
        }

        private static FileRequest CreateFileRequest()
        {
            return new FileRequest
            {
                name = "file.txt",
                path = "folder/file.txt"
            };
        }
    }
}
