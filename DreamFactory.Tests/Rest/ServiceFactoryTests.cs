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
        public void ShouldCreateUserSessionApi()
        {
            // Arrange
            HttpHeaders headers = new HttpHeaders();
            IServiceFactory factory = new ServiceFactory(Mock.Of<IHttpAddress>(), Mock.Of<IHttpFacade>(), Mock.Of<IContentSerializer>(), headers);

            // Act
            IUserSessionApi api = factory.CreateUserSessionApi();

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
    }
}
