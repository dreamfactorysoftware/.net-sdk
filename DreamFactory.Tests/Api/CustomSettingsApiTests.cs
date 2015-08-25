namespace DreamFactory.Tests.Api
{
    using System.Collections.Generic;
    using System.Linq;
    using DreamFactory.Api;
    using DreamFactory.Api.Implementation;
    using DreamFactory.Http;
    using DreamFactory.Rest;
    using DreamFactory.Serialization;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Shouldly;

    [TestClass]
    public class CustomSettingsApiTests
    {
        private const string BaseAddress = "http://localhost:8765";

        [TestMethod]
        public void ShouldGetCustomSettingsAsync()
        {
            // Arrange
            ICustomSettingsApi settingsApi = CreateSettingsApi();

            // Act
            IEnumerable<string> names = settingsApi.GetCustomSettingsAsync().Result;

            // Assert
            names.Single().ShouldBe("preferences");
        }

        [TestMethod]
        public void ShouldSetCustomSettingAsync()
        {
            // Arrange
            ICustomSettingsApi settingsApi = CreateSettingsApi();
            UserPreferences preferences = CreateUserPreferences();

            // Act
            bool ok = settingsApi.SetCustomSettingAsync("preferences", preferences).Result;

            // Assert
            ok.ShouldBe(true);
        }

        [TestMethod]
        public void ShouldGetCustomSettingAsync()
        {
            // Arrange
            ICustomSettingsApi settingsApi = CreateSettingsApi();

            // Act
            UserPreferences setting = settingsApi.GetCustomSettingAsync<UserPreferences>("preferences").Result;

            // Assert
            setting.Flag.ShouldBe(true);
            setting.Array.Length.ShouldBe(3);
            setting.entity.Rank.ShouldBe(4);
            setting.entity.Role.ShouldBe("user");
        }

        [TestMethod]
        public void ShouldDeleteCustomSettingAsync()
        {
            // Arrange
            ICustomSettingsApi settingsApi = CreateSettingsApi();

            // Act
            bool ok = settingsApi.DeleteCustomSettingAsync("preferences").Result;

            // Assert
            ok.ShouldBe(true);
        }

        private static ICustomSettingsApi CreateSettingsApi()
        {
            IHttpFacade httpFacade = new TestDataHttpFacade();
            HttpAddress address = new HttpAddress(BaseAddress, RestApiVersion.V1);
            return new CustomSettingsApi(address, httpFacade, new JsonContentSerializer(), new HttpHeaders(), "user");
        }

        private static UserPreferences CreateUserPreferences()
        {
            return new UserPreferences
            {
                Flag = true,
                Array = new[] { "a", "b", "c" },
                entity = new UserPreferences.Entity { Rank = 4, Role = "user" }
            };
        }

        internal class UserPreferences
        {
            public bool Flag { get; set; }
            public string[] Array { get; set; }
            public Entity entity { get; set; }

            internal class Entity
            {
                public int Rank { get; set; }
                public string Role { get; set; }
            }
        }
    }
}