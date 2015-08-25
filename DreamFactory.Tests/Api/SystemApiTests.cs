namespace DreamFactory.Tests.Api
{
    using System.Collections.Generic;
    using System.Linq;
    using DreamFactory.Api;
    using DreamFactory.Api.Implementation;
    using DreamFactory.Http;
    using DreamFactory.Model.Database;
    using DreamFactory.Model.System.App;
    using DreamFactory.Model.System.AppGroup;
    using DreamFactory.Model.System.Config;
    using DreamFactory.Model.System.Environment;
    using DreamFactory.Model.System.Event;
    using DreamFactory.Model.System.Role;
    using DreamFactory.Model.System.Script;
    using DreamFactory.Model.System.Service;
    using DreamFactory.Model.System.User;
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
            List<AppResponse> apps = systemApi.GetAppsAsync(new SqlQuery()).Result.ToList();

            // Assert
            apps.Count.ShouldBe(5);
            apps.First().ApiName.ShouldBe("todojquery");
        }

        [TestMethod]
        public void ShouldGetUsersAsync()
        {
            // Arrange
            ISystemApi systemApi = CreateSystemApi();

            // Act
            List<UserResponse> users = systemApi.GetUsersAsync(new SqlQuery()).Result.ToList();

            // Assert
            users.Count.ShouldBe(2);
            users.First().DisplayName.ShouldBe("Andrei Smirnov");
        }

        [TestMethod]
        public void ShouldGetRolesAsync()
        {
            // Arrange
            ISystemApi systemApi = CreateSystemApi();

            // Act
            List<RoleResponse> roles = systemApi.GetRolesAsync(new SqlQuery()).Result.ToList();

            // Assert
            roles.Count.ShouldBe(1);
            roles.First().Name.ShouldBe("TestRole");
        }

        [TestMethod]
        public void ShouldGetServicesAsync()
        {
            // Arrange
            ISystemApi systemApi = CreateSystemApi();

            // Act
            List<ServiceResponse> services = systemApi.GetServicesAsync(new SqlQuery()).Result.ToList();

            // Assert
            services.Count.ShouldBe(4);
            services.First().Name.ShouldBe("Database");
        }

        [TestMethod]
        public void ShouldGetAppGroupAsync()
        {
            // Arrange
            ISystemApi systemApi = CreateSystemApi();

            // Act
            List<AppGroupResponse> appGroups = systemApi.GetAppGroupsAsync(new SqlQuery()).Result.ToList();

            // Assert
            appGroups.Count.ShouldBe(1);
            appGroups.First().Name.ShouldBe("NewGroup");
        }

        [TestMethod]
        public void ShouldGetScriptsAsync()
        {
            // Arrange
            ISystemApi systemApi = CreateSystemApi();

            // Act
            List<ScriptResponse> scripts = systemApi.GetScriptsAsync(true).Result.ToList();

            // Assert
            scripts.Count.ShouldBe(1);
            scripts.First().Language.ShouldBe("js");
            scripts.First().EventName.ShouldBe("sample-scripts");
        }

        [TestMethod]
        public void ShouldGetEventsAsync()
        {
            // Arrange
            ISystemApi systemApi = CreateSystemApi();

            // Act
            List<EventCacheResponse> responses = systemApi.GetEventsAsync(true).Result.ToList();

            // Assert
            responses.Count.ShouldBe(5);
            responses.First().Name.ShouldBe("user");
            responses.First().Paths.Count.ShouldBe(8);
        }

        [TestMethod]
        public void ShouldCreateAppAsync()
        {
            // Arrange
            ISystemApi systemApi = CreateSystemApi();
            AppRequest app = CreateApp();

            // Act
            AppResponse created = systemApi.CreateAppsAsync(new SqlQuery(), app).Result.First();

            // Assert
            created.Name.ShouldBe("Todo List jQuery");
        }

        [TestMethod]
        public void ShouldUpdateAppAsync()
        {
            // Arrange
            ISystemApi systemApi = CreateSystemApi();
            AppRequest app = CreateApp();

            // Act & Assert
            systemApi.UpdateAppsAsync(new SqlQuery(), app).Wait();
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

        [TestMethod]
        public void ShouldGetEnvironmentAsync()
        {
            // Arrange
            ISystemApi systemApi = CreateSystemApi();

            // Act
            EnvironmentResponse environment = systemApi.GetEnvironmentAsync().Result;

            // Assert
            environment.Server.ServerOs.ShouldBe("linux");
        }

        [TestMethod]
        public void ShouldGetConfigAsync()
        {
            // Arrange
            ISystemApi systemApi = CreateSystemApi();

            // Act
            ConfigResponse config = systemApi.GetConfigAsync().Result;

            // Assert
            config.DbVersion.ShouldBe("1.9.0");
            config.InstallName.ShouldBe("Bitnami Package");
            config.Paths.Count.ShouldBe(6);
            config.States.OperationState.ShouldBe(-1);
        }

        [TestMethod]
        public void ShouldGetConstantsAsync()
        {
            // Arrange
            ISystemApi systemApi = CreateSystemApi();

            // Act
            List<string> types = systemApi.GetConstantsAsync().Result.ToList();

            // Assert
            types.Count.ShouldBe(19);
            types.ShouldContain("content_types");
        }

        [TestMethod]
        public void ShouldGetConstantAsync()
        {
            // Arrange
            ISystemApi systemApi = CreateSystemApi();

            // Act
            Dictionary<string, string> constant = systemApi.GetConstantAsync("content_types").Result;

            // Assert
            constant.Count.ShouldBe(14);
            constant.Keys.ShouldContain("HTML");
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
                Id = 1,
                Name = "Todo List jQuery",
                ApiName = "todojquery",
                Description = "A simple jQuery application showing how to create, update, and delete database records on the DreamFactory Services Platform.",
                IsActive = true,
                Url = "/index.html",
                IsUrlExternal = false,
                ImportUrl = "https://raw.github.com/dreamfactorysoftware/app-todo-jquery/master/todojquery.dfpkg",
                StorageServiceId = "2",
                StorageContainer = "applications",
                RequiresFullscreen = false,
                AllowFullscreenToggle = true,
                ToggleLocation = "top",
                RequiresPlugin = false
            };
        }
    }
}