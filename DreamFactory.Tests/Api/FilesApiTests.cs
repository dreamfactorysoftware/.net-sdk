namespace DreamFactory.Tests.Api
{
    using DreamFactory.Api;
    using DreamFactory.Http;
    using DreamFactory.Model;
    using DreamFactory.Rest;
    using DreamFactory.Serialization;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Shouldly;

    [TestClass]
    public class FilesApiTests
    {
        private const string BaseAddress = "http://localhost";

        [TestMethod]
        public void ShouldCreateFileAsync()
        {
            // Arrange
            IRestContext context = CreateRestContext();
            IFilesApi filesApi = context.GetServiceApi<IFilesApi>("files");

            // Act
            FileResponse fileResponse = filesApi.CreateFileAsync("applications", "calendar/test.txt", "Hello").Result;

            // Assert
            fileResponse.path.ShouldBe("applications/calendar/test.txt");
        }

        [TestMethod]
        public void ShouldGetFileAsync()
        {
            // Arrange
            IRestContext context = CreateRestContext();
            IFilesApi filesApi = context.GetServiceApi<IFilesApi>("files");

            // Act
            string content = filesApi.GetFileAsync("applications", "calendar/test.txt").Result;

            // Assert
            content.ShouldBe("Hello");
        }

        [TestMethod]
        public void ShouldDeleteFileAsync()
        {
            // Arrange
            IRestContext context = CreateRestContext();
            IFilesApi filesApi = context.GetServiceApi<IFilesApi>("files");

            // Act
            FileResponse fileResponse = filesApi.DeleteFileAsync("applications", "calendar/test.txt").Result;

            // Assert
            fileResponse.path.ShouldBe("applications/calendar/test.txt");
        }

        private static IRestContext CreateRestContext()
        {
            IHttpFacade httpFacade = new TestDataHttpFacade();
            IRestContext context = new RestContext(BaseAddress, httpFacade, new JsonContentSerializer());
            return context;
        }
    }
}
