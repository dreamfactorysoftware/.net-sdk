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
            await filesApi.CreateContainersAsync(false, TestContainer);

            // Creating a file
            FileResponse response = await filesApi.CreateFileAsync(TestContainer, "test.txt", "test", false);
            Console.WriteLine("Created file: {0}", response.path);

            // Reading the file
            string content = await filesApi.GetTextFileAsync(TestContainer, "test.txt");
            Console.WriteLine("GetFile content: {0}", content);

            // Deleting the file
            response = await filesApi.DeleteFileAsync(TestContainer, "test.txt");
            Console.WriteLine("Deleted file: {0}", response.path);

            // Deleting the container
            await filesApi.DeleteContainersAsync(TestContainer);
            Console.WriteLine("Container '{0}' deleted.", TestContainer);

            // Downloading a container
            Console.WriteLine("Downloading 'applications' container as zip archive...");
            byte[] zip = await filesApi.DownloadContainerAsync("applications");
            File.WriteAllBytes("applications-container.zip", zip);
            Console.WriteLine("Open applications-container.zip to see the contents.");
        }
    }
}
