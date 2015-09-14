namespace DreamFactory.Api
{
    using DreamFactory.Model.Database;
    using DreamFactory.Model.System.Config;
    using DreamFactory.Model.System.Environment;
    using DreamFactory.Model.System.Script;
    using global::System.Collections.Generic;
    using global::System.Threading.Tasks;

    /// <summary>
    /// Represents /system API.
    /// </summary>
    public interface ISystemApi : ISystemAdminApi, ISystemAppApi, 
        ISystemAppGroupApi, ISystemEmailTemplateApi, ISystemEventApi, 
        ISystemRoleApi, ISystemServiceApi, ISystemUserApi
    {
        /// <summary>
        /// Retrieve system configuration properties.
        /// </summary>
        /// <returns>See <see cref="ConfigResponse"/>.</returns>
        Task<ConfigResponse> GetConfigAsync();

        /// <summary>
        /// Update one or more system configuration properties.
        /// </summary>
        /// <param name="config">New configuration properties.</param>
        /// <returns>See <see cref="ConfigResponse"/>.</returns>
        Task<ConfigResponse> SetConfigAsync(ConfigRequest config);

        /// <summary>
        /// Get all enumerated types.
        /// </summary>
        /// <returns>List of enumeration types.</returns>
        Task<IEnumerable<string>> GetConstantsAsync();

        /// <summary>
        /// Get enumerated type constant values.
        /// </summary>
        /// <param name="constant">Identifier of the enumeration type to retrieve.</param>
        /// <returns>Key-value pairs.</returns>
        Task<Dictionary<string, string>> GetConstantAsync(string constant);

        /// <summary>
        /// Retrieve environment information.
        /// </summary>
        /// <returns>See <see cref="EnvironmentResponse"/>.</returns>
        Task<EnvironmentResponse> GetEnvironmentAsync();

        /// <summary>
        /// Retrieve one or more script types.
        /// </summary>
        /// <param name="query">Query parameters.</param>
        /// <returns>List of script types.</returns>
        Task<IEnumerable<ScriptTypeResponse>> GetScriptTypesAsync(SqlQuery query);

    }
}
