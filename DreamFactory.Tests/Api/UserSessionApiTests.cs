namespace DreamFactory.Tests.Api
{
    using System.Collections.Generic;
    using DreamFactory.Api;
    using DreamFactory.Http;
    using DreamFactory.Model;
    using DreamFactory.Rest;
    using DreamFactory.Serialization;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Shouldly;

    [TestClass]
    public class UserSessionApiTests
    {
        private const string BaseAddress = "http://localhost";

        [TestMethod]
        public void ShouldLoginAsync()
        {
            // Arrange
            IRestContext context = CreateRestContext();
            IUserSessionApi userSessionApi = context.GetServiceApi<IUserSessionApi>();
            Login login = CreateLogin();

            // Act
            Session session = userSessionApi.LoginAsync("admin", login).Result;

            // Assert
            session.display_name.ShouldBe("Andrei Smirnov");
            session.session_id.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void LoginShouldChangeBaseHeaders()
        {
            // Arrange
            IRestContext context = CreateRestContext();
            IUserSessionApi userSessionApi = context.GetServiceApi<IUserSessionApi>();
            Login login = CreateLogin();

            // Act
            userSessionApi.LoginAsync("admin", login).Wait();

            // Assert
            Dictionary<string, object> headers = context.BaseHeaders.Build();
            headers.ContainsKey(HttpHeaders.DreamFactoryApplicationHeader).ShouldBe(true);
            headers.ContainsKey(HttpHeaders.DreamFactorySessionTokenHeader).ShouldBe(true);
            headers[HttpHeaders.DreamFactoryApplicationHeader].ShouldBe("admin");
        }

        [TestMethod]
        public void ShouldLogoutAsync()
        {
            // Arrange
            IRestContext context = CreateRestContext();
            IUserSessionApi userSessionApi = context.GetServiceApi<IUserSessionApi>();

            // Act
            Logout logout = userSessionApi.LogoutAsync().Result;

            // Assert
            logout.success.ShouldBe(true);
        }

        [TestMethod]
        public void LogoutShouldRemoveSessionToken()
        {
            // Arrange
            IRestContext context = CreateRestContext();
            IUserSessionApi userSessionApi = context.GetServiceApi<IUserSessionApi>();
            Login login = CreateLogin();
            userSessionApi.LoginAsync("admin", login).Wait();

            // Act
            userSessionApi.LogoutAsync().Wait();

            // Assert
            context.BaseHeaders.Build().ContainsKey(HttpHeaders.DreamFactorySessionTokenHeader).ShouldBe(false);
        }

        private static IRestContext CreateRestContext()
        {
            IHttpFacade httpFacade = new TestDataHttpFacade();
            IRestContext context = new RestContext(BaseAddress, httpFacade, new JsonContentSerializer());
            return context;
        }

        private static Login CreateLogin()
        {
            return new Login { email = "user@mail.com", password = "userdream" };
        }
    }
}
