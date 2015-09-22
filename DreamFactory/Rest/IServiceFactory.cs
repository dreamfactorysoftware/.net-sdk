namespace DreamFactory.Rest
{
    using DreamFactory.Api;

    /// <summary>
    /// Represents factory creating API instances.
    /// </summary>
    public interface IServiceFactory
    {
        /// <summary>
        /// Creates <see cref="IUserApi"/> instance.
        /// </summary>
        /// <returns><see cref="IUserApi"/> instance.</returns>
        IUserApi CreateUserApi();

        /// <summary>
        /// Creates <see cref="ISystemApi"/> instance.
        /// </summary>
        /// <returns><see cref="ISystemApi"/> instance.</returns>
        ISystemApi CreateSystemApi();

        /// <summary>
        /// Creates <see cref="IFilesApi"/> instance.
        /// </summary>
        /// <returns><see cref="IFilesApi"/> instance.</returns>
        IFilesApi CreateFilesApi(string serviceName);

        /// <summary>
        /// Creates <see cref="IEmailApi"/> instance.
        /// </summary>
        /// <returns><see cref="IEmailApi"/> instance.</returns>
        IEmailApi CreateEmailApi(string serviceName);

        /// <summary>
        /// Creates <see cref="IDatabaseApi"/> instance.
        /// </summary>
        /// <returns><see cref="IDatabaseApi"/> instance.</returns>
        IDatabaseApi CreateDatabaseApi(string serviceName);

        /// <summary>
        /// Creates <see cref="ICustomSettingsApi"/> instance for /user/custom.
        /// </summary>
        /// <returns><see cref="ICustomSettingsApi"/> instance.</returns>
        ICustomSettingsApi CreateUserCustomSettingsApi();

        /// <summary>
        /// Creates <see cref="ICustomSettingsApi"/> instance for /system/custom.
        /// </summary>
        /// <returns><see cref="ICustomSettingsApi"/> instance.</returns>
        ICustomSettingsApi CreateSystemCustomSettingsApi();

        /// <summary>
        /// Creates <see cref="ISystemAdminApi"/> instance for /system/admin.
        /// </summary>
        /// <returns><see cref="ISystemAdminApi"/> instance.</returns>
        ISystemAdminApi CreateSystemAdminApi();

        /// <summary>
        /// Creates <see cref="ISystemAppApi"/> instance for /system/app.
        /// </summary>
        /// <returns><see cref="ISystemAppApi"/> instance.</returns>
        ISystemAppApi CreateSystemAppApi();

        /// <summary>
        /// Creates <see cref="ISystemAppGroupApi"/> instance for /system/appgroup.
        /// </summary>
        /// <returns><see cref="ISystemAppGroupApi"/> instance.</returns>
        ISystemAppGroupApi CreateSystemAppGroupApi();

        /// <summary>
        /// Creates <see cref="ISystemEmailTemplateApi"/> instance for /system/emailtemplate.
        /// </summary>
        /// <returns><see cref="ISystemEmailTemplateApi"/> instance.</returns>
        ISystemEmailTemplateApi CreateSystemEmailTemplateApi();

        /// <summary>
        /// Creates <see cref="ISystemEventApi"/> instance for /system/event.
        /// </summary>
        /// <returns><see cref="ISystemEventApi"/> instance.</returns>
        ISystemEventApi CreateSystemEventApi();

        /// <summary>
        /// Creates <see cref="ISystemRoleApi"/> instance for /system/role.
        /// </summary>
        /// <returns><see cref="ISystemRoleApi"/> instance.</returns>
        ISystemRoleApi CreateSystemRoleApi();

        /// <summary>
        /// Creates <see cref="ISystemServiceApi"/> instance for /system/service.
        /// </summary>
        /// <returns><see cref="ISystemServiceApi"/> instance.</returns>
        ISystemServiceApi CreateSystemServiceApi();

        /// <summary>
        /// Creates <see cref="ISystemUserApi"/> instance for /system/user.
        /// </summary>
        /// <returns><see cref="ISystemUserApi"/> instance.</returns>
        ISystemUserApi CreateSystemUserApi();
    }
}
