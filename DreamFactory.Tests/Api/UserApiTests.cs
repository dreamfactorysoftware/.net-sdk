namespace DreamFactory.Tests.Api
{
    using System.Collections.Generic;
    using DreamFactory.Api;
    using DreamFactory.Api.Implementation;
    using DreamFactory.Http;
    using DreamFactory.Model;
    using DreamFactory.Rest;
    using DreamFactory.Serialization;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Shouldly;

    [TestClass]
    public class UserApiTests
    {
        private const string BaseAddress = "http://localhost";

        [TestMethod]
        public void ShouldLoginAsync()
        {
            // Arrange
            HttpHeaders headers;
            IUserApi userSessionApi = CreateUserApi(out headers);
            Login login = CreateLogin();

            // Act
            Session session = userSessionApi.LoginAsync("admin", login).Result;

            // Assert
            session.display_name.ShouldBe("Andrei Smirnov");
            session.session_id.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void ShouldGetSessionAsync()
        {
            // Arrange
            HttpHeaders headers;
            IUserApi userSessionApi = CreateUserApi(out headers);
            Login login = CreateLogin();
            userSessionApi.LoginAsync("admin", login).Wait();

            // Act
            Session session = userSessionApi.GetSessionAsync().Result;

            // Assert
            session.session_id.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void LoginShouldChangeBaseHeaders()
        {
            // Arrange
            HttpHeaders headers;
            IUserApi userSessionApi = CreateUserApi(out headers);
            Login login = CreateLogin();

            // Act
            userSessionApi.LoginAsync("admin", login).Wait();

            // Assert
            Dictionary<string, object> _headers = headers.Build();
            _headers.ContainsKey(HttpHeaders.DreamFactoryApplicationHeader).ShouldBe(true);
            _headers.ContainsKey(HttpHeaders.DreamFactorySessionTokenHeader).ShouldBe(true);
            _headers[HttpHeaders.DreamFactoryApplicationHeader].ShouldBe("admin");
        }

        [TestMethod]
        public void ShouldLogoutAsync()
        {
            // Arrange
            HttpHeaders headers;
            IUserApi userSessionApi = CreateUserApi(out headers);

            // Act
            bool logout = userSessionApi.LogoutAsync().Result;

            // Assert
            logout.ShouldBe(true);
        }

        [TestMethod]
        public void LogoutShouldRemoveSessionToken()
        {
            // Arrange
            HttpHeaders headers;
            IUserApi userSessionApi = CreateUserApi(out headers);
            Login login = CreateLogin();
            userSessionApi.LoginAsync("admin", login).Wait();

            // Act
            userSessionApi.LogoutAsync().Wait();

            // Assert
            headers.Build().ContainsKey(HttpHeaders.DreamFactorySessionTokenHeader).ShouldBe(false);
        }

        private static IUserApi CreateUserApi(out HttpHeaders headers)
        {
            IHttpFacade httpFacade = new TestDataHttpFacade();
            HttpAddress address = new HttpAddress(BaseAddress, RestApiVersion.V1);
            headers = new HttpHeaders();
            return new UserApi(address, httpFacade, new JsonContentSerializer(), headers);
        }

        private static Login CreateLogin()
        {
            return new Login { email = "user@mail.com", password = "userdream" };
        }
    }
}
