namespace DreamFactory.Tests.Api
{
    using System;
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

        [TestMethod]
        public void ShouldGetContainersAsync()
        {
            // Arrange
            IFilesApi filesApi = CreateFilesApi();

            // Act
            List<ContainerInfo> list = filesApi.GetContainersAsync().Result.ToList();

            // Assert
            list.Count.ShouldBe(4);
            ContainerInfo container = list.Single(x => x.name == "applications");
            container.access.ShouldContain("GET");
            container.access.ShouldContain("POST");
            container.access.Count.ShouldBe(6);
            DateTime time = container.last_modified ?? DateTime.Today;
            DateTime.Compare(time, DateTime.Now).ShouldBeLessThan(0);
        }

        [TestMethod]
        public void ShouldCreateContainersAsync()
        {
            // Arrange
            IFilesApi filesApi = CreateFilesApi();

            // Act & Assert
            filesApi.CreateContainersAsync(new[] { "a", "b" }).Wait();
        }

        [TestMethod]
        public void ShouldDeleteContainersAsync()
        {
            // Arrange
            IFilesApi filesApi = CreateFilesApi();

            // Act & Assert
            filesApi.DeleteContainersAsync(new[] { "a", "b" }).Wait();
        }

        [TestMethod]
        public void ShouldCreateFileAsync()
        {
            // Arrange
            IFilesApi filesApi = CreateFilesApi();

            // Act
            FileResponse fileResponse = filesApi.CreateFileAsync("applications", "calendar/test.txt", "Hello").Result;

            // Assert
            fileResponse.path.ShouldBe("applications/calendar/test.txt");
        }

        [TestMethod]
        public void ShouldGetFileAsync()
        {
            // Arrange
            IFilesApi filesApi = CreateFilesApi();

            // Act
            string content = filesApi.GetTextFileAsync("applications", "calendar/test.txt").Result;

            // Assert
            content.ShouldBe("Hello");
        }

        [TestMethod]
        public void ShouldDeleteFileAsync()
        {
            // Arrange
            IFilesApi filesApi = CreateFilesApi();

            // Act
            FileResponse fileResponse = filesApi.DeleteFileAsync("applications", "calendar/test.txt").Result;

            // Assert
            fileResponse.path.ShouldBe("applications/calendar/test.txt");
        }

        private static IFilesApi CreateFilesApi()
        {
            IHttpFacade httpFacade = new TestDataHttpFacade();
            HttpAddress address = new HttpAddress(BaseAddress, RestApiVersion.V1);
            HttpHeaders headers = new HttpHeaders();
            return new FilesApi(address, httpFacade, new JsonContentSerializer(), headers, "files");
        }

    }
}
