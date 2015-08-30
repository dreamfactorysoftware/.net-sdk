namespace DreamFactory.Model.System.Service
{
    using DreamFactory.Model.System.App;
    using DreamFactory.Model.System.Role;
    using global::System.Collections.Generic;

    /// <summary>
    /// ServiceResponse.
    /// </summary>
    public class ServiceRequest : IRecord
    {
        /// <summary>
        /// Identifier of this service.
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Displayable name of this service.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Name of the service to use in API transactions.
        /// </summary>
        public string ApiName { get; set; }

        /// <summary>
        /// Description of this service.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// True if this service is active for use.
        /// </summary>
        public bool? IsActive { get; set; }

        /// <summary>
        /// One of the supported service types.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// One of the supported enumerated service types.
        /// </summary>
        public int? TypeId { get; set; }

        /// <summary>
        /// They supported storage service type.
        /// </summary>
        public string StorageType { get; set; }

        /// <summary>
        /// One of the supported enumerated storage service types.
        /// </summary>
        public int? StorageTypeId { get; set; }

        /// <summary>
        /// Any credentials data required by the service.
        /// </summary>
        public Dictionary<string, object> Credentials { get; set; }

        /// <summary>
        /// The format of the returned data of the service.
        /// </summary>
        public string NativeFormat { get; set; }

        /// <summary>
        /// The base URL for remote web services.
        /// </summary>
        public string BaseUrl { get; set; }

        /// <summary>
        /// Additional URL parameters required by the service.
        /// </summary>
        public List<KeyValuePair<string, object>> Parameters { get; set; }

        /// <summary>
        /// Additional headers required by the service.
        /// </summary>
        public List<string> Headers { get; set; }

        /// <summary>
        /// Related apps by app to service assignment.
        /// </summary>
        public List<RelatedApp> Apps { get; set; }

        /// <summary>
        /// Related roles by service to role assignment.
        /// </summary>
        public List<RelatedRole> Roles { get; set; }
    }
}