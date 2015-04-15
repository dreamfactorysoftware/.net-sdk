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
            IUserApi userApi = CreateUserApi();

            // Act
            Session session = userApi.LoginAsync("admin", "user@mail.com", "userdream").Result;

            // Assert
            session.display_name.ShouldBe("Andrei Smirnov");
            session.session_id.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void ShouldGetSessionAsync()
        {
            // Arrange
            IUserApi userApi = CreateUserApi();
            userApi.LoginAsync("admin", "user@mail.com", "userdream").Wait();

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

            // Act
            userApi.LoginAsync("admin", "user@mail.com", "userdream").Wait();

            // Assert
            Dictionary<string, object> dictionary = headers.Build();
            dictionary.ContainsKey(HttpHeaders.DreamFactoryApplicationHeader).ShouldBe(true);
            dictionary.ContainsKey(HttpHeaders.DreamFactorySessionTokenHeader).ShouldBe(true);
            dictionary[HttpHeaders.DreamFactoryApplicationHeader].ShouldBe("admin");
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
            userApi.LoginAsync("admin", "user@mail.com", "userdream").Wait();

            // Act
            userApi.LogoutAsync().Wait();

            // Assert
            headers.Build().ContainsKey(HttpHeaders.DreamFactorySessionTokenHeader).ShouldBe(false);
        }

        [TestMethod]
        public void ShouldGetProfileAsync()
        {
            // Arrange
            IUserApi userApi = CreateUserApi();

            // Act
            ProfileResponse profile = userApi.GetProfileAsync().Result;

            // Assert
            profile.display_name.ShouldBe("pinebit");
        }

        [TestMethod]
        public void ShouldUpdateProfileAsync()
        {
            // Arrange
            IUserApi userApi = CreateUserApi();
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
            IUserApi userApi = CreateUserApi();

            // Act
            bool ok = userApi.ChangePasswordAsync("abc", "cba").Result;

            // Assert
            ok.ShouldBe(true);
        }

        [TestMethod]
        public void ShouldGetDevicesAsync()
        {
            // Arrange
            IUserApi userApi = CreateUserApi();

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
            IUserApi userApi = CreateUserApi();
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

        [TestMethod]
        public void ShouldGetCustomSettingsAsync()
        {
            IUserApi userApi = CreateUserApi();
            
            // Act
            Dictionary<string, Dictionary<string, object>> settings = userApi.GetCustomSettingsAsync().Result;

            // Assert
            settings.Count.ShouldBe(2);
            settings["setting2"].Count.ShouldBe(1);
            settings["setting2"]["enabled"].ShouldBe(true);
        }

        [TestMethod]
        public void ShouldSetCustomSettingsAsync()
        {
            // Arrange
            IUserApi userApi = CreateUserApi();
            Dictionary<string, Dictionary<string, object>> settings =
                new Dictionary<string, Dictionary<string, object>>
                {
                    { "setting1", new Dictionary<string, object> { { "age", 33 }, { "name", "John" } } },
                    { "setting2", new Dictionary<string, object> { { "enabled", true } } },
                };

            // Act
            bool ok = userApi.SetCustomSettingsAsync(settings).Result;

            // Assert
            ok.ShouldBe(true);
        }

        [TestMethod]
        public void ShouldGetCustomSettingAsync()
        {
            // Arrange
            IUserApi userApi = CreateUserApi();

            // Act
            Dictionary<string, object> setting1 = userApi.GetCustomSettingAsync("setting1").Result;

            // Assert
            setting1.Count.ShouldBe(2);
            setting1["age"].ShouldBe(33);
            setting1["name"].ShouldBe("John");
        }

        [TestMethod]
        public void ShouldDeleteCustomSettingAsync()
        {
            // Arrange
            IUserApi userApi = CreateUserApi();

            // Act
            bool ok = userApi.DeleteCustomSettingAsync("setting1").Result;

            // Assert
            ok.ShouldBe(true);
        }

        [TestMethod]
        public void ShouldRegisterAsync()
        {
            // Arrange
            IUserApi userApi = CreateUserApi();
            Register register = new Register
            {
                email = "test@mail.com",
                first_name = "first",
                last_name = "last",
                display_name = "display",
                new_password = "qwerty"
            };

            // Act
            bool ok = userApi.RegisterAsync(register).Result;

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
            response.security_question.ShouldBe("to be or not to be?");
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
