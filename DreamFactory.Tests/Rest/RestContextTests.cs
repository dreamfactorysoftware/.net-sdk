namespace DreamFactory.Tests.Rest
{
    using System;
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

        [TestMethod]
        public void ShouldSetSessionIdHeader()
        {
            // Arrange
            IRestContext context = new RestContext(BaseAddress, AppName, AppApiKey, SessionId, new TestDataHttpFacade(), new JsonContentSerializer());

            // Act
            Dictionary<string, object> headers = context.BaseHeaders.Build();

            // Assert
            headers[HttpHeaders.DreamFactorySessionTokenHeader].ShouldBe(SessionId);
        }

        [TestMethod]
        public void ShouldThrowIfSetApplicationNameArgumentIsNull()
        {
            // Arrange
            IRestContext context = CreateRestContext();

            // Act & Assert
            Should.Throw<ArgumentNullException>(() => context.SetApplicationName(null));
        }

        [TestMethod]
        public void ShouldThrowIfAnyArgumentsAreNull()
        {
            // Arrange, Act & Assert
            Should.Throw<ArgumentException>(() => new RestContext(null, AppName, AppApiKey, null, new TestDataHttpFacade(), new JsonContentSerializer()));
            Should.Throw<ArgumentNullException>(() => new RestContext(BaseAddress, null, AppApiKey, null, new TestDataHttpFacade(), new JsonContentSerializer()));
            Should.Throw<ArgumentNullException>(() => new RestContext(BaseAddress, AppName, null, null, new TestDataHttpFacade(), new JsonContentSerializer()));
            Should.Throw<ArgumentNullException>(() => new RestContext(BaseAddress, AppName, AppApiKey, null, null, new JsonContentSerializer()));
            Should.Throw<ArgumentNullException>(() => new RestContext(BaseAddress, AppName, AppApiKey, null, new TestDataHttpFacade(), null));
        }

        private static IRestContext CreateRestContext()
        {
            IHttpFacade httpFacade = new TestDataHttpFacade();
            IRestContext context = new RestContext(BaseAddress, AppName, AppApiKey, null, httpFacade, new JsonContentSerializer());
            return context;
        }
    }
}
