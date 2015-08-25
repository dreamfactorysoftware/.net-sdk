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
        private const string BaseAddress = "http://localhost";

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
            setting.flag.ShouldBe(true);
            setting.array.Length.ShouldBe(3);
            setting.entity.rank.ShouldBe(4);
            setting.entity.role.ShouldBe("user");
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
                flag = true,
                array = new[] { "a", "b", "c" },
                entity = new UserPreferences.Entity { rank = 4, role = "user" }
            };
        }

        internal class UserPreferences
        {
            public bool flag { get; set; }
            public string[] array { get; set; }
            public Entity entity { get; set; }

            internal class Entity
            {
                public int rank { get; set; }
                public string role { get; set; }
            }
        }
    }
}