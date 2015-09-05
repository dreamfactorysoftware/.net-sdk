namespace DreamFactory.Tests.Rest
{
    using System.Collections.Generic;
    using System.Linq;
    using DreamFactory.Http;
    using DreamFactory.Model;
    using DreamFactory.Rest;
    using DreamFactory.Serialization;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Shouldly;

    [TestClass]
    public class RestContextTests : BaseTest
    {
        [TestMethod]
        public void ShouldCreateHttpFacade()
        {
            // Arrange

            // Act
            RestContext context = new RestContext(BaseAddress, AppName, AppApiKey);
            
            // Assert
            context.HttpFacade.ShouldNotBe(null);
        }

        [TestMethod]
        public void ShouldCreateContentSerializer()
        {
            // Arrange

            // Act
            RestContext context = new RestContext(BaseAddress, AppName, AppApiKey);

            // Assert
            context.ContentSerializer.ShouldNotBe(null);
        }

        [TestMethod]
        public void ShouldCreateBaseHeaders()
        {
            // Arrange

            // Act
            RestContext context = new RestContext(BaseAddress, AppName, AppApiKey);

            // Assert
            context.BaseHeaders.ShouldNotBe(null);
        }

        [TestMethod]
        public void ShouldUseCustomHttpFacade()
        {
            // Arrange
            IHttpFacade facade = Mock.Of<IHttpFacade>();

            // Act
            RestContext context = new RestContext(BaseAddress, AppName, AppApiKey, null, facade, new JsonContentSerializer());

            // Assert
            context.HttpFacade.ShouldBeSameAs(facade);
        }

        [TestMethod]
        public void ShouldUseCustomContentSerializer()
        {
            // Arrange
            IContentSerializer serializer = Mock.Of<IContentSerializer>();

            // Act
            RestContext context = new RestContext(BaseAddress, AppName, AppApiKey, null, Mock.Of<IHttpFacade>(), serializer);

            // Assert
            context.ContentSerializer.ShouldBeSameAs(serializer);
        }

        [TestMethod]
        public void ShouldGetServicesAsync()
        {
            // Arrange
            IRestContext context = CreateRestContext();

            // Act
            List<string> services = context.GetServicesAsync().Result.ToList();

            // Assert
            services.ShouldNotBeEmpty();
            services.ShouldContain(x => x == "files");
            services.ShouldContain(x => x == "email");
        }

        [TestMethod]
        public void ShouldGetResourcesAsync()
        {
            // Arrange
            IRestContext context = CreateRestContext();

            // Act
            List<Resource> resources = context.GetResourcesAsync("user").Result.ToList();

            // Assert
            resources.ShouldNotBeEmpty();
            resources.ShouldContain(x => x.Name == "password");
            resources.ShouldContain(x => x.Name == "profile");
            resources.ShouldContain(x => x.Name == "session");
        }

        [TestMethod]
        public void ShouldSetApplicationName()
        {
            // Arrange
            IRestContext context = CreateRestContext();

            // Act
            context.SetApplicationName("foo");

            // Assert
            Dictionary<string, object> headers = context.BaseHeaders.Build();
            headers[HttpHeaders.FolderNameHeader].ShouldBe("foo");
        }

        private static IRestContext CreateRestContext()
        {
            IHttpFacade httpFacade = new TestDataHttpFacade();
            IRestContext context = new RestContext(BaseAddress, AppName, AppApiKey, null, httpFacade, new JsonContentSerializer());
            return context;
        }
    }
}
