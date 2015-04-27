namespace DreamFactory.Tests.Api
{
    using System.Collections.Generic;
    using System.Linq;
    using DreamFactory.Api;
    using DreamFactory.Api.Implementation;
    using DreamFactory.Http;
    using DreamFactory.Model.System;
    using DreamFactory.Rest;
    using DreamFactory.Serialization;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Shouldly;

    [TestClass]
    public class SystemApiTests
    {
        private const string BaseAddress = "http://localhost";

        [TestMethod]
        public void ShouldGetAppsAsync()
        {
            // Arrange
            ISystemApi systemApi = CreateSystemApi();

            // Act
            List<AppResponse> apps = systemApi.GetAppsAsync().Result.ToList();

            // Assert
            apps.Count.ShouldBe(4);
        }

        [TestMethod]
        public void ShouldCreateAppAsync()
        {
            // Arrange
            ISystemApi systemApi = CreateSystemApi();
            AppRequest app = CreateApp();

            // Act
            AppResponse created = systemApi.CreateAppsAsync(app).Result.First();

            // Assert
            created.name.ShouldBe("Todo List jQuery");
        }

        [TestMethod]
        public void ShouldUpdateAppAsync()
        {
            // Arrange
            ISystemApi systemApi = CreateSystemApi();
            AppRequest app = CreateApp();

            // Act & Assert
            systemApi.UpdateAppsAsync(app).Wait();
        }

        [TestMethod]
        public void ShouldDeleteAppsAsync()
        {
            // Arrange
            ISystemApi systemApi = CreateSystemApi();

            // Act & Assert
            systemApi.DeleteAppsAsync(true, 1, 2, 3);
        }

        [TestMethod]
        public void ShouldDownloadApplicationPackageAsync()
        {
            // Arrange
            ISystemApi systemApi = CreateSystemApi();

            // Act
            byte[] data = systemApi.DownloadApplicationPackageAsync(1).Result;

            // Assert
            data.Length.ShouldBeGreaterThan(0);
        }

        [TestMethod]
        public void ShouldDownloadApplicationSdkAsync()
        {
            // Arrange
            ISystemApi systemApi = CreateSystemApi();

            // Act
            byte[] data = systemApi.DownloadApplicationSdkAsync(1).Result;

            // Assert
            data.Length.ShouldBeGreaterThan(0);
        }

        private static ISystemApi CreateSystemApi(string suffix = null)
        {
            HttpHeaders headers;
            return CreateSystemApi(out headers, suffix);
        }

        private static ISystemApi CreateSystemApi(out HttpHeaders headers, string suffix = null)
        {
            IHttpFacade httpFacade = new TestDataHttpFacade(suffix);
            HttpAddress address = new HttpAddress(BaseAddress, RestApiVersion.V1);
            headers = new HttpHeaders();
            return new SystemApi(address, httpFacade, new JsonContentSerializer(), headers);
        }

        private static AppRequest CreateApp()
        {
            return new AppRequest
            {
                id = 1,
                name = "Todo List jQuery",
                api_name = "todojquery",
                description = "A simple jQuery application showing how to create, update, and delete database records on the DreamFactory Services Platform.",
                is_active = true,
                url = "/index.html",
                is_url_external = false,
                import_url = "https://raw.github.com/dreamfactorysoftware/app-todo-jquery/master/todojquery.dfpkg",
                storage_service_id = "2",
                storage_container = "applications",
                requires_fullscreen = false,
                allow_fullscreen_toggle = true,
                toggle_location = "top",
                requires_plugin = false
            };
        }
    }
}