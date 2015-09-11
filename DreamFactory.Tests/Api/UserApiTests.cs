namespace DreamFactory.Tests.Api
{
    using System;
    using System.Collections.Generic;
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
        #region --- Session ---

        [TestMethod]
        public void ShouldLoginAsync()
        {
            // Arrange
            IUserApi userApi = CreateUserApi();

            // Act
            Session session = userApi.LoginAsync("demo@factory.com", "dreamfactory").Result;

            // Assert
            session.Name.ShouldBe("demo");
            session.SessionId.ShouldNotBeEmpty();

            Should.Throw<ArgumentNullException>(() => userApi.LoginAsync(null, "dreamfactory"));
            Should.Throw<ArgumentNullException>(() => userApi.LoginAsync("demo@factory.com", null));
            Should.Throw<ArgumentOutOfRangeException>(() => userApi.LoginAsync("demo@factory.com", "dreamfactory", -9999));
        }

        [TestMethod]
        public void ShouldGetSessionAsync()
        {
            // Arrange
            IUserApi userApi = CreateUserApi();
            userApi.LoginAsync("demo@factory.com", "dreamfactory").Wait();

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
            userApi.LoginAsync("demo@factory.com", "dreamfactory").Wait();

            // Assert
            Dictionary<string, object> dictionary = headers.Build();
            dictionary.ContainsKey(HttpHeaders.DreamFactorySessionTokenHeader).ShouldBe(true);
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
            userApi.LoginAsync("demo@factory.com", "dreamfactory").Wait();

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

            Should.Throw<ArgumentNullException>(() => userApi.UpdateProfileAsync(null));
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

            Should.Throw<ArgumentNullException>(() => userApi.RegisterAsync(null));
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

            Should.Throw<ArgumentNullException>(() => userApi.ChangePasswordAsync("abc", null));
            Should.Throw<ArgumentNullException>(() => userApi.ChangePasswordAsync(null, "cba"));
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

            Should.Throw<ArgumentNullException>(() => userApi.RequestPasswordResetAsync(null));
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

            Should.Throw<ArgumentNullException>(() => userApi.CompletePasswordResetAsync(null, "qwerty", answer: "maybe"));
            Should.Throw<ArgumentNullException>(() => userApi.CompletePasswordResetAsync("user@mail.com", null, answer: "maybe"));
            Should.Throw<ArgumentException>(() => userApi.CompletePasswordResetAsync("user@mail.com", "qwerty", answer: "maybe", code: "not"));
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
            HttpAddress address = new HttpAddress("http://base_address", RestApiVersion.V1);
            headers = new HttpHeaders();
            return new UserApi(address, httpFacade, new JsonContentSerializer(), headers);
        }
    }
}
