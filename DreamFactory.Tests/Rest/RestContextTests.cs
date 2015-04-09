namespace DreamFactory.Tests.Rest
{
    using DreamFactory.Api;
    using DreamFactory.Http;
    using DreamFactory.Model;
    using DreamFactory.Rest;
    using DreamFactory.Serialization;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Shouldly;

    [TestClass]
    public class RestContextTests
    {
        private const string BaseAddress = "http://localhost";

        [TestMethod]
        public void ShouldCreateHttpFacade()
        {
            // Arrange

            // Act
            RestContext context = new RestContext(BaseAddress);
            
            // Assert
            context.HttpFacade.ShouldNotBe(null);
        }

        [TestMethod]
        public void ShouldCreateContentSerializer()
        {
            // Arrange

            // Act
            RestContext context = new RestContext(BaseAddress);

            // Assert
            context.ContentSerializer.ShouldNotBe(null);
        }

        [TestMethod]
        public void ShouldCreateBaseHeaders()
        {
            // Arrange

            // Act
            RestContext context = new RestContext(BaseAddress);

            // Assert
            context.BaseHeaders.ShouldNotBe(null);
        }

        [TestMethod]
        public void ShouldUseCustomHttpFacade()
        {
            // Arrange
            IHttpFacade facade = Mock.Of<IHttpFacade>();

            // Act
            RestContext context = new RestContext(BaseAddress, facade, new JsonContentSerializer());

            // Assert
            context.HttpFacade.ShouldBeSameAs(facade);
        }

        [TestMethod]
        public void ShouldUseCustomContentSerializer()
        {
            // Arrange
            IContentSerializer serializer = Mock.Of<IContentSerializer>();

            // Act
            RestContext context = new RestContext(BaseAddress, Mock.Of<IHttpFacade>(), serializer);

            // Assert
            context.ContentSerializer.ShouldBeSameAs(serializer);
        }

        [TestMethod]
        public void ShouldCreateUserSessionApi()
        {
            // Arrange
            IRestContext context = new RestContext(BaseAddress);

            // Act
            IUserSessionApi api = context.GetServiceApi<IUserSessionApi>();

            // Assert
            api.ShouldNotBe(null);
        }

        [TestMethod]
        public void ShouldCreateFilesApi()
        {
            // Arrange
            IRestContext context = new RestContext(BaseAddress);

            // Act
            IFilesApi api = context.GetServiceApi<IFilesApi>("xyz");

            // Assert
            api.ShouldNotBe(null);
        }

        [TestMethod]
        public void ShouldGetServicesAsync()
        {
            // Arrange
            IRestContext context = CreateRestContext();

            // Act
            Services services = context.GetServicesAsync().Result;

            // Assert
            services.service.ShouldNotBeEmpty();
            services.service.ShouldContain(x => x.api_name == "files");
            services.service.ShouldContain(x => x.api_name == "email");
        }

        [TestMethod]
        public void ShouldGetResourcesAsync()
        {
            // Arrange
            IRestContext context = CreateRestContext();

            // Act
            Resources resources = context.GetResourcesAsync("user").Result;

            // Assert
            resources.resource.ShouldNotBeEmpty();
            resources.resource.ShouldContain(x => x.name == "password");
            resources.resource.ShouldContain(x => x.name == "profile");
            resources.resource.ShouldContain(x => x.name == "session");
        }

        private static IRestContext CreateRestContext()
        {
            IHttpFacade httpFacade = new TestDataHttpFacade();
            IRestContext context = new RestContext(BaseAddress, httpFacade, new JsonContentSerializer());
            return context;
        }
    }
}
