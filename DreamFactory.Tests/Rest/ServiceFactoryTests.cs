namespace DreamFactory.Tests.Rest
{
    using DreamFactory.Api;
    using DreamFactory.Http;
    using DreamFactory.Rest;
    using DreamFactory.Serialization;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Shouldly;

    [TestClass]
    public class ServiceFactoryTests
    {
        [TestMethod]
        public void ShouldCreateUserApi()
        {
            // Arrange
            HttpHeaders headers = new HttpHeaders();
            IServiceFactory factory = new ServiceFactory(Mock.Of<IHttpAddress>(), Mock.Of<IHttpFacade>(), Mock.Of<IContentSerializer>(), headers);

            // Act
            IUserApi api = factory.CreateUserApi();

            // Assert
            api.ShouldNotBe(null);
        }

        [TestMethod]
        public void ShouldCreateFilesApi()
        {
            // Arrange
            HttpHeaders headers = new HttpHeaders();
            IServiceFactory factory = new ServiceFactory(Mock.Of<IHttpAddress>(), Mock.Of<IHttpFacade>(), Mock.Of<IContentSerializer>(), headers);

            // Act
            IFilesApi api = factory.CreateFilesApi("files");

            // Assert
            api.ShouldNotBe(null);
        }

        [TestMethod]
        public void ShouldCreateEmailApi()
        {
            // Arrange
            HttpHeaders headers = new HttpHeaders();
            IServiceFactory factory = new ServiceFactory(Mock.Of<IHttpAddress>(), Mock.Of<IHttpFacade>(), Mock.Of<IContentSerializer>(), headers);

            // Act
            IEmailApi api = factory.CreateEmailApi("email");

            // Assert
            api.ShouldNotBe(null);
        }

        [TestMethod]
        public void ShouldCreateDatabaseApi()
        {
            // Arrange
            HttpHeaders headers = new HttpHeaders();
            IServiceFactory factory = new ServiceFactory(Mock.Of<IHttpAddress>(), Mock.Of<IHttpFacade>(), Mock.Of<IContentSerializer>(), headers);

            // Act
            IDatabaseApi api = factory.CreateDatabaseApi("mysql");

            // Assert
            api.ShouldNotBe(null);
        }

        [TestMethod]
        public void ShouldCreateSystemApi()
        {
            // Arrange
            HttpHeaders headers = new HttpHeaders();
            IServiceFactory factory = new ServiceFactory(Mock.Of<IHttpAddress>(), Mock.Of<IHttpFacade>(), Mock.Of<IContentSerializer>(), headers);

            // Act
            ISystemApi api = factory.CreateSystemApi();

            // Assert
            api.ShouldNotBe(null);
        }

        [TestMethod]
        public void ShouldCreateSystemCustomSettingsApi()
        {
            // Arrange
            HttpHeaders headers = new HttpHeaders();
            IServiceFactory factory = new ServiceFactory(Mock.Of<IHttpAddress>(), Mock.Of<IHttpFacade>(), Mock.Of<IContentSerializer>(), headers);

            // Act
            ICustomSettingsApi api = factory.CreateSystemCustomSettingsApi();

            // Assert
            api.ShouldNotBe(null);
        }

        [TestMethod]
        public void ShouldCreateUserCustomSettingsApi()
        {
            // Arrange
            HttpHeaders headers = new HttpHeaders();
            IServiceFactory factory = new ServiceFactory(Mock.Of<IHttpAddress>(), Mock.Of<IHttpFacade>(), Mock.Of<IContentSerializer>(), headers);

            // Act
            ICustomSettingsApi api = factory.CreateUserCustomSettingsApi();

            // Assert
            api.ShouldNotBe(null);
        }

        [TestMethod]
        public void ShouldCreateSystemAdminApi()
        {
            // Arrange
            HttpHeaders headers = new HttpHeaders();
            IServiceFactory factory = new ServiceFactory(Mock.Of<IHttpAddress>(), Mock.Of<IHttpFacade>(), Mock.Of<IContentSerializer>(), headers);

            // Act
            ISystemAdminApi api = factory.CreateSystemAdminApi();

            // Assert
            api.ShouldNotBe(null);
        }

        [TestMethod]
        public void ShouldCreateSystemAppApi()
        {
            // Arrange
            HttpHeaders headers = new HttpHeaders();
            IServiceFactory factory = new ServiceFactory(Mock.Of<IHttpAddress>(), Mock.Of<IHttpFacade>(), Mock.Of<IContentSerializer>(), headers);

            // Act
            ISystemAppApi api = factory.CreateSystemAppApi();

            // Assert
            api.ShouldNotBe(null);
        }

        [TestMethod]
        public void ShouldCreateSystemAppGroupApi()
        {
            // Arrange
            HttpHeaders headers = new HttpHeaders();
            IServiceFactory factory = new ServiceFactory(Mock.Of<IHttpAddress>(), Mock.Of<IHttpFacade>(), Mock.Of<IContentSerializer>(), headers);

            // Act
            ISystemAppGroupApi api = factory.CreateSystemAppGroupApi();

            // Assert
            api.ShouldNotBe(null);
        }

        [TestMethod]
        public void ShouldCreateSystemEmailTemplateApi()
        {
            // Arrange
            HttpHeaders headers = new HttpHeaders();
            IServiceFactory factory = new ServiceFactory(Mock.Of<IHttpAddress>(), Mock.Of<IHttpFacade>(), Mock.Of<IContentSerializer>(), headers);

            // Act
            ISystemEmailTemplateApi api = factory.CreateSystemEmailTemplateApi();

            // Assert
            api.ShouldNotBe(null);
        }

        [TestMethod]
        public void ShouldCreateSystemEventApi()
        {
            // Arrange
            HttpHeaders headers = new HttpHeaders();
            IServiceFactory factory = new ServiceFactory(Mock.Of<IHttpAddress>(), Mock.Of<IHttpFacade>(), Mock.Of<IContentSerializer>(), headers);

            // Act
            ISystemEventApi api = factory.CreateSystemEventApi();

            // Assert
            api.ShouldNotBe(null);
        }

        [TestMethod]
        public void ShouldCreateSystemRoleApi()
        {
            // Arrange
            HttpHeaders headers = new HttpHeaders();
            IServiceFactory factory = new ServiceFactory(Mock.Of<IHttpAddress>(), Mock.Of<IHttpFacade>(), Mock.Of<IContentSerializer>(), headers);

            // Act
            ISystemRoleApi api = factory.CreateSystemRoleApi();

            // Assert
            api.ShouldNotBe(null);
        }

        [TestMethod]
        public void ShouldCreateSystemServiceApi()
        {
            // Arrange
            HttpHeaders headers = new HttpHeaders();
            IServiceFactory factory = new ServiceFactory(Mock.Of<IHttpAddress>(), Mock.Of<IHttpFacade>(), Mock.Of<IContentSerializer>(), headers);

            // Act
            ISystemServiceApi api = factory.CreateSystemServiceApi();

            // Assert
            api.ShouldNotBe(null);
        }

        [TestMethod]
        public void ShouldCreateSystemUserApi()
        {
            // Arrange
            HttpHeaders headers = new HttpHeaders();
            IServiceFactory factory = new ServiceFactory(Mock.Of<IHttpAddress>(), Mock.Of<IHttpFacade>(), Mock.Of<IContentSerializer>(), headers);

            // Act
            ISystemUserApi api = factory.CreateSystemUserApi();

            // Assert
            api.ShouldNotBe(null);
        }
    }
}
