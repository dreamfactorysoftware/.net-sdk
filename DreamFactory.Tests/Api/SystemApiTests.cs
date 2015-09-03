namespace DreamFactory.Tests.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DreamFactory.Api;
    using DreamFactory.Api.Implementation;
    using DreamFactory.Http;
    using DreamFactory.Model;
    using DreamFactory.Model.Database;
    using DreamFactory.Model.System.App;
    using DreamFactory.Model.System.AppGroup;
    using DreamFactory.Model.System.Config;
    using DreamFactory.Model.System.Email;
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

        #region --- Session ---

        [TestMethod]
        public void ShouldLoginAdminAsync()
        {
            // Arrange
            ISystemApi systemApi = CreateSystemApi();

            // Act
            Session session = systemApi.LoginAdminAsync(AppName, AppApiKey, "dream@factory.com", "dreamfactory").Result;

            // Assert
            session.Name.ShouldBe("SuperAdmin");
            session.SessionId.ShouldNotBeEmpty();

            Should.Throw<ArgumentNullException>(() => systemApi.LoginAdminAsync(null, AppApiKey, "dream@factory.com", "dreamfactory"));
            Should.Throw<ArgumentNullException>(() => systemApi.LoginAdminAsync(AppName, null, "dream@factory.com", "dreamfactory"));
            Should.Throw<ArgumentNullException>(() => systemApi.LoginAdminAsync(AppName, AppApiKey, null, "dreamfactory"));
            Should.Throw<ArgumentNullException>(() => systemApi.LoginAdminAsync(AppName, AppApiKey, "dream@factory.com", null));
            Should.Throw<ArgumentOutOfRangeException>(() => systemApi.LoginAdminAsync(AppName, AppApiKey, "dream@factory.com", "dreamfactory", -9999));
        }

        [TestMethod]
        public void ShouldGetAdminSessionAsync()
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
        public void LoginAdminShouldChangeBaseHeaders()
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
        public void ShouldLogoutAdminAsync()
        {
            // Arrange
            ISystemApi systemApi = CreateSystemApi();

            // Act
            bool logout = systemApi.LogoutAdminAsync().Result;

            // Assert
            logout.ShouldBe(true);
        }

        [TestMethod]
        public void LogoutAdminShouldRemoveSessionToken()
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

        #region --- EmailTemplate ---

        [TestMethod]
        public void ShouldGetEmailTemplatesAsync()
        {
            // Arrange
            ISystemApi systemApi = CreateSystemApi();

            // Act
            List<EmailTemplateResponse> emailTemplates = systemApi.GetEmailTemplatesAsync(new SqlQuery()).Result.ToList();

            // Assert
            emailTemplates.Count.ShouldBe(3);
            emailTemplates.First().Name.ShouldBe("User Invite Default");

            Should.Throw<ArgumentNullException>(() => systemApi.GetEmailTemplatesAsync(null));
        }

        [TestMethod]
        public void ShouldCreateEmailTemplatesAsync()
        {
            // Arrange
            ISystemApi systemApi = CreateSystemApi();
            EmailTemplateRequest[] templates = CreateEmailTemplates();

            // Act
            List<EmailTemplateResponse> emailTemplates = systemApi.CreateEmailTemplatesAsync(new SqlQuery(), templates).Result.ToList();

            // Assert
            emailTemplates.Count.ShouldBe(3);
            emailTemplates.First().Name.ShouldBe("User Invite Default");

            Should.Throw<ArgumentNullException>(() => systemApi.CreateEmailTemplatesAsync(null, templates));
            Should.Throw<ArgumentException>(() => systemApi.CreateEmailTemplatesAsync(new SqlQuery(), null));
        }

        [TestMethod]
        public void ShouldUpdateEmailTemplatesAsync()
        {
            // Arrange
            ISystemApi systemApi = CreateSystemApi();
            EmailTemplateRequest[] templates = CreateEmailTemplates();

            // Act
            List<EmailTemplateResponse> emailTemplates = systemApi.UpdateEmailTemplatesAsync(new SqlQuery(), templates).Result.ToList();

            // Assert
            emailTemplates.Count.ShouldBe(3);
            emailTemplates.First().Name.ShouldBe("User Invite Default");

            Should.Throw<ArgumentNullException>(() => systemApi.UpdateEmailTemplatesAsync(null, templates));
            Should.Throw<ArgumentException>(() => systemApi.UpdateEmailTemplatesAsync(new SqlQuery(), null));
        }

        [TestMethod]
        public void ShouldDeleteEmailTemplatesAsync()
        {
            // Arrange
            ISystemApi systemApi = CreateSystemApi();
            EmailTemplateRequest[] templates = CreateEmailTemplates();
            int[] ids = new [] {1,2,3};

            // Act
            List<EmailTemplateResponse> emailTemplates = systemApi.DeleteEmailTemplatesAsync(new SqlQuery(), ids).Result.ToList();

            // Assert
            emailTemplates.Count.ShouldBe(3);
            emailTemplates.First().Name.ShouldBe("User Invite Default");

            Should.Throw<ArgumentNullException>(() => systemApi.DeleteEmailTemplatesAsync(null, ids));
            Should.Throw<ArgumentException>(() => systemApi.DeleteEmailTemplatesAsync(new SqlQuery(), null));
        }

        private EmailTemplateRequest[] CreateEmailTemplates()
        {
            return new []
            {
                new EmailTemplateRequest
                {
                    Id = 1,
                    Name = "User Invite Default",
                },
                new EmailTemplateRequest
                {
                    Id = 2,
                    Name = "User Registration Default"
                },
                new EmailTemplateRequest
                {
                    Id = 3,
                    Name = "Password reset Default"
                }
            };
        }

        #endregion

        #region --- EventScript ---

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
        public void ShouldGetScriptTypes()
        {
            // Arrange
            ISystemApi systemApi = CreateSystemApi();

            // Act
            List<ScriptTypeResponse> scriptTypes = systemApi.GetScriptTypesAsync(new SqlQuery()).Result.ToList();

            // Assert
            scriptTypes.Count.ShouldBe(1);
            scriptTypes.Select(x => x.Name).First().ShouldBe("v8js");
        }

        [TestMethod]
        public void ShouldCreateEventScriptAsync()
        {
            // Arrange
            ISystemApi systemApi = CreateSystemApi();
            EventScriptRequest eventScript = CreateEventScript();

            // Act
            EventScriptResponse response = systemApi.CreateEventScriptAsync("system.get.pre_process", eventScript, new SqlQuery()).Result;

            // Assert
            response.Name.ShouldBe("my_custom_script");
            response.Type.ShouldBe("v8js");

            Should.Throw<ArgumentNullException>(() => systemApi.CreateEventScriptAsync(null, eventScript, new SqlQuery()));
            Should.Throw<ArgumentNullException>(() => systemApi.CreateEventScriptAsync("system.get.pre_process", null, new SqlQuery()));
            Should.Throw<ArgumentNullException>(() => systemApi.CreateEventScriptAsync("system.get.pre_process", eventScript, null));
        }

        [TestMethod]
        public void ShouldUpdateEventScriptAsync()
        {
            // Arrange
            ISystemApi systemApi = CreateSystemApi();
            EventScriptRequest eventScript = CreateEventScript();

            // Act
            EventScriptResponse response = systemApi.UpdateEventScriptAsync("system.get.pre_process", eventScript, new SqlQuery()).Result;

            // Assert
            response.Name.ShouldBe("my_custom_script");
            response.Type.ShouldBe("v8js");

            Should.Throw<ArgumentNullException>(() => systemApi.CreateEventScriptAsync(null, eventScript, new SqlQuery()));
            Should.Throw<ArgumentNullException>(() => systemApi.CreateEventScriptAsync("system.get.pre_process", null, new SqlQuery()));
            Should.Throw<ArgumentNullException>(() => systemApi.CreateEventScriptAsync("system.get.pre_process", eventScript, null));
        }

        [TestMethod]
        public void ShouldDeleteEventScriptAsync()
        {
            // Arrange
            ISystemApi systemApi = CreateSystemApi();

            // Act
            EventScriptResponse response = systemApi.DeleteEventScriptAsync("system.get.pre_process", new SqlQuery()).Result;

            // Assert
            response.Name.ShouldBe("my_custom_script");
            response.Type.ShouldBe("v8js");

            Should.Throw<ArgumentNullException>(() => systemApi.DeleteEventScriptAsync(null, new SqlQuery()));
            Should.Throw<ArgumentNullException>(() => systemApi.DeleteEventScriptAsync("system.get.pre_process", null));
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

            Should.Throw<ArgumentNullException>(() => systemApi.GetEventScriptAsync(null, new SqlQuery()));
            Should.Throw<ArgumentNullException>(() => systemApi.GetEventScriptAsync("system.get.pre_process", null));
        }

        private static EventScriptRequest CreateEventScript()
        {
            return new EventScriptRequest
            {
                Name = "my_custom_script",
                Type = "v8js",
                IsActive = true,
                AffectsProcess = true,
                Content = "text",
                Config = "text"
            };
        }

        #endregion

        #region --- App ---

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

            Should.Throw<ArgumentNullException>(() => systemApi.GetAppsAsync(null));
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

            Should.Throw<ArgumentNullException>(() => systemApi.CreateAppsAsync(null, app));
            Should.Throw<ArgumentException>(() => systemApi.CreateAppsAsync(new SqlQuery()));
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

            Should.Throw<ArgumentNullException>(() => systemApi.DeleteAppsAsync(null, 1, 2, 3));
            Should.Throw<ArgumentException>(() => systemApi.DeleteAppsAsync(new SqlQuery()));
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

        #endregion

        #region --- Environment ---

        [TestMethod]
        public void ShouldGetEnvironmentAsync()
        {
            // Arrange
            ISystemApi systemApi = CreateSystemApi();

            // Act
            EnvironmentResponse environment = systemApi.GetEnvironmentAsync().Result;

            // Assert
            environment.Platform.VersionCurrent.ShouldBe("2.0");
        }

        #endregion

        #region --- Config ---

        [TestMethod]
        public void ShouldGetConfigAsync()
        {
            // Arrange
            ISystemApi systemApi = CreateSystemApi();

            // Act
            ConfigResponse config = systemApi.GetConfigAsync().Result;

            // Assert
            config.EditableProfileFields.ShouldBe("name");
        }

        [TestMethod]
        public void ShouldSetConfigAsync()
        {
            // Arrange
            ISystemApi systemApi = CreateSystemApi();
            ConfigRequest config = CreateConfig();

            // Act
            ConfigResponse response = systemApi.SetConfigAsync(config).Result;

            // Assert
            response.EditableProfileFields.ShouldBe("name");

            Should.Throw<ArgumentNullException>(() => systemApi.SetConfigAsync(null));
        }
        private ConfigRequest CreateConfig()
        {
            return new ConfigRequest
            {
                EditableProfileFields = "name",
                RestrictedVerbs = new List<string> { "patch" },
                TimestampFormat = ""
            };
        }

        #endregion

        #region --- Constant ---

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

        #endregion

        #region --- AppGroup ---

        [TestMethod]
        public void ShouldGetAppGroupAsync()
        {
            // Arrange
            ISystemApi systemApi = CreateSystemApi();

            // Act
            List<AppGroupResponse> appGroups = systemApi.GetAppGroupsAsync(new SqlQuery()).Result.ToList();

            // Assert
            appGroups.Count.ShouldBe(1);
            appGroups.First().Name.ShouldBe("my_app_group");
        }

        [TestMethod]
        public void ShouldCreateAppGroupAsync()
        {
            // Arrange
            ISystemApi systemApi = CreateSystemApi();
            AppGroupRequest appGroup = CreateAppGroup();
            appGroup.Id = null;

            // Act
            AppGroupResponse created = systemApi.CreateAppGroupsAsync(new SqlQuery(), appGroup).Result.First();

            // Assert
            created.Id.ShouldBe(1);

            Should.Throw<ArgumentNullException>(() => systemApi.CreateAppGroupsAsync(null, appGroup));
            Should.Throw<ArgumentException>(() => systemApi.CreateAppGroupsAsync(new SqlQuery()));
        }

        [TestMethod]
        public void ShouldUpdateAppGroupAsync()
        {
            // Arrange
            ISystemApi systemApi = CreateSystemApi();
            AppGroupRequest appGroup = CreateAppGroup();

            // Act & Assert
            systemApi.UpdateAppGroupsAsync(new SqlQuery(), appGroup).Wait();
        }

        [TestMethod]
        public void ShouldDeleteAppGroupsAsync()
        {
            // Arrange
            ISystemApi systemApi = CreateSystemApi();

            // Act & Assert
            systemApi.DeleteAppGroupsAsync(new SqlQuery(), 1);

            Should.Throw<ArgumentNullException>(() => systemApi.DeleteAppGroupsAsync(null, 1));
            Should.Throw<ArgumentException>(() => systemApi.DeleteAppGroupsAsync(new SqlQuery()));
        }

        private static AppGroupRequest CreateAppGroup()
        {
            return new AppGroupRequest
            {
                Id = 1,
                Name = "my_app_group",
                Description = "Contains my groups."
            };
        }

        #endregion

        #region --- Service ---

        [TestMethod]
        public void ShouldGetServicesAsync()
        {
            // Arrange
            ISystemApi systemApi = CreateSystemApi();

            // Act
            List<ServiceResponse> services = systemApi.GetServicesAsync(new SqlQuery()).Result.ToList();

            // Assert
            services.Count.ShouldBe(3);
            services.First().Name.ShouldBe("system");
        }

        [TestMethod]
        public void ShouldCreateServiceAsync()
        {
            // Arrange
            ISystemApi systemApi = CreateSystemApi();
            ServiceRequest service = CreateService();
            service.Id = null;

            // Act
            ServiceResponse created = systemApi.CreateServicesAsync(new SqlQuery(), service).Result.First();

            // Assert
            created.Id.ShouldBe(1);

            Should.Throw<ArgumentNullException>(() => systemApi.CreateServicesAsync(null, service));
            Should.Throw<ArgumentException>(() => systemApi.CreateServicesAsync(new SqlQuery()));
        }

        [TestMethod]
        public void ShouldUpdateServiceAsync()
        {
            // Arrange
            ISystemApi systemApi = CreateSystemApi();
            ServiceRequest service = CreateService();

            // Act & Assert
            systemApi.UpdateServicesAsync(new SqlQuery(), service).Wait();
        }

        [TestMethod]
        public void ShouldDeleteServicesAsync()
        {
            // Arrange
            ISystemApi systemApi = CreateSystemApi();

            // Act & Assert
            systemApi.DeleteServicesAsync(new SqlQuery(), 1, 2, 3);

            Should.Throw<ArgumentNullException>(() => systemApi.DeleteServicesAsync(null, 1, 2, 3));
            Should.Throw<ArgumentException>(() => systemApi.DeleteServicesAsync(new SqlQuery()));
        }

        private static ServiceRequest CreateService()
        {
            return new ServiceRequest
            {
                Id = 1,
                Name = "system",
                Label = "System Management",
                Description = "Service for managing system resources.",
                IsActive = true,
                Type= "system"
            };
        }

        #endregion

        #region --- Role ---

        [TestMethod]
        public void ShouldGetRolesAsync()
        {
            // Arrange
            ISystemApi systemApi = CreateSystemApi();

            // Act
            List<RoleResponse> roles = systemApi.GetRolesAsync(new SqlQuery()).Result.ToList();

            // Assert
            roles.Count.ShouldBe(2);
            roles.First().Name.ShouldBe("AddressBookUser");
        }

        [TestMethod]
        public void ShouldCreateRoleAsync()
        {
            // Arrange
            ISystemApi systemApi = CreateSystemApi();
            RoleRequest role = CreateRole();
            role.Id = null;

            // Act
            RoleResponse created = systemApi.CreateRolesAsync(new SqlQuery(), role).Result.First();

            // Assert
            created.Id.ShouldBe(1);

            Should.Throw<ArgumentNullException>(() => systemApi.CreateRolesAsync(null, role));
            Should.Throw<ArgumentException>(() => systemApi.CreateRolesAsync(new SqlQuery()));
        }

        [TestMethod]
        public void ShouldUpdateRoleAsync()
        {
            // Arrange
            ISystemApi systemApi = CreateSystemApi();
            RoleRequest role = CreateRole();

            // Act & Assert
            systemApi.UpdateRolesAsync(new SqlQuery(), role).Wait();
        }

        [TestMethod]
        public void ShouldDeleteRolesAsync()
        {
            // Arrange
            ISystemApi systemApi = CreateSystemApi();

            // Act & Assert
            systemApi.DeleteRolesAsync(new SqlQuery(), 1);

            Should.Throw<ArgumentNullException>(() => systemApi.DeleteRolesAsync(null, 1));
            Should.Throw<ArgumentException>(() => systemApi.DeleteRolesAsync(new SqlQuery()));
        }

        private static RoleRequest CreateRole()
        {
            return new RoleRequest
            {
                Id = 1,
                Name = "AddressBookUser",
                Description = "This role can access address book.",
                IsActive = true,
            };
        }

        #endregion

        #region --- User ---

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
        public void ShouldCreateUserAsync()
        {
            // Arrange
            ISystemApi systemApi = CreateSystemApi();
            UserRequest user = CreateUser();
            user.Id = null;

            // Act
            UserResponse created = systemApi.CreateUsersAsync(new SqlQuery(), user).Result.First();

            // Assert
            created.Id.ShouldBe(1);

            Should.Throw<ArgumentNullException>(() => systemApi.CreateUsersAsync(null, user));
            Should.Throw<ArgumentException>(() => systemApi.CreateUsersAsync(new SqlQuery()));
        }

        [TestMethod]
        public void ShouldUpdateUserAsync()
        {
            // Arrange
            ISystemApi systemApi = CreateSystemApi();
            UserRequest user = CreateUser();

            // Act & Assert
            systemApi.UpdateUsersAsync(new SqlQuery(), user).Wait();
        }

        [TestMethod]
        public void ShouldDeleteUsersAsync()
        {
            // Arrange
            ISystemApi systemApi = CreateSystemApi();

            // Act & Assert
            systemApi.DeleteUsersAsync(new SqlQuery(), 1);

            Should.Throw<ArgumentNullException>(() => systemApi.DeleteUsersAsync(null, 1));
            Should.Throw<ArgumentException>(() => systemApi.DeleteUsersAsync(new SqlQuery()));
        }

        private static UserRequest CreateUser()
        {
            return new UserRequest
            {
                Id = 1,
                Name = "dreamUser",
                FirstName = "Dream",
                LastName = "Factory",
                Email = "system@factory.com",
                IsActive = true,
            };
        }

        #endregion

    }
}