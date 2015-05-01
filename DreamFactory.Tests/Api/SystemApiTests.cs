namespace DreamFactory.Tests.Api
{
    using System.Collections.Generic;
    using System.Linq;
    using DreamFactory.Api;
    using DreamFactory.Api.Implementation;
    using DreamFactory.Http;
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
            List<AppResponse> apps = systemApi.GetAppsAsync().Result.ToList();

            // Assert
            apps.Count.ShouldBe(4);
            apps.First().api_name.ShouldBe("todojquery");
        }

        [TestMethod]
        public void ShouldGetUsersAsync()
        {
            // Arrange
            ISystemApi systemApi = CreateSystemApi();

            // Act
            List<UserResponse> users = systemApi.GetUsersAsync().Result.ToList();

            // Assert
            users.Count.ShouldBe(2);
            users.First().display_name.ShouldBe("Andrei Smirnov");
        }

        [TestMethod]
        public void ShouldGetRolesAsync()
        {
            // Arrange
            ISystemApi systemApi = CreateSystemApi();

            // Act
            List<RoleResponse> roles = systemApi.GetRolesAsync().Result.ToList();

            // Assert
            roles.Count.ShouldBe(1);
            roles.First().name.ShouldBe("TestRole");
        }

        [TestMethod]
        public void ShouldGetServicesAsync()
        {
            // Arrange
            ISystemApi systemApi = CreateSystemApi();

            // Act
            List<ServiceResponse> services = systemApi.GetServicesAsync().Result.ToList();

            // Assert
            services.Count.ShouldBe(4);
            services.First().name.ShouldBe("Database");
        }

        [TestMethod]
        public void ShouldGetAppGroupAsync()
        {
            // Arrange
            ISystemApi systemApi = CreateSystemApi();

            // Act
            List<AppGroupResponse> appGroups = systemApi.GetAppGroupsAsync().Result.ToList();

            // Assert
            appGroups.Count.ShouldBe(1);
            appGroups.First().name.ShouldBe("NewGroup");
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
            scripts.First().language.ShouldBe("js");
            scripts.First().event_name.ShouldBe("sample-scripts");
        }

        [TestMethod]
        public void ShouldGetEventsAsync()
        {
            // Arrange
            ISystemApi systemApi = CreateSystemApi();

            // Act
            List<EventCacheResponse> responses = systemApi.GetEventsAsync(true, false).Result.ToList();

            // Assert
            responses.Count.ShouldBe(5);
            responses.First().name.ShouldBe("user");
            responses.First().paths.Count.ShouldBe(8);
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

        [TestMethod]
        public void ShouldGetEnvironmentAsync()
        {
            // Arrange
            ISystemApi systemApi = CreateSystemApi();

            // Act
            EnvironmentResponse environment = systemApi.GetEnvironmentAsync().Result;

            // Assert
            environment.server.server_os.ShouldBe("linux");
        }

        [TestMethod]
        public void ShouldGetConfigAsync()
        {
            // Arrange
            ISystemApi systemApi = CreateSystemApi();

            // Act
            ConfigResponse config = systemApi.GetConfigAsync().Result;

            // Assert
            config.db_version.ShouldBe("1.9.0");
            config.install_name.ShouldBe("Bitnami Package");
            config.paths.Count.ShouldBe(6);
            config.states.operation_state.ShouldBe(-1);
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