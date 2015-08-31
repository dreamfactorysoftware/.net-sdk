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
    using DreamFactory.Model.User;
    using DreamFactory.Rest;
    using DreamFactory.Serialization;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Shouldly;

    [TestClass]
    public class SystemApiTests
    {
        private const string BaseAddress = "http://localhost:8765";
        private const string AppName = "admin";
        private const string AppApiKey = "api_key";

        #region --- Session ---

        [TestMethod]
        public void ShouldLoginAsync()
        {
            // Arrange
            ISystemApi systemApi = CreateSystemApi();

            // Act
            Session session = systemApi.LoginAdminAsync(AppName, AppApiKey, "dream@factory.com", "dreamfactory").Result;

            // Assert
            session.Name.ShouldBe("SuperAdmin");
            session.SessionId.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void ShouldGetSessionAsync()
        {
            // Arrange
            ISystemApi systemApi = CreateSystemApi();
            systemApi.LoginAdminAsync(AppName, AppApiKey, "dream@factory.com", "dreamfactory").Wait();

            // Act
            Session session = systemApi.GetAdminSessionAsync().Result;

            // Assert
            session.SessionId.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void LoginShouldChangeBaseHeaders()
        {
            // Arrange
            HttpHeaders headers;
            ISystemApi systemApi = CreateSystemApi(out headers);

            // Act
            systemApi.LoginAdminAsync(AppName, AppApiKey, "dream@factory.com", "dreamfactory").Wait();

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
            ISystemApi systemApi = CreateSystemApi();

            // Act
            bool logout = systemApi.LogoutAdminAsync().Result;

            // Assert
            logout.ShouldBe(true);
        }

        [TestMethod]
        public void LogoutShouldRemoveSessionToken()
        {
            // Arrange
            HttpHeaders headers;
            ISystemApi systemApi = CreateSystemApi(out headers);
            systemApi.LoginAdminAsync(AppName, AppApiKey, "dream@factory.com", "dreamfactory").Wait();

            // Act
            systemApi.LogoutAdminAsync().Wait();

            // Assert
            headers.Build().ContainsKey(HttpHeaders.DreamFactorySessionTokenHeader).ShouldBe(false);
        }

        #endregion


        [TestMethod]
        public void ShouldGetAppsAsync()
        {
            // Arrange
            ISystemApi systemApi = CreateSystemApi();

            // Act
            List<AppResponse> apps = systemApi.GetAppsAsync(new SqlQuery()).Result.ToList();

            // Assert
            apps.Count.ShouldBe(4);
            apps.First().Name.ShouldBe("admin");
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
            users.First().Name.ShouldBe("demo");
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
        public void ShouldGetEventsAsync()
        {
            // Arrange
            ISystemApi systemApi = CreateSystemApi();

            // Act
            EventScriptResponse response = systemApi.GetEventScriptAsync("system.get.pre_process", new SqlQuery()).Result;

            // Assert
            response.Name.ShouldBe("my_custom_script");
            response.Type.ShouldBe("v8js");
        }

        [TestMethod]
        public void ShouldGetEventScriptsAsync()
        {
            // Arrange
            ISystemApi systemApi = CreateSystemApi();

            // Act
            List<string> events = systemApi.GetEventsAsync().Result.ToList();

            // Assert
            events.Count.ShouldBe(5);
            events.First().ShouldBe("system.get.pre_process");
        }

        [TestMethod]
        public void ShouldCreateAppAsync()
        {
            // Arrange
            ISystemApi systemApi = CreateSystemApi();
            AppRequest app = CreateApp();
            app.Id = null;

            // Act
            AppResponse created = systemApi.CreateAppsAsync(new SqlQuery(), app).Result.First();

            // Assert
            created.Id.ShouldBe(1);
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
            systemApi.DeleteAppsAsync(new SqlQuery(), 1, 2, 3);
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
                Name = "admin",
                Description = "An application for administering this instance.",
                IsActive = true,
                RequiresFullscreen = false,
                AllowFullscreenToggle = true,
                ToggleLocation = "top",
                RoleId = 2
            };
        }
    }
}