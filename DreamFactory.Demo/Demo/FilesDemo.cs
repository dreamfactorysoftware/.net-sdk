namespace DreamFactory.Demo.Demo
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DreamFactory.Api;
    using DreamFactory.Model.File;
    using DreamFactory.Rest;

    public class FilesDemo : IRunnable
    {
        public async Task RunAsync(IRestContext context)
        {
            IFilesApi filesApi = context.Factory.CreateFilesApi("files");

            // Display resources
            IEnumerable<string> names = await filesApi.GetResourceNamesAsync();
            Console.WriteLine("GetResourcesAsync(): {0}", names.ToStringList());

            // Creating a folder
           await filesApi.CreateFolderAsync("test", true);
            Console.WriteLine("Folder 'test' created.");

            // Creating a file
            FileResponse response = await filesApi.CreateFileAsync("test/test.txt", "test", true);
            Console.WriteLine("Created file: {0}", response.Path);

            // Reading the file
            string content = await filesApi.GetTextFileAsync("test/test.txt");
            Console.WriteLine("GetFile content: {0}", content);

            // Deleting the file
            response = await filesApi.DeleteFileAsync("test/test.txt");
            Console.WriteLine("Deleted file: {0}", response.Path);

            // Deleting the folder
            await filesApi.DeleteFolderAsync("test", true);
            Console.WriteLine("Folder 'test' deleted.");
        }
    }
}
