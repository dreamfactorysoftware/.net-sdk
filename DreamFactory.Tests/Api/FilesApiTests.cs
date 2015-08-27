namespace DreamFactory.Tests.Api
{
    using System.Collections.Generic;
    using System.Linq;
    using DreamFactory.Api;
    using DreamFactory.Api.Implementation;
    using DreamFactory.Http;
    using DreamFactory.Model.File;
    using DreamFactory.Rest;
    using DreamFactory.Serialization;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Shouldly;

    [TestClass]
    public class FilesApiTests
    {
        private const string BaseAddress = "http://localhost:8765";

        #region --- Resources ---

        [TestMethod]
        public void ShouldGetResourcesAsync()
        {
            // Arrange
            IFilesApi filesApi = CreateFilesApi();

            // Act
            List<StorageResource> resources = filesApi.GetResourcesAsync(ListingFlags.IncludeFiles | ListingFlags.IncludeFolders).Result.ToList();

            // Assert
            resources.Count.ShouldBe(4);
            resources.Count(x => x.Name == "applications").ShouldBe(1);
        }

        [TestMethod]
        public void ShouldGetResourceNamesAsync()
        {
            // Arrange
            IFilesApi filesApi = CreateFilesApi();

            // Act
            List<string> resources = filesApi.GetResourceNamesAsync().Result.ToList();

            // Assert
            resources.Count.ShouldBe(4);
            resources.Count(x => x == "applications").ShouldBe(1);
        }

        #endregion

        #region --- Folders ---

        [TestMethod]
        public void ShouldGetFolderAsync()
        {
            // Arrange
            IFilesApi filesApi = CreateFilesApi();

            // Act
            FolderResponse folder = filesApi.GetFolderAsync("calendar", ListingFlags.IncludeEverything).Result;

            // Assert
            folder.ShouldNotBe(null);
            folder.Name.ShouldBe("calendar");
            folder.Folder.Count.ShouldBe(2);
            folder.File.Count.ShouldBe(6);
        }

        [TestMethod]
        public void ShouldCreateFolderAsync()
        {
            // Arrange
            IFilesApi filesApi = CreateFilesApi();

            // Act & Assert
            filesApi.CreateFolderAsync("calendar").Wait();
        }

        [TestMethod]
        public void ShouldDownloadFolderAsync()
        {
            // Arrange
            IFilesApi filesApi = CreateFilesApi();

            // Act
            byte[] data = filesApi.DownloadFolderAsync("calendar").Result;

            // Assert
            data.Length.ShouldBeGreaterThan(0);
        }

        [TestMethod]
        public void ShouldDeleteFolderAsync()
        {
            // Arrange
            IFilesApi filesApi = CreateFilesApi();

            // Act & Assert
            filesApi.DeleteFolderAsync("calendar").Wait();
        }


        #endregion

        #region --- Files ---

        [TestMethod]
        public void ShouldCreateTextFileAsync()
        {
            // Arrange
            IFilesApi filesApi = CreateFilesApi();

            // Act
            FileResponse fileResponse = filesApi.CreateFileAsync("calendar/test.txt", "Hello").Result;

            // Assert
            fileResponse.Path.ShouldBe("calendar/test.txt");
        }

        [TestMethod]
        public void ShouldCreateBinaryFileAsync()
        {
            // Arrange
            IFilesApi filesApi = CreateFilesApi();
            byte[] data = { 50, 51, 52, 53, 54, 55, 56, 57 };

            // Act
            FileResponse fileResponse = filesApi.CreateFileAsync("calendar/test.bin", data).Result;

            // Assert
            fileResponse.Path.ShouldBe("calendar/test.bin");
        }

        [TestMethod]
        public void ShouldGetTextFileAsync()
        {
            // Arrange
            IFilesApi filesApi = CreateFilesApi();

            // Act
            string content = filesApi.GetTextFileAsync("calendar/test.txt").Result;

            // Assert
            content.ShouldBe("Hello");
        }

        [TestMethod]
        public void ShouldGetBinaryFileAsync()
        {
            // Arrange
            IFilesApi filesApi = CreateFilesApi();
            byte[] expected = { 1, 2, 3, 4, 5, 6, 7, 8 };

            // Act
            byte[] content = filesApi.GetBinaryFileAsync("calendar/test.bin").Result;

            // Assert
            content.Length.ShouldBe(8);
            content.ShouldBe(expected);
        }

        [TestMethod]
        public void ShouldReplaceTextFileContentsAsync()
        {
            // Arrange
            IFilesApi filesApi = CreateFilesApi();

            // Act & Assert
            filesApi.ReplaceFileContentsAsync("calendar/test.txt", "Bye").Wait();
        }

        [TestMethod]
        public void ShouldReplaceBinaryFileContentsAsync()
        {
            // Arrange
            IFilesApi filesApi = CreateFilesApi();
            byte[] data = { 50, 51, 52, 53, 54, 55, 56, 57 };

            // Act & Assert
            filesApi.ReplaceFileContentsAsync("calendar/test.bin", data).Wait();
        }

        [TestMethod]
        public void ShouldDeleteFileAsync()
        {
            // Arrange
            IFilesApi filesApi = CreateFilesApi();

            // Act
            FileResponse fileResponse = filesApi.DeleteFileAsync("calendar/test.txt").Result;

            // Assert
            fileResponse.Path.ShouldBe("calendar/test.txt");
        }

        #endregion

        private static IFilesApi CreateFilesApi()
        {
            IHttpFacade httpFacade = new TestDataHttpFacade();
            HttpAddress address = new HttpAddress(BaseAddress, RestApiVersion.V1);
            HttpHeaders headers = new HttpHeaders();
            return new FilesApi(address, httpFacade, new JsonContentSerializer(), headers, "files");
        }
    }
}
