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
        private const string BaseAddress = "http://localhost:8765";
        private const string AppName = "admin";
        private const string AppApiKey = "api_key";

        #region --- Session ---

        [TestMethod]
        public void ShouldLoginAsync()
        {
            // Arrange
            IUserApi userApi = CreateUserApi();

            // Act
            Session session = userApi.LoginAsync(AppName, AppApiKey, "user@mail.com", "userdream").Result;

            // Assert
            session.Name.ShouldBe("demo");
            session.SessionId.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void ShouldGetSessionAsync()
        {
            // Arrange
            IUserApi userApi = CreateUserApi();
            userApi.LoginAsync(AppName, AppApiKey, "user@mail.com", "userdream").Wait();

            // Act
            Session session = userApi.GetSessionAsync().Result;

            // Assert
            session.SessionId.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void LoginShouldChangeBaseHeaders()
        {
            // Arrange
            HttpHeaders headers;
            IUserApi userApi = CreateUserApi(out headers);

            // Act
            userApi.LoginAsync(AppName, AppApiKey, "user@mail.com", "userdream").Wait();

            // Assert
            Dictionary<string, object> dictionary = headers.Build();
            dictionary.ContainsKey(HttpHeaders.FolderNameHeader).ShouldBe(true);
            dictionary.ContainsKey(HttpHeaders.DreamFactorySessionTokenHeader).ShouldBe(true);
            dictionary[HttpHeaders.FolderNameHeader].ShouldBe("admin");
        }

        [TestMethod]
        public void ShouldLogoutAsync()
        {
            // Arrange
            IUserApi userApi = CreateUserApi();

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
            userApi.LoginAsync(AppName, AppApiKey, "user@mail.com", "userdream").Wait();

            // Act
            userApi.LogoutAsync().Wait();

            // Assert
            headers.Build().ContainsKey(HttpHeaders.DreamFactorySessionTokenHeader).ShouldBe(false);
        }

        #endregion

        #region --- Profile ---

        [TestMethod]
        public void ShouldGetProfileAsync()
        {
            // Arrange
            IUserApi userApi = CreateUserApi();

            // Act
            ProfileResponse profile = userApi.GetProfileAsync().Result;

            // Assert
            profile.Name.ShouldBe("pinebit");
        }

        [TestMethod]
        public void ShouldUpdateProfileAsync()
        {
            // Arrange
            IUserApi userApi = CreateUserApi();
            ProfileRequest profileRequest = new ProfileRequest
                                            {
                                                FirstName = "Alex",
                                                LastName = "Smith",
                                                DisplayName = "Alex Smith",
                                                DefaultAppId = 1,
                                                Email = "alex@user.com",
                                                Phone = null,
                                                SecurityQuestion = "to be or not to be?",
                                                SecurityAnswer = "maybe",
                                            };

            // Act
            bool success = userApi.UpdateProfileAsync(profileRequest).Result;

            // Assert
            success.ShouldBe(true);
        }

        #endregion

        #region --- Device ---

        [TestMethod]
        public void ShouldGetDevicesAsync()
        {
            // Arrange
            IUserApi userApi = CreateUserApi();

            // Act
            List<DeviceResponse> devices = userApi.GetDevicesAsync().Result.ToList();

            // Assert
            devices.ShouldNotBeEmpty();
            devices.First().Platform.ShouldBe("windows");
        }

        [TestMethod]
        public void ShouldSetDeviceAsync()
        {
            // Arrange
            IUserApi userApi = CreateUserApi();
            DeviceRequest request = new DeviceRequest
                                    {
                                        Id = 1,
                                        Uuid = "1",
                                        Platform = "windows",
                                        Model = "new",
                                        Version = "1"
                                    };

            // Act
            bool ok = userApi.SetDeviceAsync(request).Result;

            // Assert
            ok.ShouldBe(true);
        }

        #endregion

        #region --- Register ---

        [TestMethod]
        public void ShouldRegisterAsync()
        {
            // Arrange
            IUserApi userApi = CreateUserApi();
            Register register = new Register
            {
                Email = "test@mail.com",
                FirstName = "first",
                LastName = "last",
                Name = "display",
                NewPassword = "qwerty"
            };

            // Act
            bool ok = userApi.RegisterAsync(register).Result;

            // Assert
            ok.ShouldBe(true);
        }

        #endregion

        #region --- Password ---


        [TestMethod]
        public void ShouldChangePasswordAsync()
        {
            // Arrange
            IUserApi userApi = CreateUserApi();

            // Act
            bool ok = userApi.ChangePasswordAsync("abc", "cba").Result;

            // Assert
            ok.ShouldBe(true);
        }

        [TestMethod]
        public void ShouldRequestPasswordResetAsync()
        {
            // Arrange
            IUserApi userApi = CreateUserApi("reset");

            // Act
            PasswordResponse response = userApi.RequestPasswordResetAsync("user@mail.com").Result;

            // Assert
            response.SecurityQuestion.ShouldBe("to be or not to be?");
        }

        [TestMethod]
        public void ShouldCompletePasswordResetAsync()
        {
            // Arrange
            IUserApi userApi = CreateUserApi("complete");

            // Act
            bool ok = userApi.CompletePasswordResetAsync("user@mail.com", "qwerty", answer: "maybe").Result;

            // Assert
            ok.ShouldBe(true);
        }

        #endregion

        private static IUserApi CreateUserApi(string suffix = null)
        {
            HttpHeaders headers;
            return CreateUserApi(out headers, suffix);
        }

        private static IUserApi CreateUserApi(out HttpHeaders headers, string suffix = null)
        {
            IHttpFacade httpFacade = new TestDataHttpFacade(suffix);
            HttpAddress address = new HttpAddress(BaseAddress, RestApiVersion.V1);
            headers = new HttpHeaders();
            return new UserApi(address, httpFacade, new JsonContentSerializer(), headers);
        }
    }
}
