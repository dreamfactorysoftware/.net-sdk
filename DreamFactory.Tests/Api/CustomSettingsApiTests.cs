namespace DreamFactory.Tests.Api
{
    using System.Collections.Generic;
    using System.Linq;
    using DreamFactory.Api;
    using DreamFactory.Api.Implementation;
    using DreamFactory.Http;
    using DreamFactory.Model.System.Custom;
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
            IEnumerable<string> names = settingsApi.GetCustomSettingsAsync().Result.Select(x => x.Name);

            // Assert
            names.ShouldContain("preferences");
        }

        [TestMethod]
        public void ShouldSetCustomSettingAsync()
        {
            // Arrange
            ICustomSettingsApi settingsApi = CreateSettingsApi();
            List<CustomRequest> userSettings = CreateUserSettings();

            // Act
            bool ok = settingsApi.SetCustomSettingsAsync(userSettings).Result.Any();

            // Assert
            ok.ShouldBe(true);
        }

        [TestMethod]
        public void ShouldGetCustomSettingAsync()
        {
            // Arrange
            ICustomSettingsApi settingsApi = CreateSettingsApi();

            // Act
            CustomResponse setting = settingsApi.GetCustomSettingAsync("Language").Result;

            // Assert
            setting.Value.ShouldBe("en-us");
        }

        [TestMethod]
        public void ShouldDeleteCustomSettingAsync()
        {
            // Arrange
            ICustomSettingsApi settingsApi = CreateSettingsApi();

            // Act
            CustomResponse settings = settingsApi.DeleteCustomSettingAsync("Language").Result;

            // Assert
            settings.Name.ShouldBe("Language");
        }

        private static ICustomSettingsApi CreateSettingsApi()
        {
            IHttpFacade httpFacade = new TestDataHttpFacade();
            HttpAddress address = new HttpAddress(BaseAddress, RestApiVersion.V1);
            return new CustomSettingsApi(address, httpFacade, new JsonContentSerializer(), new HttpHeaders(), "user");
        }

        private static List<CustomRequest> CreateUserSettings()
        {
            return new List<CustomRequest>
            {
                new CustomRequest
                {
                    Name = "Language",
                    Value = "en-us"
                },
                new CustomRequest
                {
                    Name = "TimeZone",
                    Value = "ET"
                }
            };

        }
    }
}