namespace DreamFactory.Model.System.Service
{
    using global::System;

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
        /// Label of this service.
        /// </summary>
        public string Label { get; set; }

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
    }
}