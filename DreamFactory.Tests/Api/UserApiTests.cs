namespace DreamFactory.Tests.Api
{
    using System.Collections.Generic;
    using System.Linq;
    using DreamFactory.Api;
    using DreamFactory.Api.Implementation;
    using DreamFactory.Http;
    using DreamFactory.Model.User;
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
            IUserApi userApi = CreateUserApi(out headers);
            Login login = CreateLogin();

            // Act
            Session session = userApi.LoginAsync("admin", login).Result;

            // Assert
            session.display_name.ShouldBe("Andrei Smirnov");
            session.session_id.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void ShouldGetSessionAsync()
        {
            // Arrange
            HttpHeaders headers;
            IUserApi userApi = CreateUserApi(out headers);
            Login login = CreateLogin();
            userApi.LoginAsync("admin", login).Wait();

            // Act
            Session session = userApi.GetSessionAsync().Result;

            // Assert
            session.session_id.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void LoginShouldChangeBaseHeaders()
        {
            // Arrange
            HttpHeaders headers;
            IUserApi userApi = CreateUserApi(out headers);
            Login login = CreateLogin();

            // Act
            userApi.LoginAsync("admin", login).Wait();

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
            IUserApi userApi = CreateUserApi(out headers);

            // Act
            bool logout = userApi.LogoutAsync().Result;

            // Assert
            logout.ShouldBe(true);
        }

        [TestMethod]
        public void LogoutShouldRemoveSessionToken()
        {
            // Arrange
            HttpHeaders headers;
            IUserApi userApi = CreateUserApi(out headers);
            Login login = CreateLogin();
            userApi.LoginAsync("admin", login).Wait();

            // Act
            userApi.LogoutAsync().Wait();

            // Assert
            headers.Build().ContainsKey(HttpHeaders.DreamFactorySessionTokenHeader).ShouldBe(false);
        }

        [TestMethod]
        public void ShouldGetProfileAsync()
        {
            // Arrange
            HttpHeaders headers;
            IUserApi userApi = CreateUserApi(out headers);

            // Act
            ProfileResponse profile = userApi.GetProfileAsync().Result;

            // Assert
            profile.display_name.ShouldBe("pinebit");
        }

        [TestMethod]
        public void ShouldUpdateProfileAsync()
        {
            // Arrange
            HttpHeaders headers;
            IUserApi userApi = CreateUserApi(out headers);
            ProfileRequest profileRequest = new ProfileRequest
                                            {
                                                first_name = "Alex",
                                                last_name = "Smith",
                                                display_name = "Alex Smith",
                                                default_app_id = 1,
                                                email = "alex@user.com",
                                                phone = null,
                                                security_question = "to be or not to be?",
                                                security_answer = "maybe",
                                            };

            // Act
            bool success = userApi.UpdateProfileAsync(profileRequest).Result;

            // Assert
            success.ShouldBe(true);
        }

        [TestMethod]
        public void ShouldChangePasswordAsync()
        {
            // Arrange
            HttpHeaders headers;
            IUserApi userApi = CreateUserApi(out headers);

            // Act
            bool ok = userApi.ChangePasswordAsync("abc", "cba").Result;

            // Assert
            ok.ShouldBe(true);
        }

        [TestMethod]
        public void ShouldGetDevicesAsync()
        {
            // Arrange
            HttpHeaders headers;
            IUserApi userApi = CreateUserApi(out headers);

            // Act
            List<DeviceResponse> devices = userApi.GetDevicesAsync().Result.ToList();

            // Assert
            devices.ShouldNotBeEmpty();
            devices.First().platform.ShouldBe("windows");
        }

        [TestMethod]
        public void ShouldSetDeviceAsync()
        {
            // Arrange
            HttpHeaders headers;
            IUserApi userApi = CreateUserApi(out headers);
            DeviceRequest request = new DeviceRequest
                                    {
                                        id = 1,
                                        uuid = "1",
                                        platform = "windows",
                                        model = "new",
                                        version = "1"
                                    };

            // Act
            bool ok = userApi.SetDeviceAsync(request).Result;

            // Assert
            ok.ShouldBe(true);
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
