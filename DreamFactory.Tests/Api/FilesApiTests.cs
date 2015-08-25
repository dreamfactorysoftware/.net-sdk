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
        private const string BaseAddress = "http://localhost";

        #region --- Containers ---

        [TestMethod]
        public void ShouldGetContainerNamesAsync()
        {
            // Arrange
            IFilesApi filesApi = CreateFilesApi();

            // Act
            List<string> names = filesApi.GetContainerNamesAsync().Result.ToList();

            // Assert
            names.Count.ShouldBe(4);
            names.Count(x => x == "applications").ShouldBe(1);
        }

        [TestMethod]
        public void ShouldCreateContainersAsync()
        {
            // Arrange
            IFilesApi filesApi = CreateFilesApi();

            // Act & Assert
            filesApi.CreateContainersAsync(false, "a", "b").Wait();
        }

        [TestMethod]
        public void ShouldDeleteContainersAsync()
        {
            // Arrange
            IFilesApi filesApi = CreateFilesApi();

            // Act & Assert
            filesApi.DeleteContainersAsync("a", "b").Wait();
        }

        [TestMethod]
        public void ShouldDeleteContainerAsync()
        {
            // Arrange
            IFilesApi filesApi = CreateFilesApi();

            // Act & Assert
            filesApi.DeleteContainerAsync("applications").Wait();
        }

        [TestMethod]
        public void ShouldGetContainerAsync()
        {
            // Arrange
            IFilesApi filesApi = CreateFilesApi();

            // Act
            ContainerResponse result = filesApi.GetContainerAsync("applications", ListingFlags.IncludeEverything).Result;

            // Assert
            result.ShouldNotBe(null);
            result.Name.ShouldBe("applications");
            result.Folder.Count.ShouldBe(11);
            result.File.Count.ShouldBe(32);
        }

        [TestMethod]
        public void ShouldDownloadContainerAsync()
        {
            // Arrange
            IFilesApi filesApi = CreateFilesApi();

            // Act
            byte[] data = filesApi.DownloadContainerAsync("applications").Result;

            // Assert
            data.Length.ShouldBeGreaterThan(0);
        }

        #endregion

        #region --- Folders ---

        [TestMethod]
        public void ShouldGetFolderAsync()
        {
            // Arrange
            IFilesApi filesApi = CreateFilesApi();

            // Act
            FolderResponse folder = filesApi.GetFolderAsync("applications", "calendar", ListingFlags.IncludeEverything).Result;

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
            filesApi.CreateFolderAsync("applications", "calendar").Wait();
        }

        [TestMethod]
        public void ShouldDownloadFolderAsync()
        {
            // Arrange
            IFilesApi filesApi = CreateFilesApi();

            // Act
            byte[] data = filesApi.DownloadFolderAsync("applications", "calendar").Result;

            // Assert
            data.Length.ShouldBeGreaterThan(0);
        }

        [TestMethod]
        public void ShouldDeleteFolderAsync()
        {
            // Arrange
            IFilesApi filesApi = CreateFilesApi();

            // Act & Assert
            filesApi.DeleteFolderAsync("applications", "calendar").Wait();
        }


        #endregion

        #region --- Files ---

        [TestMethod]
        public void ShouldCreateTextFileAsync()
        {
            // Arrange
            IFilesApi filesApi = CreateFilesApi();

            // Act
            FileResponse fileResponse = filesApi.CreateFileAsync("applications", "calendar/test.txt", "Hello").Result;

            // Assert
            fileResponse.Path.ShouldBe("applications/calendar/test.txt");
        }

        [TestMethod]
        public void ShouldCreateBinaryFileAsync()
        {
            // Arrange
            IFilesApi filesApi = CreateFilesApi();
            byte[] data = { 50, 51, 52, 53, 54, 55, 56, 57 };

            // Act
            FileResponse fileResponse = filesApi.CreateFileAsync("applications", "calendar/test.bin", data).Result;

            // Assert
            fileResponse.Path.ShouldBe("applications/calendar/test.bin");
        }

        [TestMethod]
        public void ShouldGetTextFileAsync()
        {
            // Arrange
            IFilesApi filesApi = CreateFilesApi();

            // Act
            string content = filesApi.GetTextFileAsync("applications", "calendar/test.txt").Result;

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
            byte[] content = filesApi.GetBinaryFileAsync("applications", "calendar/test.bin").Result;

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
            filesApi.ReplaceFileContentsAsync("applications", "calendar/test.txt", "Bye").Wait();
        }

        [TestMethod]
        public void ShouldReplaceBinaryFileContentsAsync()
        {
            // Arrange
            IFilesApi filesApi = CreateFilesApi();
            byte[] data = { 50, 51, 52, 53, 54, 55, 56, 57 };

            // Act & Assert
            filesApi.ReplaceFileContentsAsync("applications", "calendar/test.bin", data).Wait();
        }

        [TestMethod]
        public void ShouldDeleteFileAsync()
        {
            // Arrange
            IFilesApi filesApi = CreateFilesApi();

            // Act
            FileResponse fileResponse = filesApi.DeleteFileAsync("applications", "calendar/test.txt").Result;

            // Assert
            fileResponse.Path.ShouldBe("applications/calendar/test.txt");
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
