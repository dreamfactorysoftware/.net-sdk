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
    }
}
